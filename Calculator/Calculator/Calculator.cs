//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;

////Before evaluating expression we are converting inxfix notation to postfix(RPN*) using
////"Shunting-yard" algorithm by Edgar Dijkstra that runs in linear time - O(n).

////*The postfix notation was brought by Charles Hamblin in 1957, based on Polish or prefix notation, introduced in 1950 by the Polish logician Jan Lukasiewicz,
////*It is a method of representing an expression without using parenthesis and still conserving the precedence rules of the original expression.

//namespace Calculator
//{
//    public class Calculator
//    {
//        public string errorMessage = "";

//        decimal value = 0;

//        public decimal Parse(string expression)
//        {
//            decimal d;
//            if (decimal.TryParse(expression, out d))
//            {
//                return d;
//            }
//            else
//            {
//                return CalculateValue(expression, out errorMessage);
//            }
//        }

//        public bool TryParse(string expression, out decimal value, out string errorMessage)
//        {
//            if (IsExpression(expression, out errorMessage))
//            {
//                try
//                {
//                    value = Parse(expression);
//                    return true;
//                }
//                catch
//                {
//                    value = 0;
//                    return false;
//                }
//            }
//            else
//            {
//                value = 0;
//                return false;
//            }
//        }

//        public bool IsExpression(string s, out string errorMessage)
//        {
//            //Determines whether the string contains illegal characters
//            Regex RgxUrl = new Regex("^[0-9+*-/()., ]+$");
//            errorMessage = "Unsupported operator";
//            return RgxUrl.IsMatch(s);
//        }

//        private List<string> TokenizeExpression(string expression, Dictionary<char, int> operators)
//        {
//            List<string> elements = new List<string>();
//            string currentElement = string.Empty;

//            int state = 0;
//            /* STATES
//                 * 0 - start
//                 * 1 - after opening bracket '('
//                 * 2 - after closing bracket ')'
//                 * */
//            int bracketCount = 0;
//            for (int i = 0; i < expression.Length; i++)
//            {
//                switch (state)
//                {
//                    case 0:
//                        if (expression[i] == '(')
//                        {
//                            //Change the state after an opening bracket is received
//                            state = 1;
//                            bracketCount = 0;
//                            if (currentElement != string.Empty)
//                            {
//                                //if the currentElement is not empty, then assuming multiplication
//                                elements.Add(currentElement);
//                                elements.Add("*");
//                                currentElement = string.Empty;
//                            }
//                        }
//                        else if (operators.Keys.Contains(expression[i]))
//                        {
//                            //The current character is an operator
//                            elements.Add(currentElement);
//                            elements.Add(expression[i].ToString());
//                            currentElement = string.Empty;
//                        }
//                        else if (expression[i] != ' ')
//                        {
//                            //The current character is neither an operator nor a space
//                            currentElement += expression[i];
//                        }
//                        break;
//                    case 1:
//                        if (expression[i] == '(')
//                        {
//                            bracketCount++;
//                            currentElement += expression[i];
//                        }
//                        else if (expression[i] == ')')
//                        {
//                            if (bracketCount == 0)
//                            {
//                                state = 2;
//                            }
//                            else
//                            {
//                                bracketCount--;
//                                currentElement += expression[i];
//                            }
//                        }
//                        else if (expression[i] != ' ')
//                        {
//                            //Add the character to the current element, omitting spaces
//                            currentElement += expression[i];
//                        }
//                        break;
//                    case 2:
//                        if (operators.Keys.Contains(expression[i]))
//                        {
//                            //The current character is an operator
//                            state = 0;
//                            elements.Add(currentElement);
//                            currentElement = string.Empty;
//                            elements.Add(expression[i].ToString());
//                        }
//                        else if (expression[i] != ' ')
//                        {
//                            elements.Add(currentElement);
//                            elements.Add("*");
//                            currentElement = string.Empty;


