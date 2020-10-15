using System;

namespace Calculator
{
    static class Console
    {
        public static string errorMessage = "";
        public static string FilePath { get; set; }
        public static string InputExpression { get; set; }

        public static void Header()
        {
            System.Console.Clear();
            System.Console.WriteLine(new string('#', 30));
            System.Console.WriteLine("#        -CALCULATOR-        #");
            System.Console.WriteLine(new string('#', 30));
            System.Console.WriteLine();
        }

        public static void ManualPromt()
        {
            bool run = true;
            while (run)
            {
                System.Console.Clear();
                Header();
                System.Console.WriteLine("Please input your expression to calculate\n(only +-*/() and numbers are supported) :");
                InputExpression = System.Console.ReadLine();

                decimal result;

                var calc = new Calculator();

                if (calc.TryParse(InputExpression, out result, out errorMessage) & calc.errorMessage == "")
                {
                    System.Console.WriteLine(result);
                }
                else
                {
                    System.Console.WriteLine(calc.errorMessage);
                }




                System.Console.WriteLine("Press any key to continue or \"E\" to exit");
                var promt = System.Console.ReadLine();
                run = promt?.ToUpper() != "E";
            }
        }

        public static void FileInputPromt()
        {
            bool run = true;
            while (run)
            {
                System.Console.Clear();
                Header();
                System.Console.WriteLine("Please, input the path to your expression file");
                System.Console.Write(@"(format is C:\\expression.txt): ");
                FileIO.ReadS(System.Console.ReadLine());


                System.Console.WriteLine("Press any key to continue or \"E\" to exit");
                var promt = System.Console.ReadLine();
                run = promt?.ToUpper() != "E";
            }



        }

    }
}
