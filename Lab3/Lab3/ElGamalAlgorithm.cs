using System;

namespace Lab_3
{
    public static class ElGamalAlgorithm
    {   
        public static ElGamalKey GenerateKeys(ushort p = 0)
        {
            var random = new Random();

            if (p < 2) {
                p = MathUtils.GetFirstPrimeNumber((ushort)random.Next(ushort.MaxValue));
            }
            
            ushort x = (ushort)random.Next(2, p);
            ushort g = MathUtils.GetRandomPremetiveRoot(p);
            ushort y = (ushort)MathUtils.ModularExponentiation(g, x, p);

            return new ElGamalKey
            {
                X = x,
                Y = y,
                G = g,
                P = p
            };
        }
    }
}