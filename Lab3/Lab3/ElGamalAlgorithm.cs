using System;

namespace Lab_3
{
    public static class ElGamalAlgorithm
    {
        public static ElGamalKey GenerateKeys(ushort p = 0)
        {
            var random = new Random();

            if (p < 2) {
                p = MathUtils.GetFirstPrimeNumber((ushort) random.Next(ushort.MaxValue));
            }

            ushort x = (ushort) random.Next(2, p);
            ushort g = MathUtils.GetRandomPremetiveRoot(p);
            ushort y = (ushort) MathUtils.ModularExponentiation(g, x, p);

            return new ElGamalKey {
                X = x,
                Y = y,
                G = g,
                P = p
            };
        }

        public static EncryptedMessage Encrypt(ElGamalKey key, ushort message)
        {
            Random random = new Random();

            var k = random.Next(1, key.P - 1);

            // a = g^k mod p
            var a = (ushort) MathUtils.ModularExponentiation(key.G, k, key.P);
            // b = y^k M mod p
            var b = (ushort) MathUtils.ModularExponentiation(key.Y, k, key.P);

            var c = (b * message) % key.P;

            return new EncryptedMessage(a, (ushort) c);
        }

        public static ushort Decrypt(ElGamalKey key, EncryptedMessage encryptedMessage)
        {
            //apx = a^(p-1-x) mod p
            var apx = (ushort) MathUtils.ModularExponentiation(encryptedMessage.A, key.P - 1 - key.X, key.P);
            //apx = b*apx mod p
            var m = (ushort) ((encryptedMessage.B * apx) % key.P);

            return m;
        }
    }
}