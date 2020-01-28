using System;

namespace QSharpCheck
{
    public class StatisticalAnalyticsEngine
    {
        static readonly BiNom Bn = new BiNom();

        public bool AnalyseMeasurementResult(double theta, double phi, long mean, int numberOfTestCases,
            long numOfExperiments,
            int confidenceLevel,
            int numberOfMeasurements, string propertyName, int i)
        {
            double significanceLevel = 100.0 - confidenceLevel;
            double probability = Math.Pow(Math.Cos(theta / 2.0), 2);
            int lowerCriticalVal = Bn.QBinom(significanceLevel / 200.0, numberOfMeasurements, probability, true);
            int upperCriticalVal = Bn.QBinom(significanceLevel / 200.0, numberOfMeasurements, probability, false);
            
            return lowerCriticalVal <= mean && mean <= upperCriticalVal;
        }

        public bool EqualityComparison(int b1, int b2, int r1, int r2)
        {
            return r1 == b1 && r2 == b2;
        }

        public void printAll_AssertTeleported(double theta, double phi, long numberOfTestCases,
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
                Console.WriteLine("  AssertTeleported was true in all test cases.");
                Console.WriteLine($"  Passed {numberOfTestCases} tests.");
            }
            else
            {
                Console.WriteLine($"  After {i} test,");
                Console.WriteLine("  AssertTeleported was falsified when:");
                Console.WriteLine($"  θ = {theta} and φ = {phi}");
            }

            Console.WriteLine(
                "\n╘═══════════════════════════════════════════════════════════════════════════╛\n");
        }

        public void printAll_AssertEqualClassicalBits(int numberOfTestCases, string propertyName, bool h0, int i,
            int b1, int b2)
        {
            Console.WriteLine(
                "╒═══════════════════════════════════════════════════════════════════════════╕");

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
                "\n╘═══════════════════════════════════════════════════════════════════════════╛\n");
        }
    }
}