using System;
using System.Collections.Generic;
using System.Linq;

namespace QSharpCheck
{
    public static class StatisticalAnalyticsEngine
    {
        private static readonly BiNom Bn = new BiNom();

        public static bool AnalyseMeasurementResultOfTeleportation(double theta,
            long mean,
            double significanceLevel,
            int numberOfMeasurements)
        {
            var probability = Math.Pow(Math.Cos(theta / 2.0), 2);
            var lowerCriticalVal = Bn.QBinom(significanceLevel / 200.0, numberOfMeasurements, probability, true);
            var upperCriticalVal = Bn.QBinom(significanceLevel / 200.0, numberOfMeasurements, probability, false);

            return lowerCriticalVal <= mean && mean <= upperCriticalVal;
        }

        public static (bool result, int lowCritical, int upperCritical, long mean)
            AnalyseMeasurementResultOfProbability(double proposedProbability, long mean, double significanceLevel,
                int numberOfMeasurements)
        {
            var lowerCriticalVal =
                Bn.QBinom(significanceLevel / 200.0, numberOfMeasurements, proposedProbability, true);
            var upperCriticalVal =
                Bn.QBinom(significanceLevel / 200.0, numberOfMeasurements, proposedProbability, false);

            return (lowerCriticalVal <= mean && mean <= upperCriticalVal, lowerCriticalVal, upperCriticalVal, mean);
        }

        public static bool AnalyseMeasurementResultOfTransformation(long mean, double significanceLevel,
            int numberOfMeasurements, double minOfDestinationTheta, double maxOfDestinationTheta)
        {
            var p1 = Math.Pow(Math.Cos(minOfDestinationTheta), 2);
            var p2 = Math.Pow(Math.Cos(maxOfDestinationTheta), 2);
            var criticalVal1 = Bn.QBinom(significanceLevel / 200.0, numberOfMeasurements, p1, true);
            var criticalVal2 =
                Bn.QBinom(significanceLevel / 200.0, numberOfMeasurements, p2, false);

            return criticalVal2 <= mean && mean <= criticalVal1;
        }

        public static bool AnalyseMeasurementResultOfEntanglement(long meanQ1StateZero, long meanQ2StateZero,
            double significanceLevel,
            int numberOfMeasurements)
        {
            var table = new Dictionary<double, double>
            {
                {0.995, 0.0000397},
                {0.99, 0.000157},
                {0.975, 0.000982},
                {0.95, 0.00393},
                {0.9, 0.0158},
                {0.5, 0.455},
                {0.2, 1.642},
                {0.1, 2.706},
                {0.05, 3.841},
                {0.025, 5.024},
                {0.02, 5.412},
                {0.01, 6.635},
                {0.005, 7.879},
                {0.002, 9.550},
                {0.001, 10.828}
            };

            var meanQ1StateOne = numberOfMeasurements - meanQ1StateZero;
            var meanQ2StateOne = numberOfMeasurements - meanQ2StateZero;
            var column1Total = meanQ1StateZero + meanQ2StateZero;
            var column2Total = meanQ1StateOne + meanQ2StateOne;
            var e1 = column1Total / numberOfMeasurements;
            var e2 = column2Total / numberOfMeasurements;
            var chiSquareResult = (Math.Pow(meanQ1StateZero - e1, 2) / e1) + (Math.Pow(meanQ1StateOne - e2, 2) / e2) +
                                  (Math.Pow(meanQ2StateZero - e1, 2) / e1) + (Math.Pow(meanQ2StateOne - e2, 2) / e2);

            // If true then reject H0
            return chiSquareResult >= table[significanceLevel / 100.0];
        }

        public static bool AnalyseMeasurementResultOfEquality(List<long> measurementListQ1,
            List<long> measurementListQ2, double significanceLevel)
        {
            var table = new Dictionary<double, double>
            {
                {1.0, 0.0},
                {0.8, 0.253},
                {0.5, 0.674},
                {0.4, 0842},
                {0.3, 1.036},
                {0.2, 1.282},
                {0.1, 1.645},
                {0.05, 1.960},
                {0.02, 2.326},
                {0.01, 2.576},
                {0.005, 2.807},
                {0.002, 3.090},
                {0.001, 3.291}
            };

            var sum1 = measurementListQ1.Sum();
            var sum2 = measurementListQ2.Sum();
            var mean1 = measurementListQ1.Count == 0 ? 0 : sum1 / measurementListQ1.Count;
            var mean2 = measurementListQ2.Count == 0 ? 0 : sum2 / measurementListQ2.Count;
            var sum1Squared = Math.Pow(sum1, 2);
            var sum2Squared = Math.Pow(sum2, 2);
            var df = measurementListQ1.Count + measurementListQ2.Count - 2;
            var sumOfEachElementSquared1 = measurementListQ1.Sum(t1 => Math.Pow(t1, 2));
            var sumOfEachElementSquared2 = measurementListQ2.Sum(t1 => Math.Pow(t1, 2));
            var result1 = sum1Squared / measurementListQ1.Count;
            var result2 = sum2Squared / measurementListQ2.Count;
            var reverse1 = 1.0 / measurementListQ1.Count;
            var reverse2 = 1.0 / measurementListQ2.Count;
            var sqr = Math.Sqrt((((sumOfEachElementSquared1 - result1) +
                                  (sumOfEachElementSquared2 - result2)) / df) * (reverse1 + reverse2));
            var calculateT = sqr == 0.0 ? 0 : (mean1 - mean2) / sqr;

            // If false then reject H0 where H0 claims the qubits have the same state
            return calculateT <= table[significanceLevel / 100.0];
        }

