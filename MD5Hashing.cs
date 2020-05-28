using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTeachingTool
{
    class MD5Hashing
    {
        // Hashing (Group A) is implemented here
        // Dynamic generation of objects based on complex user-defined use of OOP model (Group A) is implemented here

        // Four 32-bits long words for the buffer of MD5
        private UInt32 A = 0x01234567;
        private UInt32 B = 0x89ABCDEF;
        private UInt32 C = 0xFEDCBA98;
        private UInt32 D = 0x76543210;

        // The constant table of 64 elements
        private readonly UInt32[] K = new UInt32[64];

        // The constant binary left shift values
        private readonly int[] SHIFT = new int[64]
        {
            7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,
            5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20,
            4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23,
            6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21
        };

        // A salt data used to defend against rainbow table attack
        private const string SALT = "We can only see a short distance ahead, but we can see plenty there that needs to be done.";

        public MD5Hashing()
        {
            // Use binary integer part of the sines of integers (in radians) as constants of the table
            for (int i = 0; i < 64; i++)
                K[i] = Convert.ToUInt32(Math.Floor(Math.Abs(Math.Sin(i + 1)) * Math.Pow(2, 32)));
        }

        /// <summary>
        /// One of the four auxiliary functions that each take as input three 32-bit words and produce as output one 32-bit word.
        /// </summary>
        private UInt32 F(UInt32 X, UInt32 Y, UInt32 Z)
        {
            return (X & Y) | (~X & Z);
        }

        /// <summary>
        /// One of the four auxiliary functions that each take as input three 32-bit words and produce as output one 32-bit word.
        /// </summary>
        private UInt32 G(UInt32 X, UInt32 Y, UInt32 Z)
        {
            return (X & Z) | (Y & ~Z);
        }

        /// <summary>
        /// One of the four auxiliary functions that each take as input three 32-bit words and produce as output one 32-bit word.
        /// </summary>
        private UInt32 H(UInt32 X, UInt32 Y, UInt32 Z)
        {
            return X ^ Y ^ Z;
        }

        /// <summary>
        /// One of the four auxiliary functions that each take as input three 32-bit words and produce as output one 32-bit word.
        /// </summary>
        private UInt32 I(UInt32 X, UInt32 Y, UInt32 Z)
        {
            return Y ^ (X | ~Z);
        }

        /// <summary>
        /// Creates padded message for processing. 
        /// Message is padded with 1 as the fitst bit, followed by 0s, along with the size of the message in the end.
        /// </summary>
        /// <param name="message">the message to be padded.</param>
        /// <returns>The padded message as a byte array.</returns>
        private byte[] Padding(byte[] message)
        {
            // Declare variables
            byte[] output;
            int padLength; // Number of padding bits before the 64-bit size value
            ulong messageSize; // 64-bit pad for the size of the message
            int finalLength; // Length of the padded message

            // Calculate pad lengths
            int temp = 448 - ((message.Length * 8) % 512);
            padLength = (temp + 512) % 512; // Get number of bits to be padded
            if (padLength == 0) padLength = 512; // Pad is in bits of length at least 1 and at most 512
            messageSize = (ulong)(message.Length * 8);
            finalLength = message.Length + (padLength / 8) + 8;
            output = new byte[finalLength]; // No need to pad with 0 because the output array are already initialised to 0

            // Create padded message
            for (int i = 0; i < message.Length; i++) // Copy string to output
                output[i] = message[i];
            output[message.Length] = 0x80; // Make the first bit of padding 1
            for (int i = 1; i <= 8; i++) // Write the size value
                output[finalLength - i] = (byte)(messageSize >> ((i - 1) * 8) & 0x00000000000000FF);

            return output;
        }

        /// <summary>
        /// Divides the padded message into 512-bit blocks. 
        /// </summary>
        /// <param name="message">The padded message.</param>
        /// <returns>A list of 512-bit blocks.</returns>
        private List<byte[]> DivideMessageIntoBlocks(byte[] message)
        {
            List<byte[]> output = new List<byte[]>();
            int length = message.Length;
            int blocksCount = length * 8 / 512;
            byte[] temp = new byte[64];
            for (int i = 0; i < blocksCount; i++)
            {
                for (int j = 0; j < 64; j++)
                    temp[j] = message[64 * i + j];
                output.Add(temp);
            }
            return output;
        }

        /// <summary>
        /// Divides a 512-bit block into sixteen 32-bit words.
        /// </summary>
        /// <param name="block">The 512-bit block to be divided.</param>
        /// <returns>The sixteen 32-bit words.</returns>
        private UInt32[] DivideBlockIntoWords(byte[] block)
        {
            UInt32[] output = new UInt32[16];
            UInt32 temp;
            for (int i = 0; i < 16; i++)
            {
                temp = 0;
                for (int j = 0; j < 4; j++)
                    temp |= (UInt32)(block[4 * i + j] << (3 - j) * 8);
                output[i] = temp;
            }
            return output;
        }

        /// <summary>
        /// The left rotate function.
        /// </summary>
        /// <param name="word">The word to be left rotated.</param>
        /// <param name="digits">The number of places for the left rotation.</param>
        /// <returns></returns>
        private UInt32 LeftRotate(UInt32 word, int digits)
        {
            return (word << digits) | (word >> (32 - digits));
        }

        /// <summary>
        /// Performs MD5 Hashing on the message.
        /// </summary>
        /// <param name="message">The message to be hashed.</param>
        /// <returns>The hashed value.</returns>
        private string MD5(string message)
        {
            string output;
            UInt32 tempA, tempB, tempC, tempD, transform;
            int k;
            byte[] paddedMessage = Padding(Encoding.ASCII.GetBytes(message));
            List<byte[]> blocks = DivideMessageIntoBlocks(paddedMessage);
            foreach (byte[] block in blocks)
            {
                UInt32[] M = DivideBlockIntoWords(block);
                tempA = A;
                tempB = B;
                tempC = C;
                tempD = D;
                transform = A;
                for (int i = 0; i < 64; i++)
                {
                    if (i >= 0 && i <= 15)
                    {
                        transform += F(tempB, tempC, tempD);
                        k = i;
                    }
                    else if (i >= 16 && i <= 31)
                    {
                        transform += G(tempB, tempC, tempD);
                        k = (5 * i + 1) % 16;
                    }
                    else if (i >= 32 && i <= 47)
                    {
                        transform += H(tempB, tempC, tempD);
                        k = (3 * i + 5) % 16;
                    }
                    else // if (i >= 48 && i <= 63)
                    {
                        transform += I(tempB, tempC, tempD);
                        k = (7 * i) % 16;
                    }
                    transform += tempA + M[k] + K[i];
                    tempA = tempD;
                    tempD = tempC;
                    tempC = tempB;
                    tempB += LeftRotate(transform, SHIFT[i]);
                }
                A += tempA;
                B += tempB;
                C += tempC;
                D += tempD;
            }
            output = A.ToString("X") + B.ToString("X") + C.ToString("X") + D.ToString("X");
            return output;
        }

        /// <summary>
        /// Performs MD5 Hashing with the hard-coded salt on the message.
        /// </summary>
        /// <param name="message">The message to be hashed.</param>
        /// <returns>The hashed value.</returns>
        public string Encrypt(string message)
        {
            return MD5(MD5(message) + SALT);
        }
    }
}
