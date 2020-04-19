// All rights reserved.
// Licensed under the MIT license.

using System;

namespace QSharpCheck
{
    public static class TestCaseGenerator
    {
        private static readonly Random R = new Random(DateTime.Now.Millisecond);

        private static double RandomDoubleNumberGenerator(double min, double max)
        {
            return R.NextDouble() * (max - min) + min;
        }

        public static double ToRadians(double degree)
        {
            return (Math.PI / 180.0) * degree;
        }

        public static double ThetaGenerator(double min = 0.0, double max = 180.0)
        {
            return max == 0.0 ? 0.0 : RandomDoubleNumberGenerator(min, max);
        }

        public static double PhiGenerator(double min = 0.0, double max = 360.0)
        {
            return max == 0.0 ? 0.0 : RandomDoubleNumberGenerator(min, max);
        }

        private static (int b1, int b2) RandomPairGenerator()
        {
            return (R.Next(2), R.Next(2));
        }
    }
}