using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2
{
    public class SHA1Algorithm
    {
        private static readonly uint[] H = new uint[] {
            0x67452301,
            0xEFCDAB89,
            0x98BADCFE,
            0x10325476,
            0xC3D2E1F0
        };
        private static readonly uint[] K = new uint[] {
            0x5A827999,
            0x6ED9EBA1,
            0x8F1BBCDC,
            0xCA62C1D6
        };

        private List<byte> message;
        private long bitlen;
        private byte[] M = new byte[64];
        private uint[] W = new uint[80];
        private string result;
        uint A, B, C, D, E, T;


        private static uint F(uint j, uint x, uint y, uint z)
        {
            if (j < 20)
                return (x & y) | ((~x) & z);
            else if (j < 40)
                return x ^ y ^ z;
            else if (j < 60)
                return (x & y) | (x & z) | (y & z);
            else if (j < 80)
                return x ^ y ^ z;
            else
                return 0;
        }

        private void extension()
        {
            bitlen = message.Count * 8;
            message.Add(0x80);
            while ((message.Count * 8) % 512 != 448)
                message.Add(0);
        }

        private void AddingLength()
        {
            var temp = message.Count;
            message.AddRange(new byte[8]);

            for (var i = message.Count - 1; i >= temp; i--)
            {
                message[i] = (byte)bitlen;
                bitlen >>= 8;
            }
        }

        private void MessageProcessing()
        {
            for (var i = 0; i < message.Count; i += 64)
            {
                for (var k = 0; k < 64; k++)
                {
                    M[k] = message[k + i];
                }

                for (var k = 0; k < 16; k++)
                {
                    W[k] = ((uint)M[k * 4]) << 24;
                    W[k] |= ((uint)M[k * 4 + 1]) << 16;
                    W[k] |= ((uint)M[k * 4 + 2]) << 8;
                    W[k] |= ((uint)M[k * 4 + 3]);
                }

                for (var k = 16; k < 80; k++)
                {
                    W[k] = RotateLeft((W[k - 3] ^ W[k - 8] ^ W[k - 14] ^ W[k - 16]), 1);
                }

                A = H[0];
                B = H[1];
                C = H[2];
                D = H[3];
                E = H[4];

                for (uint j = 0; j < 80; j++)
                {
                    T = RotateLeft(A, 5) + F(j, B, C, D) + E + W[j] + K[j / 20];
                    E = D;
                    D = C;
                    C = RotateLeft(B, 30);
                    B = A;
                    A = T;
                }

                H[0] += A; H[1] += B; H[2] += C; H[3]+= D; H[4] += E;
            }
        }
        private uint RotateLeft(uint original, int bits)
        {
            return (original << bits) | (original >> (32 - bits));
        }

        public uint[] SHA1(string message) {
            this.message = Encoding.ASCII.GetBytes(message).ToList();
            extension();
            AddingLength();
            MessageProcessing();
            return H;
        }
    }
}