using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class AdditionExpressionTests
    {
        [TestMethod]
        public void EvaluateWithTwoNormalOperands()
        {
            var left = new ConstantExpression(1);
            var right = new ConstantExpression(2);

            var expression = new AdditionExpression(left, right);
            Assert.AreEqual(3, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithOneAdditionOperand()
        {
            var left = new ConstantExpression(1);
            var leftTwo = new ConstantExpression(2);
            var rightTwo = new ConstantExpression(3);
            var right = new AdditionExpression(leftTwo, rightTwo);

            var expression = new AdditionExpression(left, right);
            Assert.AreEqual(6, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithTwoSubtractionExpressions()
        {
            var leftOne = new ConstantExpression(1);
            var rightOne = new ConstantExpression(2);
            var leftTwo = new ConstantExpression(2);
            var rightTwo = new ConstantExpression(3);
            var left = new AdditionExpression(leftOne, rightOne);
            var right = new AdditionExpression(leftTwo, rightTwo);

            var expression = new AdditionExpression(left, right);
            Assert.AreEqual(8, expression.Evaluate());
        }
    }
}
