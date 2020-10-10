using System;

namespace Calculator
{
    static class App
    {
        public static void Run()
        {
            Console.Header();
            bool modeSelection = true;
            bool manualMode = true;
            while (modeSelection)
            {
                System.Console.Write("Press \"M\" to enter manual mode or \"O\" to open file: ");

                string promt = System.Console.ReadLine();

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
                    System.Console.WriteLine($"\"{promt}\" is not an option, please try again");
                }

            }

            if (manualMode)
            {
                Console.ManualPromt();
            }
            else
            {
                Console.FileInputPromt();
            }
            

        }
    }
}
