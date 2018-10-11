using System;

namespace Lab1
{
    class LFSR
    {
        int[] register;
        int output;
        int[] polynom;
        int capacity;

        public LFSR(int[] polynom)
        {
            this.register = new int[polynom.Length];
            capacity = this.register.Length - 1;

            Random rand = new Random();
            for (int i = 0; i <= capacity; i++)
            {
                this.register[i] = rand.Next(2);
            }

            int bufer = this.register[capacity];
            for (int i = capacity; i > 0; i--)
            {
                if (polynom[i - 1] == 1)
                {
                    this.register[i] = this.register[i - 1] ^ bufer;
                }
                else
                {
                    this.register[i] = this.register[i - 1];
                }
            }
            this.register[0] = bufer;
            this.polynom = polynom;
        }

        public int generateStep()
        {
            int bufer = this.register[capacity];
            for (int i = capacity; i > 0; i--)
            {
                if (this.polynom[i - 1] == 1)
                {
                    this.register[i] = this.register[i - 1] ^ bufer;
                }
                else
                {
                    this.register[i] = this.register[i - 1];
                }
            }
            this.register[0] = bufer;
            output = bufer;
            return output;
        }
    }
}