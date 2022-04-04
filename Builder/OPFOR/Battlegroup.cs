using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Builder.OPFOR
{
    class Battlegroup
    {
        public static void Draw(Models.OPFOR OPFORFaction)
        {
            Input(OPFORFaction.BattlegroupVehicles);
        }

        public static void Input(Models.SQFArray SQFArray, string Introduction = "")
        {
            bool exit = false;
            string input = "";
            int CursorPosition = 0;
            while (!exit)
            {
                // Needs work
                Console.Clear();
                if (Introduction != "")
                {
                    Console.WriteLine(Introduction);
                }
                Console.WriteLine("Write \"del\" if you wish to remove an entry.");
                Console.WriteLine("Write \"clear\" to clear all entries.");
                Console.WriteLine("Write \"back\" to go back to the previous menu.\n");
                Console.Write(SQFArray.Name + " = [\n");
                for (int i = 0; i < SQFArray.Count() - 1; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if(i == CursorPosition) Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t\"" + SQFArray.Entries[i] + "\",");
                }
                if (SQFArray.Count() > 0)
                {
                    if (CursorPosition == 0) Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\t\"" + SQFArray.Entries[SQFArray.Count() - 1] + "\"");

                }
                Console.Write("];\nYour input: ");
                ConsoleKeyInfo key = Console.ReadKey();
                bool EnterPressed = false;
                while(!EnterPressed)
                {
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        input = input.Substring(0, input.Length - 1);
                    } else if (key.Key == ConsoleKey.Enter)
                    {
                        EnterPressed = true;
                    } else if (key.Key == ConsoleKey.UpArrow)
                    {
                        CursorPosition += 1;

                    } else if (key.Key == ConsoleKey.DownArrow)
                    {
                        CursorPosition -= 1;
                    } else if (key.Key == ConsoleKey.LeftArrow)
                    {

                    } else if (key.Key != ConsoleKey.Enter)
                    {
                        input += key.ToString();
                    }
                    Console.Write("/r" + input);
                }
                
                // input = Console.ReadLine();
                if (input.ToLower() == "back")
                {
                    exit = true;
                }
                else if (input.ToLower() == "del" && SQFArray.Count() > 0)
                {
                    SQFArray.RemoveLast();
                }
                else if (input.ToLower() == "clear" && SQFArray.Count() > 0)
                {
                    SQFArray.Entries.Clear();
                }
                else
                {
                    SQFArray.AddEntry(input);
                }
            }
        }
    }
}
