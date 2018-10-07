using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] selection = new int[10000];
            int[] polynom0 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            int[] polynom1 = { 1, 0, 0, 0, 0, 1 };
            int[] polynom2 = { 0, 0, 1, 0, 0, 0, 1 };
            int[] polynom3 = { 0, 1, 1, 1, 0, 0, 0, 1 };
            int[] polynom4 = { 0, 0, 0, 1, 0, 0, 0, 0, 1 };
            int[] polynom5 = { 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 };
            int[] polynom6 = { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            int[] polynom7 = { 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1 };
            int[] polynom8 = { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            List<LFSR> lfsr = new List<LFSR>();
            lfsr.Add(new LFSR(polynom1));
            lfsr.Add(new LFSR(polynom2));
            lfsr.Add(new LFSR(polynom3));
            lfsr.Add(new LFSR(polynom4));
            lfsr.Add(new LFSR(polynom5));
            lfsr.Add(new LFSR(polynom6));
            lfsr.Add(new LFSR(polynom7));
            lfsr.Add(new LFSR(polynom8));


            Table table = new Table();

            for (int i = 0; i < selection.Length; i++)
            {
                int bufer;

                bufer = table.generate(lfsr);
                selection[i] = bufer;
                Console.Write(bufer + ",");
            }
            Console.WriteLine("");
            Console.WriteLine("Tests: ");
            Console.WriteLine("1. Frequency: " + Tester.frequencyTest(selection));
            Console.WriteLine("2. XOR: " + Tester.xorFrequencyTest(selection));
            int[] ranks = Tester.rankTest(selection, 4);
            Console.WriteLine("3. Rank: ");
            for (int i = 0; i < ranks.Length; i++)
            {
                Console.WriteLine(Convert.ToString(i, 2) + "  " + (double)ranks[i]/*/selection.length*/);
            }
            Console.WriteLine("4. Complexity: ");
            Tester.complexityTest(selection);
        }
    }
}
