// All rights reserved.
// Licensed under the MIT license.

using System;
using System.Collections.Generic;

namespace QSharpCheck
{
    public class BiNom
    {
        private static readonly Dictionary<int, double> LessThanEqual20 = new Dictionary<int, double>();

        public BiNom()
        {
            long p = 1;
            LessThanEqual20.Add(0, 0);

            for (var i = 1; i <= 20; ++i)
                LessThanEqual20.Add(i, Math.Log(p *= i));
        }

        // It’s usually more convenient to work with the logarithms of factorials
        // rather than factorials themselves. Since n! = 1 × 2 × 3 × … × n, log(n!) = log(1) + log(2) + log(3) + … + log(n).
        // That gives a way to compute log(n!), but it’s slow for large arguments: the run time is proportional to the size of n.
        // we tabulate log(n!) for n up to some size and then use a formula to calculate log(n!) for larger arguments that 
        // is Stirling approximation.
        private static double LogOfFac(int num)
        {
            // This is used when the number is not larger than 20
            if (LessThanEqual20.TryGetValue(num, out double result))
                return result;

            return Math.Log(2 * Math.PI * num) / 2 +
                   num * Math.Log(num) - num +
                   Math.Log(1 + 1 / 12.0 / num);
        }

        private double DBinom(int k, int n, double p)
        {
            if (p < 0.0 || p > 1.0)
                throw new ArgumentOutOfRangeException(nameof(p));

            if (p == 0.0 || p == 1.0)
                return 0.0;

            if (k < 0 || n < 0 || k > n)
                return 0.0;

            double result = LogOfFac(n) - LogOfFac(k) - LogOfFac(n - k) +
                            k * Math.Log(p) + (n - k) * Math.Log(1 - p);

            return Math.Exp(result);
        }

        // The boolean 'lowerTail' is to help whether
        // to do the one-tailed test or the two-tailed test
        public int QBinom(double significanceLevel, int n, double p, bool lowerTail)
        {
            var criticalVal = 0;
            double dBinomResult = 0;
            if (lowerTail)
            {
                while (true)
                {
                    dBinomResult += DBinom(criticalVal, n, p);
                    if (dBinomResult == 0)
                    {
                        criticalVal += n;
                        break;
                    }

                    if (dBinomResult >= significanceLevel) break;
                    criticalVal++;
                }

                // Lower bound critical value
                return criticalVal;
            }

            while (true)
            {
                dBinomResult += DBinom(criticalVal, n, p);
                if (dBinomResult >= (1.0 - significanceLevel)) break;
                criticalVal++;
            }

            // Upper bound critical value
            return criticalVal;
        }

        public double PBinom(int k, int n, double p)
        {
            if (p < 0.0 || p > 1.0)
                throw new ArgumentOutOfRangeException(nameof(p));

            if (p == 0.0 || p == 1.0)
                return 0.0;

            if (k < 0 || n < 0 || k > n)
                return 0.0;

            var pValue = 0.0;
            var tempK = 0;
            while (tempK <= k)
            {
                pValue += DBinom(tempK, n, p);
                tempK++;
            }

            return pValue;
        }
    }
}