        public static bool EqualityComparison(int b1, int b2, int r1, int r2)
        {
            return r1 == b1 && r2 == b2;
        }

        private static double ToDegree(double radian)
        {
            return radian * 180.0 / Math.PI;
        }

        public static void printAll_AssertEntangled(double theta, double phi, double theta2, double phi2,
            long numberOfTestCases,
            long numOfExperiments, long numberOfMeasurements, int confidenceLevel, string propertyName, bool h0, int i)
        {
            Console.WriteLine(
                "╒═══════════════════════════════════════════════════════╕");

            Console.WriteLine($"\n  Testing \"{propertyName}\"");
            Console.WriteLine("");
            Console.WriteLine($"  Number of test cases:\t\t{numberOfTestCases}");
            Console.WriteLine($"  Confidence level:\t\t{confidenceLevel}");
            Console.WriteLine($"  Number of measurements:       {numberOfMeasurements}");
            Console.WriteLine($"  Number of experiments:\t{numOfExperiments}");
            Console.WriteLine("");
            if (h0)
            {
                Console.WriteLine("  AssertEntangled was true in all test cases.");
                Console.WriteLine($"  Passed {numberOfTestCases} tests.");
            }
            else
            {
                Console.WriteLine($"  After {i} test,");
                Console.WriteLine("  AssertEntangled was falsified when:");
                Console.WriteLine($"  θ1 = {ToDegree(theta)} and φ1 = {ToDegree(phi)} and");
                Console.WriteLine($"  θ2 = {ToDegree(theta2)} and φ2 = {ToDegree(phi2)}");
            }

            Console.WriteLine(
                "\n╘═══════════════════════════════════════════════════════╛\n");
        }

        public static void printAll_AssertTeleported(double theta, double phi, long numberOfTestCases,
            long numOfExperiments, long numberOfMeasurements, int confidenceLevel, string propertyName, bool h0, int i)
        {
            Console.WriteLine(
                "╒═══════════════════════════════════════════════════════╕");

            Console.WriteLine($"\n  Testing \"{propertyName}\"");
            Console.WriteLine("");
            Console.WriteLine($"  Number of test cases:\t\t{numberOfTestCases}");
            Console.WriteLine($"  Confidence level:\t\t{confidenceLevel}");
            Console.WriteLine($"  Number of measurements:       {numberOfMeasurements}");
            Console.WriteLine($"  Number of experiments:\t{numOfExperiments}");
            Console.WriteLine("");
            if (h0)
            {
                Console.WriteLine("  AssertTeleported was true in all test cases.");
                Console.WriteLine($"  Passed {numberOfTestCases} tests.");
            }
            else
            {
                Console.WriteLine($"  After {i} test,");
                Console.WriteLine("  AssertTeleported was falsified when:");
                Console.WriteLine($"  θ = {ToDegree(theta)} and φ = {ToDegree(phi)}");
            }

            Console.WriteLine(
                "\n╘═══════════════════════════════════════════════════════╛\n");
        }

        public static void printAll_AssertEqualClassicalBits(int numberOfTestCases, string propertyName, bool h0, int i,
            int b1, int b2)
        {
            Console.WriteLine(
                "╒═══════════════════════════════════════════════════════╕");

            Console.WriteLine($"\n  Testing \"{propertyName}\"");
            Console.WriteLine("");
            Console.WriteLine($"  Number of test cases:\t\t{numberOfTestCases}");
            Console.WriteLine("");
            if (h0)
            {
                Console.WriteLine("  AssertEqualClassicalBits was true in all test cases.");
                Console.WriteLine($"  Passed {numberOfTestCases} tests.");
            }
            else
            {
                Console.WriteLine($"  After {i} test,");
                Console.WriteLine("  AssertEqualClassicalBits was falsified when:");
                Console.WriteLine($"  {b1} and {b2} were the inputs.");
            }

            Console.WriteLine(
                "\n╘═══════════════════════════════════════════════════════╛\n");
        }

