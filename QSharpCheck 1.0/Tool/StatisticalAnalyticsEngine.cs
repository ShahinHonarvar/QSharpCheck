using System;

namespace QSharpCheck
{
    public class StatisticalAnalyticsEngine
    {
        static readonly BiNom bn = new BiNom();

        public bool Analyse(double theta, double phi, long mean, int numberOfTestCases, long numOfExperiments,
            int confidenceLevel,
            int numberOfMeasurements, string propertyName, int i)
        {
            double significanceLevel = 100.0 - confidenceLevel;
            double probability = Math.Pow(Math.Cos(theta / 2.0), 2);
            int lowerCriticalVal = bn.QBinom(significanceLevel / 200.0, (int) numberOfMeasurements, probability, true);
            int upperCriticalVal = bn.QBinom(significanceLevel / 200.0, (int) numberOfMeasurements, probability, false);
            if (lowerCriticalVal <= mean && mean <= upperCriticalVal)
            {
                printAll_AssertTeleported(theta, phi, numberOfTestCases, numOfExperiments, numberOfMeasurements,
                    confidenceLevel, propertyName, true, i);
                return true;
            }
            else
            {
                printAll_AssertTeleported(theta, phi, numberOfTestCases, numOfExperiments, numberOfMeasurements,
                    confidenceLevel, propertyName, false, i);
                return false;
            }
        }

        static void printAll_AssertTeleported(double theta, double phi, long numberOfTestCases,
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
    }
}