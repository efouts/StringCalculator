using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Expression
    {
        public Double Value { get; set; }

        public virtual Double Evaluate()
        {
            return Value;
        }
    }
}