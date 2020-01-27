// All rights reserved.
// Licensed under the MIT license.

using System;
using System.IO;
using System.Reflection;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace QSharpCheck {
    public static class TestExecutionEngine {
        static void Main (string[] args) {
            Assembly assembly = Assembly.GetExecutingAssembly ();
            string assemblyName = assembly.FullName.Remove (assembly.FullName.IndexOf (",", StringComparison.Ordinal));
            double theta;
            double phi;
            string sutName;
            string assertionTypeName;
            int numberOfTestCases;
            int confidenceLevel;
            int numberOfMeasurements;
            long numberOfExperiments;
            string propertyName;
            bool flag = true;
            long zeroNum;
            long sum = 0;
            TestCaseGenerator testCaseGenerator = new TestCaseGenerator ();
            StatisticalAnalyticsEngine sae = new StatisticalAnalyticsEngine ();
            (theta, phi, sutName, assertionTypeName, numberOfTestCases, confidenceLevel, numberOfMeasurements,
                numberOfExperiments, propertyName) =
            testCaseGenerator.FileReader (Path.GetFullPath("test.txt"));

            using (var qsim = new QuantumSimulator ()) {

                for (int i = 0; i <= numberOfTestCases && flag; i++) {
                    if (i == 0) {
                        zeroNum = Measurement.Run (qsim, numberOfMeasurements, theta, phi).Result;
                        continue;
                    }
                    for (int j = 0; j < numberOfExperiments; ++j) {
                        zeroNum = Measurement.Run (qsim, numberOfMeasurements, theta, phi).Result;
                        sum += zeroNum;
                    }

                    flag = sae.Analyse (theta, phi, sum / numberOfExperiments, numberOfTestCases,
                        numberOfExperiments,
                        confidenceLevel,
                        numberOfMeasurements, propertyName, i);
                    sum = 0;
                    numberOfTestCases--;
                }
            }

        }
    }
}