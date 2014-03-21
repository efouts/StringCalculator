using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class SubtractionExpression : Expression
    {
        private Expression left;
        private Expression right;

        public SubtractionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override Double Evaluate()
        {
            return left.Evaluate() - right.Evaluate();
        }
    }
}