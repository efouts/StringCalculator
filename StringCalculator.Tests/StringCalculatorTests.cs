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
            var loadedDice = new LoadedDice();
            loadedDice.SetNextRolls(new[] { 4, 4, 4, 4, 4, 4, 4, 4 });
            var expressionFactory = new ExpressionFactory(loadedDice);
            calculator = new StringCalculator(expressionFactory);
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
        [TestCase("2-3/4", 1.25)]
        [TestCase("1-2*2", -3)]
        [TestCase("1-2/2-5", -5)]
        [TestCase("1-2/.25-5", -12)]
        [TestCase("1-2/.25-5*2", -17)]
        [TestCase("-1-2/-.25-5*2", -3)]
        [TestCase("-1*2/-.25", 8)]
        [TestCase("-1*-2/-.25", -8)]
        [TestCase("-1.25*-2.00000/-0.25", -10)]
        [TestCase("-1.25*-2.00000/-0.25*23847-2389+389+238/7", -240436)]
        [TestCase("1%1", 0)]
        [TestCase("2+3%3", 2)]
        [TestCase("2-3%3", 2)]
        [TestCase("2*3%3", 0)]
        [TestCase("2*3%3+2", 2)]
        [TestCase("4/2%3+2", 4)]
        [TestCase("2*3%3+1%2", 1)]
        [TestCase("144/2/6/3", 4)]
        [TestCase("3^4", 81)]
        [TestCase("2^2^4", 256)]
        [TestCase("1+1d6", 5)]
        [TestCase("1+1d6+1", 6)]
        [TestCase("1+4d6+1", 18)] 
        public void CalculateWorks(String expression, Double expectedValue)
        {
            Assert.That(calculator.Calculate(expression), Is.EqualTo(expectedValue));
        }
    }
}
