// All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QSharpCheck
{
    public static class TestCaseGenerator
    {
        private static readonly Random R = new Random(DateTime.Now.Millisecond);

        public static (double minTheta1, double maxTheta1, double minPhi1, double maxPhi1,
            double minTheta2, double maxTheta2, double minPhi2, double maxPhi2,
            int testCasesNo, int confidence, int
            measurements, int experiments, string propertyName, double proposedProbability, (int b1, int b2), double
            minOfDestinationTheta, double maxOfDestinationTheta)
            FileReader(string pathT)
        {
            var lines = new List<string>();
            try
            {
                lines = File.ReadAllLines(pathT).ToList();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File was not found: {e}");
            }

            lines.RemoveAll(string.IsNullOrWhiteSpace);

            for (var i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].Replace(" ", "");
                lines[i] = lines[i].Replace(";", "");
            }

            var testConditions = new List<int>();
            var propertyName = lines[0];
            int numberOfTestCases;
            var confidenceLevel = 0;
            var numberOfMeasurements = 0;
            var numberOfExperiments = 0;
            var angles = new List<double>();


            if (lines[1].StartsWith("("))
            {
                lines[1] = lines[1].Replace("(", "");
                lines[1] = lines[1].Replace(")", "");
                var userArgs = lines[1].Split(",");
                testConditions.AddRange(userArgs.Select(element => Convert.ToInt32(element)));
                if (testConditions.Count == 1)
                {
                    numberOfTestCases = testConditions[0];
                    confidenceLevel = 99;
                    numberOfMeasurements = 350;
                    numberOfExperiments = 300;
                }
                else
                {
                    numberOfTestCases = testConditions[0];
                    confidenceLevel = testConditions[1];
                    numberOfMeasurements = testConditions[2];
                    if (numberOfMeasurements < 300)
                    {
                        Console.WriteLine(
                            "The number of measurement should not be less than 300. Program will now close!");
                        Environment.Exit(0);
                    }

                    numberOfExperiments = testConditions[3];
                    if (numberOfExperiments < 300)
                    {
                        Console.WriteLine(
                            "The number of experiments should not be less than 300. Program will now close!");
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                numberOfTestCases = 10;
                confidenceLevel = 99;
                numberOfMeasurements = 350;
                numberOfExperiments = 300;
            }
            
            var preCons = lines.Where(l => l.StartsWith('{')).ToList();
            var postCons = lines.Where(l => l.StartsWith('[')).ToList();
            
            while (preCons.Count > 0)
            {
                var line = preCons[0];
                if (line.Contains("Qubit"))
                {
                    var begin0 = line.IndexOf('(');
                    var end0 = line.IndexOf(')');
                    var begin1 = line.LastIndexOf('(');
                    var end1 = line.LastIndexOf(')');
                    var thetaRange = line.Substring(begin0 + 1,
                        end0 - begin0 - 1).Split(",");
                    // order of adding: minOfTheta, maxOfTheta, minOfPhi, maxOfPhi
                    angles.Add(Convert.ToDouble(thetaRange[0]));
                    angles.Add(Convert.ToDouble(thetaRange[1]));
                    var phiRange = line.Substring(begin1 + 1,
                        end1 - begin1 - 1).Split(",");
                    angles.Add(Convert.ToDouble(phiRange[0]));
                    angles.Add(Convert.ToDouble(phiRange[1]));
                    preCons.RemoveAt(0);
                }
            }
            
            while (postCons.Count > 0)
            {
                var end0 = postCons[0].IndexOf('(');
                var assertionTypeName = postCons[0].Substring(1, end0 - 1);
                if (assertionTypeName.Equals("AssertEqualClassicalBits"))
                {
                    var (b1, b2) = RandomPairGenerator();
                    return (0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, numberOfTestCases, 0, 0, numberOfExperiments,
                        propertyName, 0.0,
                        (b1, b2), 0.0, 0.0);
                }

                if (assertionTypeName.Equals("AssertEntangled"))
                {
                    return (ToRadians(angles[0]), ToRadians(angles[1]), ToRadians(angles[2]), ToRadians(angles[3]),
                        ToRadians(angles[4]), ToRadians(angles[5]), ToRadians(angles[6]), ToRadians(angles[7]),
                        numberOfTestCases, confidenceLevel,
                        numberOfMeasurements,
                        numberOfExperiments, propertyName, 0.0, (0, 0), 0.0, 0.0);
                }

                if (assertionTypeName.Equals("AssertProbability"))
                {
                    var commaIndex = postCons[0].IndexOf(',');
                    var length = postCons[0].Length - commaIndex - 2;
                    var prob = postCons[0].Substring(commaIndex + 1, length - 1);
                    var proposedProbability = Convert.ToDouble(prob);

                    return (angles[0], angles[1], angles[2], angles[3],
                        0.0, 0.0, 0.0, 0.0,
                        numberOfTestCases, confidenceLevel,
                        numberOfMeasurements,
                        numberOfExperiments, propertyName, proposedProbability, (0, 0), 0.0, 0.0);
                }

                if (assertionTypeName.Equals("AssertTeleported"))
                {
                    return (angles[0], angles[1], angles[2], angles[3],
                        0.0, 0.0, 0.0, 0.0,
                        numberOfTestCases, confidenceLevel,
                        numberOfMeasurements,
                        numberOfExperiments, propertyName, 0.0, (0, 0), 0.0, 0.0);
                }

                if (assertionTypeName.Equals("AssertTransformed"))
                {
                    var begin1 = postCons[0].IndexOf('(', postCons[0].IndexOf('(') + 1);
                    var end1 = postCons[0].IndexOf(')');
                    var destinationThetaRange = postCons[0].Substring(begin1 + 1,
                        end1 - begin1 - 1).Split(',');
                    var begin2 = postCons[0].IndexOf('(', begin1 + 1);
                    var end2 = postCons[0].LastIndexOf(')') - 1;
                    var destinationPhiRange = postCons[0].Substring(begin2 + 1,
                        end2 - begin2 - 1).Split(',');
                    var minOfDestinationTheta = Convert.ToDouble(destinationThetaRange[0]);
                    var maxOfDestinationTheta = Convert.ToDouble(destinationThetaRange[1]);
                    var minOfDestinationPhi = Convert.ToDouble(destinationPhiRange[0]);
                    var maxOfDestinationPhi = Convert.ToDouble(destinationPhiRange[1]);
                    return (angles[0], angles[1], angles[2], angles[3],
                        0.0, 0.0, 0.0, 0.0,
                        numberOfTestCases, confidenceLevel,
                        numberOfMeasurements,
                        numberOfExperiments, propertyName, 0.0, (0, 0), minOfDestinationTheta,
                        maxOfDestinationTheta);
                }

                if (assertionTypeName.Equals("AssertEqual"))
                {
                    return (angles[0], angles[1], angles[2], angles[3],
                        angles[4], angles[5], angles[6], angles[7],
                        numberOfTestCases, confidenceLevel,
                        numberOfMeasurements,
                        numberOfExperiments, propertyName, 0.0, (0, 0), 0.0, 0.0);
                }

                postCons.RemoveAt(0);
            }

            return (0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0, 0, 0, 0, "", 0.0, (0, 0), 0.0, 0.0);
        }

        private static double RandomDoubleNumberGenerator(double min, double max)
        {
            return R.NextDouble() * (max - min) + min;
        }

        private static double ToRadians(double degree)
        {
            return (Math.PI / 180.0) * degree;
        }

        public static double ThetaGenerator(double min = 0.0, double max = 180.0)
        {
            return max == 0.0 ? 0.0 : ToRadians(RandomDoubleNumberGenerator(min, max));
        }

        public static double PhiGenerator(double min = 0.0, double max = 360.0)
        {
            return max == 0.0 ? 0.0 : ToRadians(RandomDoubleNumberGenerator(min, max));
        }

        private static (int b1, int b2) RandomPairGenerator()
        {
            return (R.Next(2), R.Next(2));
        }
    }
}