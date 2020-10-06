using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    static class SOCalc
    {
        public static int ComputeInfix(string infix)
        {
            var operatorstack = new Stack<char>();
            var operandstack = new Stack<int>();

            var precedence = new Dictionary<char, int> { { '(', 0 }, { '*', 1 }, { '/', 1 }, { '+', 2 }, { '-', 2 }, { ')', 3 } };

            foreach (var ch in $"({infix})")
            {
                switch (ch)
                {
                    case var digit when Char.IsDigit(digit):
                        operandstack.Push(Convert.ToInt32(digit.ToString()));
                        break;
                    case var op when precedence.ContainsKey(op):
                        var keepLooping = true;
                        while (keepLooping && operatorstack.Count > 0 && precedence[ch] > precedence[operatorstack.Peek()])
                        {
                            switch (operatorstack.Peek())
                            {
                                case '+':
                                    operandstack.Push(operandstack.Pop() + operandstack.Pop());
                                    break;
                                case '-':
                                    operandstack.Push(-operandstack.Pop() + operandstack.Pop());
                                    break;
                                case '*':
                                    operandstack.Push(operandstack.Pop() * operandstack.Pop());
                                    break;
                                case '/':
                                    var divisor = operandstack.Pop();
                                    operandstack.Push(operandstack.Pop() / divisor);
                                    break;
                                case '(':
                                    keepLooping = false;
                                    break;
                            }
                            if (keepLooping)
                                operatorstack.Pop();
                        }
                        if (ch == ')')
                            operatorstack.Pop();
                        else
                            operatorstack.Push(ch);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            if (operatorstack.Count > 0 || operandstack.Count > 1)
                throw new ArgumentException();

            return operandstack.Pop();
        }
    }
}
