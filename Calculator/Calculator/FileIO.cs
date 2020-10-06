using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calculator
{
    static class FileIO
    {
        public static List<string> TextObject { get; set; } = new List<string>();

        public static void Read()
        {
            Console.Clear();
            Printer.Header();
            Console.WriteLine("Please, input the path to your expression file");
            Console.Write(@"(format is C:\\expression.txt): ");
            string filePath = Console.ReadLine();

            {
                try
                {
                    //Pass the file path and file name to the StreamReader constructor
                    StreamReader sr = new StreamReader(filePath);
                    //Read the first line of text
                    var line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the line to console window
                        //Console.WriteLine(line);
                        TextObject.Add(line);
                        //Read the next line
                        line = sr.ReadLine();
                    }
                    //close the file
                    sr.Close();
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }

            }

        }

        public static void Write()
        {

        }
    }
}
