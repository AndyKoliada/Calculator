using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    //Modified "Shunting-yard" algorithm by Edgar Dijkstra runs in linear time - O(n).

    class Calculator
    {
        public int Calculate(string input)
        {
            char[] tokens = input.ToCharArray();

            Stack<int> operands = new Stack<int>();

            Stack<char> operations = new Stack<char>();

            for (int i = 0; i < tokens.Length; i++)
            {
                // Skipping accidental white spaces
                if (tokens[i] == ' ')
                {
                    continue;
                }

                // If token is a number, push it to stack for operands  
                if (Char.IsNumber(tokens[i]))
                {
                    StringBuilder sb = new StringBuilder();
                    // Supporting more than one digits in number  
                    while (i < tokens.Length && Char.IsNumber(tokens[i]))
                    {
                        sb.Append(tokens[i++]);
                    }
                    operands.Push(int.Parse(sb.ToString()));
                }

                // Dealing with open brace
                else if (tokens[i] == '(')
                {
                    operations.Push(tokens[i]);
                }

                // When closing brace has arrived, pushing all insides to stack
                else if (tokens[i] == ')')
                {
                    while (operations.Peek() != '(')
                    {
                        operands.Push(applyOp(operations.Pop(), operands.Pop(), operands.Pop()));
                    }
                    operations.Pop();
                }

                // Processing binary operators
                else if (tokens[i] == '+' || tokens[i] == '-' || tokens[i] == '*' || tokens[i] == '/')
                {
                    // While top of 'ops' has same or greater precedence to current  
                    // token, which is an operator. Apply operator on top of 'ops'  
                    // to top two elements in values stack  
                    while (operations.Count > 0 && hasPrecedence(tokens[i], operations.Peek()))
                    {
                        operands.Push(applyOp(operations.Pop(), operands.Pop(), operands.Pop()));
                    }

                    // Push current token to 'ops'.  
                    operations.Push(tokens[i]);
                }
            }

            // Entire expression has been parsed at this point, apply remaining  
            // ops to remaining values  
            while (operations.Count > 0)
            {
                operands.Push(applyOp(operations.Pop(), operands.Pop(), operands.Pop()));
            }

            // Top of 'values' contains result, return it  
            return operands.Pop();
        }

        // Returns true if 'op2' has higher or same precedence as 'op1',  
        // otherwise returns false.  
        public static bool hasPrecedence(char op1, char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // A utility method to apply an operator 'op' on operands 'a'   
        // and 'b'. Return the result.  
        public static int applyOp(char op, int b, int a)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        throw new System.NotSupportedException("Cannot divide by zero");
                    }
                    return a / b;
            }
            return 0;
        }
    }
}
