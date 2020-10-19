using System;

namespace Calculator
{
    public class UserDialog
    {
        private string InputExpression { get; set; }

        private void Header()
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

        private void ManualPromt()
        {
            while (true)
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

                if (Console.ReadLine().ToUpper() == "E") break;
            }
        }

        private void FileInputPromt()
        {
            while (true)
            {
                Console.Clear();
                Header();
                Console.WriteLine("Please, input the path to your expression file");
                Console.Write(@"(format is C:\\expression.txt): ");
                var fIO = new FileIO();
                fIO.FileOutput(Console.ReadLine());

                Console.WriteLine("Press any key to continue or \"E\" to exit");

                if(Console.ReadLine().ToUpper() == "E") break;
            }
        }

    }
}
