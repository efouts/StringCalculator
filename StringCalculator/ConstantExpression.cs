using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class ConstantExpression : Expression
    {
        private Double value;

        public ConstantExpression(Double value)
        {
            this.value = value;
        }

        public Double Evaluate()
        {
            return value;
        }
    }
}
