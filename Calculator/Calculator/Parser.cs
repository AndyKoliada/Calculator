using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class Parser
    {
        //C# realization of Shunting-yard algorithm as an optimal way to parse math expressions

        //1st step is to convert from infix to postfix input

        public void Parse()
        {
            string infix = "";

            var operators = new Dictionary<string, int>() 
            {
                {"*", 3},
                {"/", 3},
                {"+", 2},
                {"-", 2}
            };

            string[] tokens = infix.Split(' ');
            var stack = new Stack<string>();
            var output = new List<string>();

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out _))
                {
                    output.Add(token);
                    Print(token);
                }
                else if (operators.TryGetValue(token, out var op1))
                {
                    while (stack.Count > 0 && operators.TryGetValue(stack.Peek(), out var op2))
                    {
                        int c = op1.precedence.CompareTo(op2.precedence);
                        if (c < 0 || !op1.rightAssociative && c <= 0)
                        {
                            output.Add(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }
                    stack.Push(token);
                    Print(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                    Print(token);
                }
                else if (token == ")")
                {
                    string top = "";
                    while (stack.Count > 0 && (top = stack.Pop()) != "(")
                    {
                        output.Add(top);
                    }
                    if (top != "(") throw new ArgumentException("No matching left parenthesis.");
                    Print(token);
                }
            }
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (!operators.ContainsKey(top)) throw new ArgumentException("No matching right parenthesis.");
                output.Add(top);
            }
            Print("pop");
            return string.Join(" ", output);

            //Yikes!
            void Print(string action) => Console.WriteLine($"{action + ":",-4} {$"stack[ {string.Join(" ", stack.Reverse())} ]",-18} {$"out[ {string.Join(" ", output)} ]"}");
            //A little more readable?
            void Print(string action) => Console.WriteLine("{0,-4} {1,-18} {2}", action + ":", $"stack[ {string.Join(" ", stack.Reverse())} ]", $"out[ {string.Join(" ", output)} ]");
        }
    }
}
