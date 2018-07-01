using LocalFunctions.Cache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LocalFunctions
{
    internal class Example
    {
        private CacheClient cache = new CacheClient();

        /// <summary>
        /// Sum year digits
        /// </summary>
        /// <returns></returns>
        public int GetSumYearDigits()
        {
            int Resolver() => GetYearDigitsSum();
            return cache.GetValue("Number", Resolver);
        }

        /// <summary>
        /// Power 2
        /// </summary>
        /// <returns></returns>
        public double GetPowNumber()
        {
            double Resolver() => Math.Pow(GetSumYearDigits(), 2);
            return cache.GetValue("PowNumber", Resolver);
        }

        /// <summary>
        /// Slow method only for experiment
        /// </summary>
        /// <returns></returns>
        private int GetYearDigitsSum()
        {
            Thread.Sleep(2000);
            var date = DateTime.UtcNow;

            return SumDigits(date.Year);
        }

        /// <summary>
        /// Sum all digits in number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private int SumDigits(int number)
        {
            number = Math.Abs(number);

            var sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }
    }
}
