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

            ushort message = 200;
            Console.WriteLine("Message: " + message);
            var encryptedMessage = ElGamalAlgorithm.Encrypt(key, message);
            Console.WriteLine($"Encrypted: {encryptedMessage.A}, {encryptedMessage.B}");
            var decryptedMessage = ElGamalAlgorithm.Decrypt(key, encryptedMessage);
            Console.WriteLine("Decrypted: " + decryptedMessage);
        }
    }
}