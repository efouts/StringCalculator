using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        private String operators = "+-*/";
        private String numbers = "0123456789";

        public Double Calculate(String function)
        {
            var expression = GetExpression(function);
            return expression.Evaluate();
        }

        private Expression GetExpression(String function)
        {
            var operatorFound = false;

            for (var i = function.Length - 1; i >= 0; i--)
            {
                operatorFound |= IsOperator(function[i]);

                if (IsANumber(function[i]) && operatorFound && IsMultiplicationOrDivision(function[i + 1]))
                {
                    var startOfSubstring = i;
                    while (startOfSubstring >= 0 && (!IsOperator(function[startOfSubstring]) || IsMultiplicationOrDivision(function[startOfSubstring])))
                        startOfSubstring--;

                    var multDivSubstring = function.Substring(startOfSubstring + 1);

                    if (function != multDivSubstring)
                    {
                        var expression = GetExpression(multDivSubstring);
                        var result = expression.Evaluate();

                        if (startOfSubstring == 0)
                            return new Expression() { Value = result };

                        var remainingFunction = function.Substring(0, startOfSubstring);
                        var left = GetExpression(remainingFunction);
                        var right = new Expression() { Value = result };

                        switch (function[startOfSubstring])
                        {
                            case '-': return new SubtractionExpression(left, right);
                            case '+':
                            default: return new AdditionExpression(left, right);
                        }
                    }
                }

                if (IsANumber(function[i]) && operatorFound)
                    return BuildExpression(function, i);
            }

            return new Expression() { Value = Convert.ToDouble(function) };
        }

        private Expression BuildExpression(String function, Int32 i)
        {
            var number = function.Substring(i + 2);
            var left = GetExpression(function.Substring(0, i + 1));
            var right = new Expression() { Value = Convert.ToDouble(number) };            

            switch (function[i + 1])
            {
                case '/': return new DivisionExpression(left, right);
                case '*': return new MultiplicationExpression(left, right);
                case '-': return new SubtractionExpression(left, right);
                case '+':
                default: return new AdditionExpression(left, right); 
            }
        }

        private Boolean IsMultiplicationOrDivision(Char character)
        {
            return character == '*' || character == '/';
        }

        private Boolean IsOperator(Char character)
        {
            return operators.Contains(character);
        }

        private Boolean IsANumber(Char character)
        {
            return numbers.Contains(character);
        }
    }
}
