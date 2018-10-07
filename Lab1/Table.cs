using System;
using System.Collections.Generic;

namespace Lab1
{
    class Table
    {

        private int[] table = new int[256];
        private int position = 0;
        const int NUMBER_LFSR = 8;

        public Table()
        {
            int number0 = 0;
            int number1 = 0;
            for (int i = 0; i < table.Length; i++)
            {
                Random rand = new Random();
                table[i] = rand.Next(2);
                if (table[i] == 0) { number0++; }
                else { number1++; }

                if (number0 == table.Length / 2)
                {
                    for (int j = i; j < table.Length; j++)
                    {
                        table[j] = 1;
                    }
                    break;
                }

                if (number1 == table.Length / 2)
                {
                    for (int j = i; j < table.Length; j++)
                    {
                        table[j] = 0;
                    }
                    break;
                }

            }

        }

        public int generate(List<LFSR> lfsr)
        {
            int output = 0;
            position = 0;
            int[] number = new int[NUMBER_LFSR];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = lfsr[i].generateStep();
            }
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == 1)
                {
                    position = position + (int)(Math.Pow(2, i));
                }
            }
            output = table[position];
            return output;
        }
    }
}