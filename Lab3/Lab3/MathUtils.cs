using System;
using System.Collections.Generic;

namespace Lab_3
{
    public static class MathUtils
    {
        public static ushort GetRandomPremetiveRoot(ushort p)
        {
            var list = new List<ushort>();

            int phi = p - 1;

            var primeFactors = FindPrimeFactors(phi);

            for (var r = 2; r <= phi; r++) {
                bool flag = false;
                for (var i = 0; i < primeFactors.Count; i++) {
                    if (ModularExponentiation(r, phi / primeFactors[i], p) == 1) {
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                    list.Add((ushort) r);
            }

            var random = new Random();
            var randomIndex = random.Next(list.Count);
            return list[randomIndex];
        }

        public static List<int> FindPrimeFactors(int p)
        {
            var result = new List<int>();
            while (p % 2 == 0) {
                result.Add(2);
                p /= 2;
            }

            for (ushort i = 3; i <= Math.Sqrt(p); i += 2) {
                while (p % i == 0) {
                    result.Add(i);
                    p /= i;
                }
            }

            if (p > 2)
                result.Add(p);

            return result;
        }

        private static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int) Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2) {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static ushort GetFirstPrimeNumber(ushort value = 2, int maxNumber = ushort.MaxValue)
        {
            ushort number = value;
            while (!IsPrime(number)) {
                number++;
            }

            return number;
        }

        public static int ModularExponentiation(int x, int y, int p)
        {
            int res = 1;

            x = x % p;

            while (y > 0) {
                if (y % 2 == 1)
                    res = (res * x) % p;

                y = y >> 1;
                x = (x * x) % p;
            }

            return res;
        }
    }
}