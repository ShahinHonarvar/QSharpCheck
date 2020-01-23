// All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace TeleportationValidate {
    class Driver {
        static readonly BiNom bn = new BiNom ();
        static readonly Random random = new Random (DateTime.Now.Millisecond);
        static void Main (string[] args) {
            Stopwatch stopwatch = Stopwatch.StartNew ();

            Driver d = new Driver ();
            d.Trigger ();
            stopwatch.Stop ();
            Console.WriteLine ($"The whole execution time in milliseconds: {stopwatch.ElapsedMilliseconds}");
        }

        void Trigger () {

            AssertTelepoprted ();
        }

        static double RandomDoubleNumberGenerator (double min, double max) {

            return random.NextDouble () * (max - min) + min;
        }

        static double ToRadians (double angle) {

            return (Math.PI / 180) * angle;
        }

        static void AssertTelepoprted (int numberOfTestCases = 10, int confidenceLevel = 99, int numberOfMeasurement = 350, int trials = 300) {

            double significanceLevel = 100 - confidenceLevel;
            long lowerCriticalVal;
            long upperCriticalVal;
            double theta;
            double phi;
            double probability;
            long zeroNum;
            long sum_q = 0;
            bool flag = true;

            using (var qsim = new QuantumSimulator ()) {
                while (numberOfTestCases > 0 && flag) {

                    theta = ToRadians (RandomDoubleNumberGenerator (0.0, 180.0));
                    phi = ToRadians (RandomDoubleNumberGenerator (0.0, 360.0));
                    probability = Math.Pow (Math.Cos (theta / 2.0), 2);

                    for (int j = 0; j < trials; ++j) {

                        zeroNum = Measurement.Run (qsim, numberOfMeasurement, theta, phi).Result;
                        sum_q += zeroNum;
                    }

                    lowerCriticalVal = bn.QBinom (significanceLevel / 200.0, (int) numberOfMeasurement, probability, true);
                    upperCriticalVal = bn.QBinom (significanceLevel / 200.0, (int) numberOfMeasurement, probability, false);

                    if (lowerCriticalVal <= (sum_q / trials) && (sum_q / trials) <= upperCriticalVal) {

                        printAll_AssertTeleported (numberOfMeasurement, probability,
                            lowerCriticalVal, upperCriticalVal, true, trials, confidenceLevel, (sum_q / trials));

                    } else {

                        printAll_AssertTeleported (numberOfMeasurement, probability,
                            lowerCriticalVal, upperCriticalVal, false, trials, confidenceLevel, (sum_q / trials));
                        flag = false;
                    }
                    sum_q = 0;
                    numberOfTestCases--;
                }
            }
        }

        static void printAll_AssertTeleported (
            long numberOfMeasurement, double prob, long lowerCriticalVal,
            long upperCriticalVal, bool h0, long trials, long confidenceLevel, long mean) {

            Console.WriteLine ("╒═════════════════════════════════════════════════════════════════════════════════════════════════════════╕");

            Console.WriteLine ($"\n It is proposed that:");
            Console.WriteLine ($"   After measurement the probability of observing \"Zero state\" is {prob}");
            Console.WriteLine ($"\n In each {numberOfMeasurement} measurements:");
            Console.WriteLine ($"   Significance level:\t\t\t{100-confidenceLevel}%");
            Console.WriteLine ($"   Confidence level:\t\t\t{confidenceLevel}%");
            Console.WriteLine ($"   Probability:\t\t\t\t{prob}");
            Console.WriteLine ($"   Lower critical value:\t\t{lowerCriticalVal}");
            Console.WriteLine ($"   Upper critical value:\t\t{upperCriticalVal}");
            Console.WriteLine ("\n  Test conclusion:");
            Console.WriteLine ($"   After {trials} trials of {numberOfMeasurement} qubit-measurements:");

            if (h0) {
                Console.WriteLine ($"   The mean number of observed Zero states was {mean} which is inside the critical region.");
                Console.WriteLine ("");
                Console.WriteLine ($"   The proposed property is FAILED TO REJECT.");
            } else {
                Console.WriteLine ($"   The mean number of observed Zero states was {mean} which is out of the critical region.");
                Console.WriteLine ($"   The correct probability of observing the qubit in Zero state after measurement, is approximately {Math.Round((double)mean/(double)numberOfMeasurement,3)}");
                Console.WriteLine ("");
                Console.WriteLine ($"   The proposed property is REJECTED.");
            }

            Console.WriteLine ("\n╘═════════════════════════════════════════════════════════════════════════════════════════════════════════╛\n");
        }
    }
}