using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    static class App
    {
        public static void Run(string[] args)
        {
            bool manualMode = true;
            while (manualMode)
            {
                Printer.Header();
                Printer.ManualPromt();
                

                string userWantsToContinue = Console.ReadLine();
                manualMode = userWantsToContinue?.ToUpper() != "R";
            }
            Printer.Header();
            Printer.FileInputPromt();

        }
    }
}
