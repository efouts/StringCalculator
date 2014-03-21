using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator calculator;

        public StringCalculatorTests()
        {
            calculator = new StringCalculator();
        }

        [TestCase("1", 1)]
        [TestCase("1+1", 2)]
        [TestCase("2+1", 3)]
        [TestCase("-2+1", -1)]
        [TestCase("-2+-3", -5)]
        [TestCase("-2+0", -2)]
        [TestCase("1.3+1.2", 2.5)]
        [TestCase("1-1", 0)]
        [TestCase("2-1", 1)]
        [TestCase("-2-1", -3)]
        [TestCase("-2--3", 1)]
        [TestCase("-2+0", -2)]
        [TestCase("-2+0-1", -3)]
        [TestCase("-2-0-1", -3)]
        [TestCase("-2-0-1.2", -3.2)]
        [TestCase("2*3", 6)]
        [TestCase("2/2", 1)]
        [TestCase("2*3/2", 3)]
        [TestCase("1/2", 0.5)]
        [TestCase("1/2-2", -1.5)]
        [TestCase("2*3/4", 1.5)]
        [TestCase("1-2/2", 0)]
        [TestCase("1-2/2-5", -5)]
        [TestCase("1-2/.25-5", -12)]
        [TestCase("1-2/.25-5*2", -17)]
        public void CalculateWorks(String expression, Double expectedValue)
        {
            Assert.That(calculator.Calculate(expression), Is.EqualTo(expectedValue));
        }
    }
}
