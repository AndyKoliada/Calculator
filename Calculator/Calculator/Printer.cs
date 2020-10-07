using System;

namespace Calculator
{
    static class Printer
    {
        public static string FilePath { get; set; }
        public static string InputExpression { get; set; }

        public static void Header()
        {
            Console.Clear();
            Console.WriteLine(new string('#', 30));
            Console.WriteLine("#        -CALCULATOR-        #");
            Console.WriteLine(new string('#', 30));
            Console.WriteLine();
        }

        public static void ManualPromt()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Header();
                Console.WriteLine("Please input your expression to calculate\n(only +-*/() and numbers are supported) :");
                InputExpression = Console.ReadLine();
                //Console.WriteLine($"={SOCalc.ComputeInfix(InputExpression)}");
                //SOCalc.ComputeInfix(InputExpression);
                Console.WriteLine("Press any key to continue or \"E\" to exit");
                var promt = Console.ReadLine();
                run = promt?.ToUpper() != "E";
            }
        }

        public static string FileInputPromt()
        {
                Console.Clear();
                Printer.Header();
                Console.WriteLine("Please, input the path to your expression file");
                Console.Write(@"(format is C:\\expression.txt): ");
                return Console.ReadLine();
        }

    }
}
