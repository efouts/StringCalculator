using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculator.Tests
{
    [TestClass]
    public class ModulusExpressionTests
    {
        [TestMethod]
        public void EvaluateWithTwoNormalOperands()
        {
            var left = new ConstantExpression(1);
            var right = new ConstantExpression(2);

            var expression = new ModulusExpression(left, right);
            Assert.AreEqual(1, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithOneModulusExpression()
        {
            var left = new ConstantExpression(1);
            var leftTwo = new ConstantExpression(2);
            var rightTwo = new ConstantExpression(4);
            var right = new ModulusExpression(leftTwo, rightTwo);

            var expression = new ModulusExpression(left, right);
            Assert.AreEqual(1, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithTwoModulusExpressions()
        {
            var leftOne = new ConstantExpression(1);
            var rightOne = new ConstantExpression(2);
            var leftTwo = new ConstantExpression(6);
            var rightTwo = new ConstantExpression(4);
            var left = new ModulusExpression(leftOne, rightOne);
            var right = new ModulusExpression(leftTwo, rightTwo);

            var expression = new ModulusExpression(left, right);
            Assert.AreEqual(1, expression.Evaluate());
        }
    }
}
