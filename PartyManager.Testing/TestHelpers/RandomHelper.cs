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
            char[] chars = new char[NumberBetween(0,255)];

            return new string(chars, 0, length);
        }
    }
}