using System;

namespace PartyManager.Testing.TestHelpers
{
    internal static class RandomHelper
    {
        public static int NumberBetween(int lower, int higher)
        {
            var generator = new Random();

            return generator.Next(lower, higher);
        }

        public static string StringOfLength(int length)
        {
            const string allowedChars = "qwertuiop";
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[NumberBetween(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}