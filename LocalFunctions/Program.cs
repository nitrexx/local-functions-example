using System;

namespace LocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new Example();

            // call resolver + slow method
            var resolverNumber = example.GetSumYearDigits();
            Console.WriteLine($"Resolver: {resolverNumber}");

            // call cache
            var cacheNumber = example.GetSumYearDigits();
            Console.WriteLine($"Cache: {cacheNumber}");

            // call cache + pow
            var powNumber = example.GetPowNumber();
            Console.WriteLine($"Pow: {powNumber}");

            Console.ReadKey();
        }
    }
}
