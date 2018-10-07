using System;

namespace Lab1
{
    class LFSR
    {
        int[] factors;
        int output;
        int[] polynom;
        int capacity;

        public LFSR(int[] polynom)
        {

            this.factors = new int[polynom.Length];
            capacity = this.factors.Length - 1;

            Random rand = new Random();
            for (int i = 0; i <= capacity; i++)
            {
                this.factors[i] = rand.Next(2);
            }

            int bufer = this.factors[capacity];
            for (int i = capacity; i > 0; i--)
            {
                if (polynom[i - 1] == 1)
                {
                    this.factors[i] = xor((this.factors[i - 1]), bufer);
                }
                else
                {
                    this.factors[i] = this.factors[i - 1];
                }
            }
            this.factors[0] = bufer;
            this.polynom = polynom;
        }

        public static int xor(int a, int b)
        {
            if ((a + b) == 2)
            {
                return 0;
            }
            if ((a + b) == 1)
            {
                return 1;
            }
            return 0;
        }

        public int generateStep()
        {
            int bufer = this.factors[capacity];
            for (int i = capacity; i > 0; i--)
            {
                if (this.polynom[i - 1] == 1)
                {
                    this.factors[i] = xor((this.factors[i - 1]), bufer);
                }
                else
                {
                    this.factors[i] = this.factors[i - 1];
                }
            }
            this.factors[0] = bufer;
            output = bufer;
            return output;
        }
    }
}