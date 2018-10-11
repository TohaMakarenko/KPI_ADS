using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] selection = new int[10000];
            int[][] polynoms = {
            new int[]{ 1, 0, 0, 0, 0, 1 },
            new int[]{ 0, 0, 1, 0, 0, 0, 1 },
            new int[]{ 0, 1, 1, 1, 0, 0, 0, 1 },
            new int[]{ 0, 0, 0, 1, 0, 0, 0, 0, 1 },
            new int[]{ 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            new int[]{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[]{ 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1 },
            new int[]{ 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 }};
            List<LFSR> lfsr = new List<LFSR>();
            lfsr.Add(new LFSR(polynoms[0]));
            lfsr.Add(new LFSR(polynoms[1]));
            lfsr.Add(new LFSR(polynoms[2]));
            lfsr.Add(new LFSR(polynoms[3]));
            lfsr.Add(new LFSR(polynoms[4]));
            lfsr.Add(new LFSR(polynoms[5]));
            lfsr.Add(new LFSR(polynoms[6]));
            lfsr.Add(new LFSR(polynoms[7]));


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
            int[] ranks = Tester.rankTest(selection, 3);
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
