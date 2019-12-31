// All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Demo {
    class Driver {
        static readonly BiNom bn = new BiNom ();
        static readonly Random random = new Random (DateTime.Now.Millisecond);
        static void Main (string[] args) {

            Driver d = new Driver ();
            d.Trigger ();
        }

        public void Trigger () {

            bool result = true;
            Assembly assembly = Assembly.GetExecutingAssembly ();
            Type[] classes = assembly.GetTypes ();

            foreach (var item in classes) {
                if (item.Name == "Driver") {
                    List<MethodInfo> methodsInfo = new List<MethodInfo> (item.GetMethods ());
                    methodsInfo.RemoveAll (mI => !(mI.Name.StartsWith ("Prop")));
                    foreach (var m in methodsInfo) {

                        result = (bool) (m.Invoke (this, new object[] { }));
                    }
                }
            }
        }

        static bool QSharpCheck (string observedState, double probability, int numberOfTestCases = 3,
            int confidenceLevel = 99, int lowerBound = 300, int upperBound = 350, int trials = 300) {

            int numberOfMeasurement;
            bool[] testResults = new bool[numberOfTestCases];
            double significanceLevel = 100 - confidenceLevel;
            int lowerCriticalVal;
            int upperCriticalVal;
            long zeroNum;
            long oneNum;
            long sum0 = 0;
            long sum1 = 0;
            bool ultimateResult = true;

            using (var qsim = new QuantumSimulator ()) {

                while (numberOfTestCases > 0) {
                    numberOfMeasurement = random.Next (lowerBound, upperBound);
                    lowerCriticalVal = bn.QBinom (significanceLevel / 200.0, numberOfMeasurement, probability, true);
                    upperCriticalVal = bn.QBinom (significanceLevel / 200.0, numberOfMeasurement, probability, false);

                    for (int i = 0; i < trials; ++i) {

                        (zeroNum, oneNum) = Measurement.Run (qsim, numberOfMeasurement).Result;
                        sum0 += zeroNum;
                        sum1 += oneNum;
                    }

                    if (lowerCriticalVal <= (sum0 / trials) &&
                        (sum0 / trials) <= upperCriticalVal) {

                        if (observedState.ToLower ().Equals ("zero"))
                            printAll (observedState, numberOfMeasurement,
                                lowerCriticalVal, upperCriticalVal, true,
                                probability, trials, confidenceLevel, (sum0 / trials));
                        else
                            printAll (observedState, numberOfMeasurement,
                                lowerCriticalVal, upperCriticalVal, true,
                                probability, trials, confidenceLevel, (sum1 / trials));

                        testResults[numberOfTestCases - 1] = true;

                    } else {
                        if (observedState.ToLower ().Equals ("zero"))
                            printAll (observedState, numberOfMeasurement,
                                lowerCriticalVal, upperCriticalVal, false,
                                probability, trials, confidenceLevel, (sum0 / trials));
                        else
                            printAll (observedState, numberOfMeasurement,
                                lowerCriticalVal, upperCriticalVal, false,
                                probability, trials, confidenceLevel, (sum1 / trials));
                        testResults[numberOfTestCases - 1] = false;
                    }
                    numberOfTestCases--;
                    sum0 = 0;
                    sum1 = 0;
                }
            }

            foreach (bool r in testResults) {
                if (!r) {
                    ultimateResult = false;
                    break;
                }
            }

            return ultimateResult;
        }

        static void printAll (string observedState, int numberOfMeasurement, int lowerCriticalVal,
            int upperCriticalVal, bool h0, double probability, int trials, int confidenceLevel, long mean = 1) {

            Console.WriteLine ("╒═════════════════════════════════════════════════════════════════════════════════════════════════════════╕");
            Console.WriteLine ($"\n It is proposed that:");
            if (observedState.ToLower ().Equals ("zero"))
                Console.WriteLine ($"   After measurement the probability of observing \"Zero state\" is {probability}");
            else { Console.WriteLine ($"   After measurement the probability of observing \"One state\" is {probability}"); }
            Console.WriteLine ($"\n In each {numberOfMeasurement} measurements:");
            Console.WriteLine ($"   Significance level:\t\t\t{100-confidenceLevel}%");
            Console.WriteLine ($"   Confidence level:\t\t\t{confidenceLevel}%");
            Console.WriteLine ($"   Probability:\t\t\t\t{probability}");
            Console.WriteLine ($"   Lower critical value:\t\t{lowerCriticalVal}");
            Console.WriteLine ($"   Upper critical value:\t\t{upperCriticalVal}");
            Console.WriteLine ("\n Test conclusion:");
            Console.WriteLine ($"   After {trials} trials of {numberOfMeasurement} qubit-measurements:");

            if (h0) {
                if (observedState.ToLower ().Equals ("zero")) {
                    Console.WriteLine ($"   The mean number of Zero state was {mean} which is inside the critical region.");
                } else {
                    Console.WriteLine ($"   The mean number of One state was {mean} which is inside the critical region.");
                }
                Console.WriteLine ("");
                Console.WriteLine ($"   This property is FAILED TO REJECT.");
            } else {

                if (observedState.ToLower ().Equals ("zero")) {
                    Console.WriteLine ($"   The mean number of Zero state was {mean} which is out of the critical region.");
                    Console.WriteLine ($"   The probability of observing Zero state is approximately {Math.Round((double)mean/(double)numberOfMeasurement,3)}");
                } else {
                    Console.WriteLine ($"   The mean number of One state was {mean} which is out of the critical region.");
                    Console.WriteLine ($"   The probability of observing One state is approximately {Math.Round((double)mean/(double)numberOfMeasurement,3)}");
                }

                Console.WriteLine ("");
                Console.WriteLine ($"   This property is REJECTED.");
            }

            Console.WriteLine ("\n╘═════════════════════════════════════════════════════════════════════════════════════════════════════════╛\n");
        }

        // Temporarily, in the demo version the properties are written here in the same class
    }
}