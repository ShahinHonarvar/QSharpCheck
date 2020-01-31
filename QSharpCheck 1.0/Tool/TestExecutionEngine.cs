// All rights reserved.
// Licensed under the MIT license.

using System;
using System.IO;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using Microsoft.Quantum.Intrinsic;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;


namespace QSharpCheck
{
    public static class TestExecutionEngine
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string assemblyName = assembly.FullName.Remove(assembly.FullName.IndexOf(",", StringComparison.Ordinal));
            double theta;
            double phi;
            string sutName;
            string assertionTypeName;
            int numberOfTestCases;
            int confidenceLevel;
            int numberOfMeasurements;
            long numberOfExperiments;
            string propertyName;
            long zeroNum;
            long sum = 0;
            int b1;
            int b2;
            long result1;
            long result2;
            TestCaseGenerator testCaseGenerator = new TestCaseGenerator();
            StatisticalAnalyticsEngine sae = new StatisticalAnalyticsEngine();
            (theta, phi, sutName, assertionTypeName, numberOfTestCases, confidenceLevel, numberOfMeasurements,
                    numberOfExperiments, propertyName, (b1, b2)) =
                testCaseGenerator.FileReader(Path.Combine (Environment.CurrentDirectory, "test.txt"));

            using (var qsim = new QuantumSimulator())
            {
                if (assertionTypeName.Equals("AssertTeleported"))
                {
                    bool flag = true;
                    int testCaseCounter = 0;
                    int i = numberOfTestCases;
                    while (i > 0 && flag)
                    {
                        for (int j = 0; j < numberOfExperiments; ++j)
                        {
                            zeroNum = Measurement.Run(qsim, numberOfMeasurements, theta, phi).Result;
                            sum += zeroNum;
                        }

                        flag = sae.AnalyseMeasurementResult(theta, phi, sum / numberOfExperiments, numberOfTestCases,
                            numberOfExperiments,
                            confidenceLevel,
                            numberOfMeasurements, propertyName, i);
                        sum = 0;
                        testCaseCounter++;
                        i--;
                    }

                    sae.printAll_AssertTeleported(theta, phi, numberOfTestCases, numberOfExperiments,
                        numberOfMeasurements,
                        confidenceLevel, propertyName, flag, i);
                }
                else if (assertionTypeName.Equals("AssertEqualClassicalBits"))
                {
                    bool flag = true;
                    int testCaseCounter = 0;
                    int i = numberOfTestCases;

                    while (i > 0 && flag)
                    {
                        (result1, result2) = Start.Run(qsim, b1, b2).Result;

                        flag = sae.EqualityComparison(b1, b2, (int) result1, (int) result2);
                        testCaseCounter++;
                        i--;
                    }

                    sae.printAll_AssertEqualClassicalBits(numberOfTestCases, propertyName, flag, testCaseCounter, b1,
                        b2);
                }
            }
        }
    }
}