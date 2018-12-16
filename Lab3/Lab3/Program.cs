using System;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = ElGamalAlgorithm.GenerateKeys(239);
            
            Console.WriteLine("p: " + key.P);
            Console.WriteLine("g: " + key.G);
            Console.WriteLine("x: " + key.X);
            Console.WriteLine("y: " + key.Y);
        }
    }
}