// All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;

namespace Demo {

    public class BiNom {

        private static Dictionary<int, double> lessThanEqual20 = new Dictionary<int, double> ();

        public BiNom () {
            long p = 1;
            lessThanEqual20.Add (0, 0);

            for (int i = 1; i <= 20; ++i)
                lessThanEqual20.Add (i, Math.Log (p *= i));
        }

        // Since n! = 1 × 2 × 3 × … × n, log(n!) = log(1) + log(2) + log(3) + … + log(n).
        // However it’s slow for large arguments as the run time is commensurate to the size of n.
        // We exploit log(n!) for n up to 20 and then use Stirling approximation to calculate log(n!) for larger numbers.
        private static double LogOfFac (int num) {

            // This is used when the number is not larger than 20
            if (lessThanEqual20.TryGetValue (num, out double output))
                return output;

            return Math.Log (2 * Math.PI * num) / 2 +
                num * Math.Log (num) - num +
                Math.Log (1 + 1 / 12.0 / num);
        }

        // Calculates the probability of getting k Zero states in an n measurements
        public double DBinom (int k, int n, double p) {

            if (p < 0 || p > 1)
                throw new ArgumentOutOfRangeException (nameof (p));

            else if (p == 0 || p == 1.0)
                return 0.0;

            if (k < 0 || n < 0 || k > n)
                return 0.0;

            double result = LogOfFac (n) - LogOfFac (k) - LogOfFac (n - k) +
                k * Math.Log (p) + (n - k) * Math.Log (1 - p);

            return Math.Exp (result);
        }

        // Calculates the probability of getting k or fewer
        // Zero states in a sample of size n with a p as the probability 
        // of observing Zero state after each single measurement
        public double PBinom (int k, int n, double p)  {
            if (p < 0 || p > 1)
                throw new ArgumentOutOfRangeException (nameof (p));

            else if (p == 0 || p == 1.0)
                return 0.0;

            if (k < 0 || n < 0 || k > n)
                return 0.0;

            double pValue = 0.0;
            int tempK = 0;
            while (tempK <= k) {
                pValue += DBinom (tempK, n, p);
                tempK++;
            }

            return pValue;
        }

        // The boolean 'lowerTail' is to help whether
        // to do the one-tailed test or the two-tailed
        public int QBinom (double significanceLevel, int n, double p, bool lowerTail) {

            int criticalVal = 0;
            double dBinomResult = 0;
            if (lowerTail) {
                while (true) {

                    dBinomResult += DBinom (criticalVal, n, p);
                    if (dBinomResult >= significanceLevel) break;
                    criticalVal++;
                }
                // Lower bound critical value
                return criticalVal;

            } else {
                while (true) {

                    dBinomResult += DBinom (criticalVal, n, p);
                    if (dBinomResult >= (1.0 - significanceLevel)) break;
                    criticalVal++;
                }
                // Upper bound critical value
                return criticalVal;
            }
        }
    }
}