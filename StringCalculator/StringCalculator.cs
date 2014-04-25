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
        private String operators = "+-*/%^";
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

                if (ShouldEvaluateExponentialExpression(function, operatorFound, i)) 
                {
                    var exponentialExpressionIndex = i;
                    while (InExponentialExpression(function, exponentialExpressionIndex))
                        exponentialExpressionIndex--;

                    if (exponentialExpressionIndex > 0)
                    {
                        var exponentialExpression = GetExpression(function.Substring(exponentialExpressionIndex + 1));

                        var nonExponentialFunction = function.Substring(0, exponentialExpressionIndex);
                        var left = GetExpression(nonExponentialFunction);
                        var right = new Expression() { Value = exponentialExpression.Evaluate() };
                        var nonExponentialOperator = function[exponentialExpressionIndex];
                        var nonExponentialExpression = ExpressionFactory.Get(nonExponentialOperator, left, right);

                        return nonExponentialExpression;
                    }
                }
                else if (ShouldEvaluateMultiplicativeExpression(function, operatorFound, i))
                {
                    var multiplicativeExpressionIndex = i;
                    while (InMultiplicativeExpression(function, multiplicativeExpressionIndex))
                        multiplicativeExpressionIndex--;

                    if (multiplicativeExpressionIndex > 0)
                    {
                        var multiplicativeExpression = GetExpression(function.Substring(multiplicativeExpressionIndex + 1));

                        var nonMultiplicativeFunction = function.Substring(0, multiplicativeExpressionIndex);
                        var left = GetExpression(nonMultiplicativeFunction);
                        var right = new Expression() { Value = multiplicativeExpression.Evaluate() };
                        var nonMultiplicativeOperator = function[multiplicativeExpressionIndex];
                        var nonMultiplicativeExpression = ExpressionFactory.Get(nonMultiplicativeOperator, left, right);

                        return nonMultiplicativeExpression;
                    }
                }

                if (CanBuildExpression(function, operatorFound, i))
                    return BuildExpression(function, i);
            }

            return new Expression() { Value = Convert.ToDouble(function) };
        }

        private bool ShouldEvaluateExponentialExpression(string function, bool operatorFound, int functionIndex)
        {
            return CanBuildExpression(function, operatorFound, functionIndex) && IsExponential(function[functionIndex + 1]); ;
        }

        private bool IsExponential(char character)
        {
            return character == '^';
        }

        private Boolean CanBuildExpression(String function, Boolean operatorFound, Int32 functionIndex)
        {
            return IsANumber(function[functionIndex]) && operatorFound;
        }

        private Boolean ShouldEvaluateMultiplicativeExpression(String function, Boolean operatorFound, Int32 functionIndex)
        {
            return CanBuildExpression(function, operatorFound, functionIndex) && IsMultiplicative(function[functionIndex + 1]);
        }

        private Boolean InExponentialExpression(String function, Int32 exponentialExpressionIndex)
        {
            var startsWithNegativeNumber = exponentialExpressionIndex > 0 && !IsANumber(function[exponentialExpressionIndex - 1]) && IsOperator(function[exponentialExpressionIndex]);

            return exponentialExpressionIndex >= 0 && (!IsOperator(function[exponentialExpressionIndex])
                                                         || IsExponential(function[exponentialExpressionIndex])
                                                         || startsWithNegativeNumber);
        }

        private Boolean InMultiplicativeExpression(String function, Int32 multiplicativeExpressionIndex)
        {
            var startsWithNegativeNumber = multiplicativeExpressionIndex > 0 && !IsANumber(function[multiplicativeExpressionIndex - 1]) && IsOperator(function[multiplicativeExpressionIndex]);

            return multiplicativeExpressionIndex >= 0 && (!IsOperator(function[multiplicativeExpressionIndex])
                                                         || IsMultiplicative(function[multiplicativeExpressionIndex])
                                                         || startsWithNegativeNumber);
        }

        private Expression BuildExpression(String function, Int32 i)
        {
            var number = function.Substring(i + 2);
            var left = GetExpression(function.Substring(0, i + 1));
            var right = new Expression() { Value = Convert.ToDouble(number) };

            return ExpressionFactory.Get(function[i + 1], left, right);
        }

        private Boolean IsMultiplicative(Char character)
        {
            return character == '*' || character == '/' || character == '%';
        }

        private Boolean IsOperator(Char character)
        {
            return operators.Contains(character);
        }

        private Boolean IsANumber(Char character)
        {
            return numbers.Contains(character);
        }

        public char nonExponentialOperator { get; set; }
    }
}
