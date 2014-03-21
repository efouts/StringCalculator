using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class MultiplicationExpressionTests
    {
        [TestMethod]
        public void EvaluateWithTwoNormalOperands()
        {
            var left = new Expression { Value = 1 };
            var right = new Expression { Value = 2 };

            var expression = new MultiplicationExpression(left, right);
            Assert.AreEqual(2, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithOneMultiplicationExpression()
        {
            var left = new Expression { Value = 1 };
            var leftTwo = new Expression { Value = 2 };
            var rightTwo = new Expression { Value = 3 };
            var right = new MultiplicationExpression(leftTwo, rightTwo);

            var expression = new MultiplicationExpression(left, right);
            Assert.AreEqual(6, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithTwoMultiplicationExpressions()
        {
            var leftOne = new Expression { Value = 1 };
            var rightOne = new Expression { Value = 2 };
            var leftTwo = new Expression { Value = 2 };
            var rightTwo = new Expression { Value = 3 };
            var left = new MultiplicationExpression(leftOne, rightOne);
            var right = new MultiplicationExpression(leftTwo, rightTwo);

            var expression = new MultiplicationExpression(left, right);
            Assert.AreEqual(12, expression.Evaluate());
        }
    }
}
