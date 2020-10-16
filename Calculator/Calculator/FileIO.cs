using MathParserTK;
using System;
using System.Collections.Generic;
using System.IO;

namespace Calculator
{
    static class FileIO
    {
        //public static List<string> TextObject { get; set; } = new List<string>();

        //public static void Read()
        //{
        //    System.Console.Clear();
        //    Console.Header();
        //    System.Console.WriteLine("Please, input the path to your expression file");
        //    System.Console.Write(@"(format is C:\\expression.txt): ");
        //    string filePath = System.Console.ReadLine();

        //    {
        //        try
        //        {
        //            //Pass the file path and file name to the StreamReader constructor
        //            StreamReader sr = new StreamReader(filePath);
        //            //Read the first line of text
        //            var line = sr.ReadLine();
        //            //Continue to read until you reach end of file
        //            while (line != null)
        //            {
        //                //write the line to console window
        //                //Console.WriteLine(line);
        //                TextObject.Add(line);
        //                //Read the next line
        //                line = sr.ReadLine();
        //            }
        //            //close the file
        //            sr.Close();
        //            System.Console.WriteLine();
        //        }
        //        catch (Exception e)
        //        {
        //            System.Console.WriteLine("Exception: " + e.Message);
        //        }

        //    }

        //}

        public static string errorMessage = "";

        public static void ReadS(string filePath)
        {

            if (File.Exists(filePath))
            {
                //var calc = new Calculator();

                string line = "";
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line + " = " + parser.Parse(line));
                        string exc = "";
                        double result = 0;

                        MathParser parser = new MathParser();

                        try
                        {
                            result = parser.Parse(line);
                        }
                        catch (Exception e)
                        {
                            exc = e.Message;
                        }
                        finally
                        {
                            if (exc != "")
                            {
                                Console.WriteLine(line + " = " + exc);
                            }
                            else
                            {
                                Console.WriteLine(line + " = " + result);
                            }
                        }
                    }
                    Console.WriteLine($"Opened file: {Path.GetFileName(filePath)}");
                }
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }

        public static void Write()
        {
            //var sw = new StreamWriter();
            //sw
        }
    }
}
