using System;
using System.IO;

namespace Calculator
{
    static class FileIO
    {
        public static string errorMessage = "";
        public static string inputFileName;

        public static void FileOutput(string filePath)
        {

            if (File.Exists(filePath))
            {
                string line = "";
                using (StreamReader sr = new StreamReader(filePath))
                {
                    inputFileName = Path.GetFileNameWithoutExtension(filePath);
                    string outputFolderPath = Path.GetDirectoryName(filePath);

                    string resultFileName = inputFileName + "-result.txt";
                    var sw = new StreamWriter(Path.Combine(outputFolderPath, resultFileName));

                    Console.WriteLine();

                    while ((line = sr.ReadLine()) != null)
                    {
                        string exc = "";
                        double result = 0;

                        Calculator parser = new Calculator();

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
                                sw.WriteLine(line + " = " + exc);
                            }
                            else
                            {
                                Console.WriteLine(line + " = " + result);
                                sw.WriteLine(line + " = " + result);
                            }
                        }
                    }
                    sw.Close();
                    Console.WriteLine();
                    Console.WriteLine(resultFileName + " succesfully writen to " + Path.GetDirectoryName(filePath));
                }
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }
    }
}
