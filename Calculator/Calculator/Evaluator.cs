using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.Collections.Generic 
{ 
    class Evaluator 
    { 
        static void Evaluate(string[] i)
        {
        var k = new Stack<float>(); 
        float o; 
         
        foreach (var s in i) switch (s) 
                { case "+": k.Push(k.Pop() + k.Pop()); 
                       break; 
                  case "-": o = k.Pop(); k.Push(k.Pop() - o); 
                        break; 
                  case "*": k.Push(k.Pop() * k.Pop()); 
                        break; 
                  case "/": o = k.Pop(); k.Push(k.Pop() / o); 
                        break; 
                  default: k.Push(float.Parse(s)); 
                        break; 
                } 
        Console.Write(k.Pop()); 
        } 
    } 
}