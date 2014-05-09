using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class DiceExpression : Expression
    {
        private Expression left;
        private Expression right;
        private IDice dice;

        public DiceExpression(Expression left, Expression right, IDice dice)
        {
            this.left = left;
            this.right = right;
            this.dice = dice;
        }

        public override Double Evaluate()
        {
            dice.Roll((Int32)left.Evaluate(), (Int32)right.Evaluate());
            return dice.Value;
        }
    }
}
