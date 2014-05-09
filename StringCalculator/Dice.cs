using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Dice : IDice
    {
        public Int32 Value { get; private set; }

        private Random random;

        public Dice()
        {
            random = RandomSingleton.GetInstance();
        }

        public void Roll(Int32 numberOfDie, Int32 numberOfSides)
        {
            var value = 0;

            for (var i = 0; i < numberOfDie; i++)
                value += random.Next(1, numberOfSides + 1);

            Value = value;
        }

        private static class RandomSingleton
        {
            private static readonly Random instance;

            static RandomSingleton()
            {
                instance = new Random();
            }

            public static Random GetInstance()
            {
                return instance;
            }
        }
    }
}
