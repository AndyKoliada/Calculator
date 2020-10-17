using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [DataTestMethod]
        [DataRow("1+2*(3+2)", "11")]
        [DataRow("1 + x + 4", "Unknown token in expression")]
        [DataRow("2 + 15 / 3 + 4 * 2", "15")]
        [DataRow("2 / 0", "Second argument is zero")]
        [DataRow("5", "5")]
        //[DataRow("++4", "Stack empty.")]
        //[DataRow("--", "Stack empty.")]
        [DataRow("0 / 99999999999999999999999999999999999999999999999999999999999999999999", "0")]
        public void ParseTest(string input, string output)
        {
            var calc = new Calculator();
            string parsed = "";
            string exc = "";

            try
            {
                parsed = calc.Parse(input).ToString();
            }
            catch (Exception e)
            {
                exc = e.Message;
            }
            finally
            {
                if (exc != "")
                {
                    parsed = exc;
                }
                //else
                //{
                //    Console.WriteLine(line + " = " + result);
                //    sw.WriteLine(line + " = " + result);
                //}
            }

            Assert.AreEqual(parsed, output);
        }
    }
}

namespace CalculatorTests
{
    class CalculatorTests
    {
    }
}
