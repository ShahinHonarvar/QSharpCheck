// All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace QSharpCheck
{
    public class TestCaseGenerator
    {
        private static readonly Random random = new Random(DateTime.Now.Millisecond);

        public (double theta, double phi, string sutName, string assertName, int testCasesNo, int confidence, int
            measurements, int experiments, string propertyName, (int b1, int b2)) FileReader(string pathT)
        {
            List<string> lines = new List<string>();
            try
            {
                lines = File.ReadAllLines(pathT).ToList();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File was not found: {e}");
            }

            lines.RemoveAll(string.IsNullOrWhiteSpace);

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].Replace(" ", "");
                lines[i] = lines[i].Replace(";", "");
            }

            List<int> testConditions = new List<int>();
            string propertyName = lines[0];
            int numberOfTestCases;
            int confidenceLevel = 0;
            int numberOfMeasurements = 0;
            int numberOfExperiments = 0;
            double minOfTheta = 0.0;
            double maxOfTheta = 0.0;
            double minOfPhi = 0.0;
            double maxOfPhi = 0.0;
            double minOfDestinationTheta = 0.0;
            double maxOfDestinationTheta = 0.0;
            double minOfDestinationPhi = 0.0;
            double maxOfDestinationPhi = 0.0;

            if (lines[1].StartsWith("("))
            {
                lines[1] = lines[1].Replace("(", "");
                lines[1] = lines[1].Replace(")", "");
                string[] userArgs = lines[1].Split(",");
                foreach (var element in userArgs)
                {
                    testConditions.Add(Convert.ToInt32(element));
                }
            }

            if (testConditions.Count != 0)
            {
                if (testConditions.Count == 1)
                    numberOfTestCases = testConditions[0];
                else
                {
                    numberOfTestCases = testConditions[0];
                    confidenceLevel = testConditions[1];
                    numberOfMeasurements = testConditions[2];
                    numberOfExperiments = testConditions[3];
                }
            }
            else
            {
                numberOfTestCases = 10;
                confidenceLevel = 99;
                numberOfMeasurements = 350;
                numberOfExperiments = 300;
            }

            foreach (string line in lines)
            {
                if (line.StartsWith("{") && line.Contains("Qubit"))
                {
                    int begin0 = line.IndexOf("(", StringComparison.Ordinal);
                    int end0 = line.IndexOf(")", StringComparison.Ordinal);
                    if (line.Length - line.Replace("(", "").Length == 1)
                    {
                        string[] thetaRange = line.Substring(begin0 + 1,
                            end0 - begin0 - 1).Split(",");
                        minOfTheta = Convert.ToInt32(thetaRange[0]);
                        maxOfTheta = Convert.ToInt32(thetaRange[1]);
                    }
                    else
                    {
                        int begin1 = line.LastIndexOf("(", StringComparison.Ordinal);
                        int end1 = line.LastIndexOf(")", StringComparison.Ordinal);
                        string[] thetaRange = line.Substring(begin0 + 1,
                            end0 - begin0 - 1).Split(",");
                        minOfTheta = Convert.ToDouble(thetaRange[0]);
                        maxOfTheta = Convert.ToDouble(thetaRange[1]);
                        string[] phiRange = line.Substring(begin1 + 1,
                            end1 - begin1 - 1).Split(",");
                        minOfPhi = Convert.ToDouble(phiRange[0]);
                        maxOfPhi = Convert.ToDouble(phiRange[1]);
                    }
                }
            }

            string sutName = lines[3];
            sutName = sutName.Remove(sutName.IndexOf("(", StringComparison.Ordinal));
            string assertionTypeName = "";
            foreach (string line in lines)
            {
                if (line.StartsWith("["))
                {
                    int end0 = line.IndexOf("(", StringComparison.Ordinal);
                    assertionTypeName = line.Substring(1, end0 - 1);
                    if (assertionTypeName.Equals("AssertTeleported"))
                    {
                        int begin1 = line.IndexOf('(', line.IndexOf('(') + 1);
                        int end1 = line.IndexOf(")", StringComparison.Ordinal);
                        string[] destinationThetaRange = line.Substring(begin1 + 1,
                            end1 - begin1 - 1).Split(",");
                        int begin2 = line.IndexOf('(', begin1 + 1);
                        int end2 = line.LastIndexOf(")", StringComparison.Ordinal) - 1;
                        string[] destinationPhiRange = line.Substring(begin2 + 1,
                            end2 - begin2 - 1).Split(",");
                        minOfDestinationTheta = Convert.ToDouble(destinationThetaRange[0]);
                        maxOfDestinationTheta = Convert.ToDouble(destinationThetaRange[1]);
                        minOfDestinationPhi = Convert.ToDouble(destinationPhiRange[0]);
                        maxOfDestinationPhi = Convert.ToDouble(destinationPhiRange[1]);
                    }
                }
            }

            return (ThetaGenerator(minOfTheta, maxOfTheta), PhiGenerator(minOfPhi, maxOfPhi), sutName,
                assertionTypeName, numberOfTestCases, confidenceLevel, numberOfMeasurements, numberOfExperiments,
                propertyName, RandomPairGenerator());
        }

        static string GetAssemblyName()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.FullName.Remove(assembly.FullName.IndexOf(",", StringComparison.Ordinal));
        }

        static double RandomDoubleNumberGenerator(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        static double ToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        static double ThetaGenerator(double min = 0.0, double max = 180.0)
        {
            return ToRadians(RandomDoubleNumberGenerator(min, max));
        }

        static double PhiGenerator(double min = 0.0, double max = 360.0)
        {
            return ToRadians(RandomDoubleNumberGenerator(min, max));
        }

        static (int b1, int b2) RandomPairGenerator()
        {
            int b1 = random.Next(2);
            int b2 = random.Next(2);

            return (b1, b2);
        }
    }
}