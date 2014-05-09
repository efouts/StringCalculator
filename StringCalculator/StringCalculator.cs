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
        private String allOperators = "+-*/%^d";
        private ExpressionFactory expressionFactory;

        public StringCalculator(ExpressionFactory expressionFactory)
        {
            this.expressionFactory = expressionFactory;
        }

        private Char[][] orderOfOperations = new[] {
            new[] { 'd' },
            new[] { '^' },
            new[] { '*', '/', '%' }
        };

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
                operatorFound |= allOperators.Contains(function[i]);

                foreach (var operators in orderOfOperations)
                {
                    if (ShouldEvaluateExpression(function, operatorFound, i, operators))
                    {
                        var expressionIndex = i;
                        while (SameOrderExpression(function, expressionIndex, operators))
                            expressionIndex--;

                        if (expressionIndex > 0)
                        {
                            var expression = GetExpression(function.Substring(expressionIndex + 1));

                            var left = GetExpression(function.Substring(0, expressionIndex));
                            var right = new ConstantExpression(expression.Evaluate());
                            return expressionFactory.Get(function[expressionIndex], left, right);
                        }
                    }
                }

                if (CanBuildExpression(function, operatorFound, i))
                {
                    var number = function.Substring(i + 2);

                    var left = GetExpression(function.Substring(0, i + 1));
                    var right = new ConstantExpression(Convert.ToDouble(number));
                    return expressionFactory.Get(function[i + 1], left, right);
                }
            }

            return new ConstantExpression(Convert.ToDouble(function));
        }

        private Boolean CanBuildExpression(String function, Boolean operatorFound, Int32 functionIndex)
        {
            return Char.IsNumber(function[functionIndex]) && operatorFound;
        }

        private Boolean ShouldEvaluateExpression(String function, Boolean operatorFound, Int32 functionIndex, IEnumerable<Char> expressionOperators)
        {
            return CanBuildExpression(function, operatorFound, functionIndex) && expressionOperators.Contains(function[functionIndex + 1]);
        }

        private Boolean SameOrderExpression(String function, Int32 multiplicativeExpressionIndex, IEnumerable<Char> expressionOperators)
        {
            var startsWithNegativeNumber = multiplicativeExpressionIndex > 0 && !Char.IsNumber(function[multiplicativeExpressionIndex - 1]) && allOperators.Contains(function[multiplicativeExpressionIndex]);

            return multiplicativeExpressionIndex >= 0 && (!allOperators.Contains(function[multiplicativeExpressionIndex])
                                                         || expressionOperators.Contains(function[multiplicativeExpressionIndex])
                                                         || startsWithNegativeNumber);
        }
    }
}
