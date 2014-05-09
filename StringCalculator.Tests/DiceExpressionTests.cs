using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StringCalculator;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class DiceExpressionTests
    {
        private IDice dice;

        [SetUp]
        public void SetUp()
        {
            dice = new Dice();
        }

        [Test]
        public void OneSidedDie()
        {
            var leftExpression = new ConstantExpression(1);
            var rightExpression = new ConstantExpression(1);

            var expression = new DiceExpression(leftExpression, rightExpression, dice);
            Assert.AreEqual(1, expression.Evaluate());
        }

        [Test]
        public void SixSidedDice()
        {
            var leftExpression = new ConstantExpression(2);
            var rightExpression = new ConstantExpression(6);

            var expression = new DiceExpression(leftExpression, rightExpression, dice);
            Assert.That(expression.Evaluate(), Is.GreaterThanOrEqualTo(2));
            Assert.That(expression.Evaluate(), Is.LessThanOrEqualTo(12));
        }

        [Test]
        public void OperandsGetTruncated()
        {
            var leftExpression = new ConstantExpression(2.9);
            var rightExpression = new ConstantExpression(6.9);

            var expression = new DiceExpression(leftExpression, rightExpression, dice);
            Assert.That(expression.Evaluate(), Is.GreaterThanOrEqualTo(2));
            Assert.That(expression.Evaluate(), Is.LessThanOrEqualTo(12));
        }
    }
}
