using System;
using System.IO;

namespace Calculator
{
    public class FileIO
    {
        private string inputFileName;

        public void FileOutput(string filePath)
        {

            if (File.Exists(filePath))
            {
                string line;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    inputFileName = Path.GetFileNameWithoutExtension(filePath);
                    string outputFolderPath = Path.GetDirectoryName(filePath);

                    string resultFileName = inputFileName + "-result.txt";
                    var sw = new StreamWriter(Path.Combine(outputFolderPath, resultFileName));

                    Console.WriteLine();

                    while ((line = sr.ReadLine()) != null)
                    {
                        Calculator parser = new Calculator();

                        try
                        {
                            Console.WriteLine(line + " = " + parser.Parse(line));
                            sw.WriteLine(line + " = " + parser.Parse(line));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(line + " = " + e.Message);
                            sw.WriteLine(line + " = " + e.Message);
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
