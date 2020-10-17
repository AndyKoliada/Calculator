using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{   
    /// <summary>
    /// Before evaluating expression we are converting inxfix notation to postfix(RPN*) using
    ///"Shunting-yard" algorithm by Edgar Dijkstra that runs in linear time - O(n).
    ///* The postfix notation was brought by Charles Hamblin in 1957, based on Polish or prefix notation, introduced in 1950 by the Polish logician Jan Lukasiewicz,
    ///* It is a method of representing an expression without using parenthesis and still conserving the precedence rules of the original expression.
    /// </summary>
    public class Calculator
    {
        private const string NumberMaker = "#";
        private const string OperatorMarker = "$";
        private const string FunctionMarker = "@";

        private const string Plus = OperatorMarker + "+";
        private const string Minus = OperatorMarker + "-";
        private const string Multiply = OperatorMarker + "*";
        private const string Divide = OperatorMarker + "/";
        private const string LeftParent = OperatorMarker + "(";
        private const string RightParent = OperatorMarker + ")";

        private readonly Dictionary<string, string> supportedOperators =
            new Dictionary<string, string>
            {
                { "+", Plus },
                { "-", Minus },
                { "*", Multiply },
                { "/", Divide },
                { "(", LeftParent },
                { ")", RightParent }
            };

        public double Parse(string expression)
        {
            try
            {
                return Calculate(ConvertToRPN(FormatString(expression)));
            }
            catch (DivideByZeroException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private string FormatString(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentNullException("Expression is null or empty");
            }

            StringBuilder formattedString = new StringBuilder();
            int balanceOfParenth = 0; // Check number of parenthesis

            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];

                if (ch == '(')
                {
                    balanceOfParenth++;
                }
                else if (ch == ')')
                {
                    balanceOfParenth--;
                }

                if (Char.IsWhiteSpace(ch))
                {
                    continue;
                }
                else
                {
                    formattedString.Append(ch);
                }
            }

            if (balanceOfParenth != 0)
            {
                throw new FormatException("Number of left and right parenthesis is not equal");
            }

            return formattedString.ToString();
        }

        private string ConvertToRPN(string expression)
        {
            int pos = 0; // Current position
            StringBuilder outputString = new StringBuilder();
            Stack<string> stack = new Stack<string>();

            // While there is unhandled char in expression
            while (pos < expression.Length)
            {
                string token = LexicalAnalysisInfixNotation(expression, ref pos);

                outputString = SyntaxAnalysisInfixNotation(token, outputString, stack);
            }

            // Pop all elements from stack to output string            
            while (stack.Count > 0)
            {
                // There should be only operators
                if (stack.Peek()[0] == OperatorMarker[0])
                {
                    outputString.Append(stack.Pop());
                }
                else
                {
                    throw new FormatException("Format exception,"
                    + " there is function without parenthesis");
                }
            }

            return outputString.ToString();
        }

        private string LexicalAnalysisInfixNotation(string expression, ref int pos)
        {
            // Receive first char
            StringBuilder token = new StringBuilder();
            token.Append(expression[pos]);

            // If it is an operator
            if (supportedOperators.ContainsKey(token.ToString()))
            {
                pos++;
                return supportedOperators[token.ToString()];
                
            }
            
            else if (Char.IsDigit(token[0]))
            {
                if (Char.IsDigit(token[0]))
                {
                    while (++pos < expression.Length
                    && Char.IsDigit(expression[pos]))
                    {
                        token.Append(expression[pos]);
                    }
                }

                return NumberMaker + token.ToString();
            }
            else
            {
                throw new ArgumentException("Unknown token in expression");
            }
        }

        private StringBuilder SyntaxAnalysisInfixNotation(string token, StringBuilder outputString, Stack<string> stack)
        {
            // If it's a number just put to string            
            if (token[0] == NumberMaker[0])
            {
                outputString.Append(token);
            }
            else if (token[0] == FunctionMarker[0])
            {
                // if it's a function push to stack
                stack.Push(token);
            }
            else if (token == LeftParent)
            {
                // If its '(' push to stack
                stack.Push(token);
            }
            else if (token == RightParent)
            {
                // If its ')' pop elements from stack to output string
                // until find the ')'

                string elem;
                while ((elem = stack.Pop()) != LeftParent)
                {
                    outputString.Append(elem);
                }

                // if after this a function is in the peek of stack then put it to string
                if (stack.Count > 0 &&
                    stack.Peek()[0] == FunctionMarker[0])
                {
                    outputString.Append(stack.Pop());
                }
            }
            else
            {
                while (stack.Count > 0 &&
                    Priority(token, stack.Peek()))
                {
                    outputString.Append(stack.Pop());
                }

                stack.Push(token);
            }

            return outputString;
        }

        private bool Priority(string token, string p)
        {
            return IsRightAssociated(token) ?
                GetPriority(token) < GetPriority(p) :
                GetPriority(token) <= GetPriority(p);
        }

        private bool IsRightAssociated(string token)
        {
            return true;
        }

        private int GetPriority(string token)
        {
            switch (token)
            {
                case LeftParent:
                    return 0;
                case Plus:
                case Minus:
                    return 2;
                case Multiply:
                case Divide:
                    return 4;
                default:
                    throw new ArgumentException("Unknown operator");
            }
        }

        private double Calculate(string expression)
        {
            int pos = 0;
            var stack = new Stack<double>();

            while (pos < expression.Length)
            {
                string token = LexicalAnalysisRPN(expression, ref pos);

                stack = SyntaxAnalysisRPN(stack, token);
            }

            if (stack.Count > 1)
            {
                throw new ArgumentException("Excess operand");
            }

            return stack.Pop();
        }

        private string LexicalAnalysisRPN(string expression, ref int pos)
        {
            StringBuilder token = new StringBuilder();

            token.Append(expression[pos++]);

            while (pos < expression.Length && expression[pos] != NumberMaker[0]
                && expression[pos] != OperatorMarker[0])
            {
                token.Append(expression[pos++]);
            }

            return token.ToString();
        }

        private Stack<double> SyntaxAnalysisRPN(Stack<double> stack, string token)
        {
            if (token[0] == NumberMaker[0])
            {
                stack.Push(double.Parse(token.Remove(0, 1)));
            }
            
            else
            {
                double arg2 = stack.Pop();
                double arg1 = stack.Pop();

                double rst;

                switch (token)
                {
                    case Plus:
                        rst = arg1 + arg2;
                        break;
                    case Minus:
                        rst = arg1 - arg2;
                        break;
                    case Multiply:
                        rst = arg1 * arg2;
                        break;
                    case Divide:
                        if (arg2 == 0)
                        {
                            throw new DivideByZeroException("Second argument is zero");
                        }
                        rst = arg1 / arg2;
                        break;
                    default:
                        throw new ArgumentException("Unknown operator");
                }

                stack.Push(rst);
            }

            return stack;
        }

    }
}