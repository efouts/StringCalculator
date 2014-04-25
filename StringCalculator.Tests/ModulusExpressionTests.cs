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
            var left = new Expression { Value = 1 };
            var right = new Expression { Value = 2 };

            var expression = new ModulusExpression(left, right);
            Assert.AreEqual(1, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithOneModulusExpression()
        {
            var left = new Expression { Value = 1 };
            var leftTwo = new Expression { Value = 2 };
            var rightTwo = new Expression { Value = 4 };
            var right = new ModulusExpression(leftTwo, rightTwo);

            var expression = new ModulusExpression(left, right);
            Assert.AreEqual(1, expression.Evaluate());
        }

        [TestMethod]
        public void EvaluateWithTwoModulusExpressions()
        {
            var leftOne = new Expression { Value = 1 };
            var rightOne = new Expression { Value = 2 };
            var leftTwo = new Expression { Value = 6 };
            var rightTwo = new Expression { Value = 4 };
            var left = new ModulusExpression(leftOne, rightOne);
            var right = new ModulusExpression(leftTwo, rightTwo);

            var expression = new ModulusExpression(left, right);
            Assert.AreEqual(1, expression.Evaluate());
        }
    }
}
