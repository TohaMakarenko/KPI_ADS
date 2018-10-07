using System;

namespace Lab1
{
    class Tester
    {

        public static double frequencyTest(int[] arr)
        {
            int output = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                {
                    output++;
                }
            }
            return ((double)output / arr.Length);
        }


        public static double xorFrequencyTest(int[] arr)
        {
            int output = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if ((arr[i] ^ arr[i + 1]) == 1)
                {
                    output++;
                }
            }
            return ((double)output / (arr.Length - 1));
        }

        public static int[] rankTest(int[] arr, int width)
        {
            if (width <= 0 || width > 10)
            {
                throw new ArgumentException("Width must be range [2;10]");
            }
            int[] output = new int[(int)Math.Pow(2, width)];
            for (int i = 0; i < arr.Length - width; i++)
            {
                int bufer = 0;
                for (int j = 0; j < width; j++)
                {
                    bufer = bufer << 1;
                    bufer = bufer | arr[i + j];
                }
                output[bufer]++;
            }
            return output;
        }

        public static void complexityTest(int[] arr)
        {
            int N = arr.Length;
            int[] b = new int[N];
            int[] c = new int[N];
            int[] t = new int[N];
            b[0] = 1;
            c[0] = 1;
            int l = 0;
            int m = -1;
            for (int n = 0; n < N; n++)
            {
                int d = 0;
                for (int i = 0; i <= l; i++)
                {
                    d ^= c[i] * arr[n - i];
                }
                if (d == 1)
                {
                    Array.Copy(c, 0, t, 0, N);
                    int NiM = n - m;
                    for (int j = 0; j < N - NiM; j++)
                    {
                        c[NiM + j] ^= b[j];
                    }
                    if (l <= n / 2)
                    {
                        l = n + 1 - l;
                        m = n;

                        Array.Copy(t, 0, b, 0, N);
                    }
                }
            }
            Console.WriteLine(l);
        }
    }
}