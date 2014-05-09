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
            var left = new ConstantExpression(1);
            var right = new ConstantExpression(2);

            var expression = new SubtractionExpression(left, right);
            Assert.AreEqual(-1, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithOneSubtractionExpression()
        {
            var left = new ConstantExpression(1);
            var leftTwo = new ConstantExpression(2);
            var rightTwo = new ConstantExpression(3);
            var right = new SubtractionExpression(leftTwo, rightTwo);

            var expression = new SubtractionExpression(left, right);
            Assert.AreEqual(2, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithTwoSubtractionExpressions()
        {
            var leftOne = new ConstantExpression(1);
            var rightOne = new ConstantExpression(2);
            var leftTwo = new ConstantExpression(2);
            var rightTwo = new ConstantExpression(3);
            var left = new SubtractionExpression(leftOne, rightOne);
            var right = new SubtractionExpression(leftTwo, rightTwo);

            var expression = new SubtractionExpression(left, right);
            Assert.AreEqual(0, expression.Evaluate());
        }
    }
}
