using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class SubtractionExpressionTests
    {
        [TestMethod]
        public void EvaluateWithTwoNormalOperands()
        {
            var left = new Expression { Value = 1 };
            var right = new Expression { Value = 2 };

            var expression = new SubtractionExpression(left, right);
            Assert.AreEqual(-1, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithOneSubtractionExpression()
        {
            var left = new Expression { Value = 1 };
            var leftTwo = new Expression { Value = 2 };
            var rightTwo = new Expression { Value = 3 };
            var right = new SubtractionExpression(leftTwo, rightTwo);

            var expression = new SubtractionExpression(left, right);
            Assert.AreEqual(2, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithTwoSubtractionExpressions()
        {
            var leftOne = new Expression { Value = 1 };
            var rightOne = new Expression { Value = 2 };
            var leftTwo = new Expression { Value = 2 };
            var rightTwo = new Expression { Value = 3 };
            var left = new SubtractionExpression(leftOne, rightOne);
            var right = new SubtractionExpression(leftTwo, rightTwo);

            var expression = new SubtractionExpression(left, right);
            Assert.AreEqual(0, expression.Evaluate());
        }
    }
}
