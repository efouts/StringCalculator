using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class DivisionExpressionTests
    {
        [TestMethod]
        public void EvaluateWithTwoNormalOperands()
        {
            var left = new Expression { Value = 1 };
            var right = new Expression { Value = 2 };

            var expression = new DivisionExpression(left, right);
            Assert.AreEqual(0.5, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithOneMultiplicationExpression()
        {
            var left = new Expression { Value = 1 };
            var leftTwo = new Expression { Value = 2 };
            var rightTwo = new Expression { Value = 4 };
            var right = new DivisionExpression(leftTwo, rightTwo);

            var expression = new DivisionExpression(left, right);
            Assert.AreEqual(2, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithTwoMultiplicationExpressions()
        {
            var leftOne = new Expression { Value = 1 };
            var rightOne = new Expression { Value = 2 };
            var leftTwo = new Expression { Value = 6 };
            var rightTwo = new Expression { Value = 3 };
            var left = new DivisionExpression(leftOne, rightOne);
            var right = new DivisionExpression(leftTwo, rightTwo);

            var expression = new DivisionExpression(left, right);
            Assert.AreEqual(0.25, expression.Evaluate());
        }
    }
}
