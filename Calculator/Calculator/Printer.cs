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
            Console.WriteLine("Please input your expression to calculate : \n(only +-*/() and numbers are supported)");
            Console.WriteLine("Or type \"R\" to read from file");
            InputExpression = Console.ReadLine();
        }

        public static string FileInputPromt()
        {
            Console.WriteLine(@"Please, input the path to your text file (format is C:\\textfile.txt): ");
            FilePath = Console.ReadLine();
            Console.WriteLine();
            return FilePath;
        }

    }
}
