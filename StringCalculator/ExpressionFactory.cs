using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class ExpressionFactory
    {
        private IDice dice;

        public ExpressionFactory(IDice dice)
        {
            this.dice = dice;
        }

        public Expression Get(Char @operator, Expression left, Expression right)
        {
            switch (@operator)
            {
                case 'd': return new DiceExpression(left, right, dice);
                case '^': return new ExponentialExpression(left, right);
                case '%': return new ModulusExpression(left, right);
                case '/': return new DivisionExpression(left, right);
                case '*': return new MultiplicationExpression(left, right);
                case '-': return new SubtractionExpression(left, right);
                case '+': return new AdditionExpression(left, right);
                default: throw new ArgumentOutOfRangeException("@operator");
            }
        }
    }
}