        public static void printAll_AssertProbibility(int lowCritical, int upperCritical, long mean,
            long numberOfTestCases,
            long numOfExperiments, long numberOfMeasurements, int confidenceLevel, string propertyName, bool h0, int i,
            double theta, double phi)
        {
            Console.WriteLine(
                "╒═════════════════════════════════════════════════════════════════╕");

            Console.WriteLine($"\n  Testing \"{propertyName}\"");
            Console.WriteLine("");
            Console.WriteLine($"  Number of test cases:\t\t{numberOfTestCases}");
            Console.WriteLine($"  Confidence level:\t\t{confidenceLevel}");
            Console.WriteLine($"  Number of measurements:       {numberOfMeasurements}");
            Console.WriteLine($"  Number of experiments:\t{numOfExperiments}");
            Console.WriteLine("");
            if (h0)
            {
                Console.WriteLine("  AssertProbability was true in all test cases.");
                Console.WriteLine($"  Passed {numberOfTestCases} tests.");
            }
            else
            {
                Console.WriteLine($"  After {i} test,");
                Console.WriteLine("  AssertTeleported was falsified when:");
                Console.WriteLine($"  θ = {theta} and φ = {phi}");
                Console.WriteLine("  and based on the proposed probability,");
                Console.WriteLine($"  The lower critical value was {lowCritical}");
                Console.WriteLine($"  The upper critical value was {upperCritical}");
                Console.WriteLine($"  The mean number of observed zero after measurement was: {mean}");
            }

            Console.WriteLine(
                "\n╘═════════════════════════════════════════════════════════════════╛\n");
        }

        public static void printAll_AssertEqual(double theta1, double phi1, double theta2, double phi2, long numberOfTestCases,
            long numOfExperiments, long numberOfMeasurements, int confidenceLevel, string propertyName, bool h0, int i)
        {
            Console.WriteLine(
                "╒═══════════════════════════════════════════════════════════════════════════╕");

            Console.WriteLine($"\n  Testing \"{propertyName}\"");
            Console.WriteLine("");
            Console.WriteLine($"  Number of test cases:\t\t{numberOfTestCases}");
            Console.WriteLine($"  Confidence level:\t\t{confidenceLevel}");
            Console.WriteLine($"  Number of measurements:       {numberOfMeasurements}");
            Console.WriteLine($"  Number of experiments:\t{numOfExperiments}");
            Console.WriteLine("");
            if (h0)
            {
                Console.WriteLine("  AssertEqual was true in all test cases.");
                Console.WriteLine($"  Passed {numberOfTestCases} tests.");
            }
            else
            {
                Console.WriteLine($"  After {i} test,");
                Console.WriteLine("  AssertEqual was falsified when:");
                Console.WriteLine($"  θ1 = {ToDegree(theta1)} and φ1 = {ToDegree(phi1)}");
                Console.WriteLine($"  θ2 = {ToDegree(theta2)} and φ2 = {ToDegree(phi2)}");
            }

            Console.WriteLine(
                "\n╘═══════════════════════════════════════════════════════════════════════════╛\n");
        }

        public static void printAll_AssertTransformation(double theta, double phi, long numberOfTestCases,
            long numOfExperiments, long numberOfMeasurements, int confidenceLevel, string propertyName, bool h0, int i)
        {
            Console.WriteLine(
                "╒═══════════════════════════════════════════════════════╕");

            Console.WriteLine($"\n  Testing \"{propertyName}\"");
            Console.WriteLine("");
            Console.WriteLine($"  Number of test cases:\t\t{numberOfTestCases}");
            Console.WriteLine($"  Confidence level:\t\t{confidenceLevel}");
            Console.WriteLine($"  Number of measurements:       {numberOfMeasurements}");
            Console.WriteLine($"  Number of experiments:\t{numOfExperiments}");
            Console.WriteLine("");
            if (h0)
            {
                Console.WriteLine("  AssertTransformation was true in all test cases.");
                Console.WriteLine($"  Passed {numberOfTestCases} tests.");
            }
            else
            {
                Console.WriteLine($"  After {i} test,");
                Console.WriteLine("  AssertTeleported was falsified when:");
                Console.WriteLine($"  θ = {ToDegree(theta)} and φ = {ToDegree(phi)}");
            }

            Console.WriteLine(
                "\n╘═══════════════════════════════════════════════════════╛\n");
        }
    }
}