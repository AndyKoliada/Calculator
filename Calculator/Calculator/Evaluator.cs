//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace Calculator
//{
//    public class Evaluator
//    {
//        public decimal Evaluate(string expression)
//        {
//            if (string.IsNullOrWhiteSpace(expression))
//            {
//                return 0;
//            }

//            operatorStack.Clear();
//            expressionStack.Clear();

//            using (var reader = new StringReader(expression))
//            {
//                int peek;
//                while ((peek = reader.Peek()) > -1)
//                {
//                    var next = (char)peek;

//                    if (char.IsDigit(next))
//                    {
//                        expressionStack.Push(ReadOperand(reader));
//                        continue;
//                    }

//                    if (Operation.IsDefined(next))
//                    {
//                        var currentOperation = ReadOperation(reader);

//                        EvaluateWhile(() => operatorStack.Count > 0 && operatorStack.Peek() != '(' &&
//                                            currentOperation.Precedence <= ((Operation)operatorStack.Peek()).Precedence);

//                        operatorStack.Push(next);
//                        continue;
//                    }

//                    if (next == '(')
//                    {
//                        reader.Read();
//                        operatorStack.Push('(');
//                        continue;
//                    }

//                    if (next == ')')
//                    {
//                        reader.Read();
//                        EvaluateWhile(() => operatorStack.Count > 0 && operatorStack.Peek() != '(');
//                        operatorStack.Pop();
//                        continue;
//                    }

//                    if (next != ' ')
//                    {
//                        throw new ArgumentException(string.Format("Encountered invalid character {0}", next), "expression");
//                    }
//                }
//            }

//            EvaluateWhile(() => operatorStack.Count > 0);

//            var compiled = Expression.Lambda<Func<decimal>>(expressionStack.Pop()).Compile();
//            return compiled();
//        }
//    }
//}
