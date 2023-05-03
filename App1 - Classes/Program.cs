using System;
using System.Drawing;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace App1Classes
{
    class Program
    {
        static void Main()
        {
            string consoleText = "";

            Calculator calculator = new Calculator();

            while (consoleText != "E" && consoleText != "e")
            {
               

                Console.Clear();
                //Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("inserisci il testo:");
                consoleText = Console.ReadLine();

                bool parseResult = calculator.ParseInput(consoleText);
                if (parseResult)
                {
                    calculator.ExecuteOperation(consoleText);
                }
                else
                {
                    Console.WriteLine("Il testo è sbagliato!");
                }

                if (calculator.Done)
                {
                    Console.WriteLine($" Risultato { calculator.Memory.ToString()}");
                    Console.ReadLine();
                    calculator = new Calculator();
                }


            }
        }
    }   
}


