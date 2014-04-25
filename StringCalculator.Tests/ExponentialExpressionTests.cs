using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class ExponentialExpressionTests
    {
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 4)]
        [TestCase(2, 3, 8)]
        public void CalculateWorks(Double left, Double right, Double expectedValue)
        {
            var leftExpression = new Expression { Value = left };
            var rightExpression = new Expression { Value = right };

            var expression = new ExponentialExpression(leftExpression, rightExpression);
            Assert.AreEqual(expectedValue, expression.Evaluate());
        }
    }
}
