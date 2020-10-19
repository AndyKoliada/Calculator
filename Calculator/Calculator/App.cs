//using System;

//namespace Calculator
//{
//    static class App
//    {
//        public static void Run()
//        {
//            UserDialog.Header();
//            bool modeSelection = true;
//            bool manualMode = true;
//            while (modeSelection)
//            {
//                Console.Write("Press \"M\" to enter manual mode or \"O\" to open file: ");

//                string promt = Console.ReadLine();

//                if (promt?.ToUpper() == "M")
//                {
//                    break;
//                }
//                else if (promt?.ToUpper() == "O")
//                {
//                    manualMode = false;
//                    break;
//                }
//                else
//                {
//                    Console.WriteLine($"\"{promt}\" is not an option, please try again");
//                }

//            }

//            if (manualMode)
//            {
//                UserDialog.ManualPromt();
//            }
//            else
//            {
//                UserDialog.FileInputPromt();
//            }
//        }
//    }
//}
