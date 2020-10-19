using System;

namespace Calculator
{
    public class UserDialog
    {
        //private string FilePath { get; set; }
        private string InputExpression { get; set; }

        public void Header()
        {
            Console.Clear();
            Console.WriteLine(new string('#', 30));
            Console.WriteLine("#        -CALCULATOR-        #");
            Console.WriteLine(new string('#', 30));
            Console.WriteLine();
        }

        public void InitializeDialog()
        {
            Header();
            bool modeSelection = true;
            bool manualMode = true;
            while (modeSelection)
            {
                Console.Write("Press \"M\" to enter manual mode or \"O\" to open file: ");

                string promt = Console.ReadLine();

                if (promt?.ToUpper() == "M")
                {
                    break;
                }
                else if (promt?.ToUpper() == "O")
                {
                    manualMode = false;
                    break;
                }
                else
                {
                    Console.WriteLine($"\"{promt}\" is not an option, please try again");
                }

            }

            if (manualMode)
            {
                ManualPromt();
            }
            else
            {
                FileInputPromt();
            }
        }

        public void ManualPromt()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Header();
                Console.WriteLine("Please input your expression to calculate\n(only +-*/() and numbers are supported) :");
                InputExpression = Console.ReadLine();

                Calculator parser = new Calculator();

                try
                {
                    Console.WriteLine(parser.Parse(InputExpression));
                }
                catch (Exception e)
                {
                        Console.WriteLine(e.Message);
                }

                Console.WriteLine("Press any key to continue or \"E\" to exit");
                var promt = Console.ReadLine();
                run = promt?.ToUpper() != "E";
            }
        }

        public void FileInputPromt()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Header();
                Console.WriteLine("Please, input the path to your expression file");
                Console.Write(@"(format is C:\\expression.txt): ");
                var fIO = new FileIO();
                fIO.FileOutput(Console.ReadLine());


                Console.WriteLine("Press any key to continue or \"E\" to exit");
                var promt = Console.ReadLine();
                run = promt?.ToUpper() != "E";
            }
        }

    }
}
