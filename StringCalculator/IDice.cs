using System;

namespace StringCalculator
{
    public interface IDice
    {
        void Roll(Int32 numberOfDie, Int32 numberOfSides);
        Int32 Value { get; }
    }
}