//                            if (expression[i] == '(')
//                            {
//                                state = 1;
//                                bracketCount = 0;
//                            }
//                            else
//                            {
//                                currentElement += expression[i];
//                                state = 0;
//                            }
//                        }
//                        break;
//                }
//            }

//            //Add the last element (which follows the last operation) to the list
//            if (currentElement.Length > 0)
//            {
//                elements.Add(currentElement);
//            }

//            return elements;
//        }

//        private decimal CalculateValue(string expression, out string errorMessage)
//        {
//            errorMessage = "";
//            Dictionary<char, int> operatorsPrecedence = new Dictionary<char, int>
//            {
//                {'+', 1}, {'-', 1}, {'*', 2}, {'/', 2},
//            };

//            List<string> elements = TokenizeExpression(expression, operatorsPrecedence);

//            //define a value which will be used as the return value of the function
//            decimal value = 0;

//            //loop from the highest precedence to the lowest
//            for (int i = operatorsPrecedence.Values.Max(); i >= operatorsPrecedence.Values.Min(); i--)
//            {

//                //loop while there are any operators left in the list from the current precedence level
//                while (elements.Count >= 3
//                    && elements.Any(element => element.Length == 1 &&
//                        operatorsPrecedence.Where(op => op.Value == i)
//                        .Select(op => op.Key).Contains(element[0])))
//                {
//                    //get the position of this element
//                    int pos = elements
//                        .FindIndex(element => element.Length == 1 &&
//                        operatorsPrecedence.Where(op => op.Value == i)
//                        .Select(op => op.Key).Contains(element[0]));

//                    //evaluate it's value
//                    value = EvaluateOperation(elements[pos], elements[pos - 1], elements[pos + 1], out errorMessage);
//                    //change the first operand of the operation to the calculated value of the operation
//                    elements[pos - 1] = value.ToString();
//                    //remove the operator and the second operand from the list
//                    elements.RemoveRange(pos, 2);
//                }
//            }

//            return value;
//        }

//        private decimal EvaluateOperation(string oper, string operand1, string operand2, out string errorMessage)
//        {
//            errorMessage = "";
//            if (oper.Length == 1)
//            {
//                decimal op1 = Parse(operand1);
//                decimal op2 = Parse(operand2);

//                if (op1 < decimal.MaxValue & op2 < decimal.MaxValue & op1 > decimal.MinValue & op2 > decimal.MinValue)
//                {
//                    switch (oper[0])
//                    {
//                        case '+':
//                            if (op1 + op2 < decimal.MaxValue)
//                            {
//                                value = op1 + op2;
//                            }
//                            else
//                            {
//                                errorMessage = "decimal.MaxValue overflow";
//                            }
//                            break;
//                        case '-':
//                            if (op1 - op2 > decimal.MinValue)
//                            {
//                                value = op1 - op2;
//                            }
//                            else
//                            {
//                                errorMessage = "decimal.MinValue overflow";
//                            }
//                            break;
//                        case '*':
//                            if (op1 * op2 < decimal.MaxValue)
//                            {
//                                value = op1 * op2;
//                            }
//                            else
//                            {
//                                errorMessage = "decimal.MaxValue overflow";
//                            }
//                            break;
//                        case '/':
//                            {
//                                if (op2 != 0)
//                                {
//                                    if (op1 / op2 > decimal.MinValue)
//                                    {
//                                        value = op1 / op2;
//                                    }
//                                    else 
//                                    {
//                                        errorMessage = "decimal.MinValue overflow";
//                                    }
//                                }
//                                else
//                                {
//                                    errorMessage = "Division by zero exception";
//                                }
//                                break;
//                            }
//                        default:
//                            errorMessage = "Unsupported operator";
//                            break;
//                            //throw new ArgumentException("Unsupported operator");
//                    }
//                }
//                else
//                {
//                    errorMessage = "decimal type capacity overflow";
//                }

//                return value;
//            }
//            else
//            {
//                errorMessage = "Unsupported operator";
//                return value;
//                //throw new ArgumentException("Unsupported operator");
//            } 
//        }
//    }
//}