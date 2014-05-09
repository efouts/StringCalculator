using System;
using System.Collections.Generic;

namespace StringCalculator.Tests
{
    public class LoadedDice : IDice
    {
        public Int32 Value { get; private set; }

        private IEnumerator<Int32> rolls;

        public void SetNextRolls(IEnumerable<Int32> rolls)
        {
            this.rolls = rolls.GetEnumerator();
        }

        public void Roll(Int32 numberOfDie, Int32 numberOfSides)
        {
            var value = 0;

            for (var i = 0; i < numberOfDie; i++)
                value += RollDie();

            Value = value;
        }

        private Int32 RollDie()
        {
            rolls.MoveNext();
            return rolls.Current;
        }
    }
}
