using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class MultiplicationExpression : Expression
    {
        private Expression left;
        private Expression right;

        public MultiplicationExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public Double Evaluate()
        {
            return left.Evaluate() * right.Evaluate();
        }
    }
}