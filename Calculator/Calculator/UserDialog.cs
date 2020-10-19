using System;

namespace Calculator
{
    static class UserDialog
    {
        public static string errorMessage = "";
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

                
                string exc = "";
                double result = 0;

                //Calculator parser = new Calculator();
                MathParser parser = new MathParser();

                try
                {
                    result = parser.Parse(InputExpression);
                }
                catch (Exception e)
                {
                    exc = e.Message;
                }
                finally
                {
                    if (exc != "")
                    {
                        Console.WriteLine(exc);
                    }
                    else
                    {
                        Console.WriteLine(result);
                    }
                }

                Console.WriteLine("Press any key to continue or \"E\" to exit");
                var promt = Console.ReadLine();
                run = promt?.ToUpper() != "E";
            }
        }

        public static void FileInputPromt()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Header();
                Console.WriteLine("Please, input the path to your expression file");
                Console.Write(@"(format is C:\\expression.txt): ");
                FileIO.FileOutput(Console.ReadLine());


                Console.WriteLine("Press any key to continue or \"E\" to exit");
                var promt = Console.ReadLine();
                run = promt?.ToUpper() != "E";
            }
        }

    }
}
