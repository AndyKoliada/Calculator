using System;

namespace Calculator
{
    class ConsoleInput
    {
        public string FilePath { get; set; }

        public void InitialPromt()
        {
            Console.WriteLine(new string('#', 30));
            Console.WriteLine("#        -CALCULATOR-        #");
            Console.WriteLine(new string('#', 30));
            Console.WriteLine();
            Console.WriteLine("Please input your expression to calculate : \n  (only +,-,*,/ and numbers are supported)");
        }

        public string ManualInputPromt()
        {

            Console.WriteLine();
            Console.WriteLine(@"Please, input the path to your text file (format is C:\\textfile.txt): ");
            FilePath = Console.ReadLine();
            Console.WriteLine();
            return FilePath;
        }

        public void FileInputPromt()
        { 
        
        }

    }
}
