using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Builder.OPFOR
{
    class SecondaryObjectives
    {
        public static void Draw(Models.OPFOR OPFORFaction)
        {
            bool exit = false;
            int CursorPos = 0;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Please select the vehicles to add as a helicopter.\n");
                for (int i = 0; i < OPFORFaction.SecondaryObjectives.Count; i++)
                {
                    if (i == CursorPos)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(OPFORFaction.SecondaryObjectives[i].Name + " -> " + OPFORFaction.SecondaryObjectives[i].Entry);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Backspace)
                {
                    exit = true;
                }
                else if (key.Key == ConsoleKey.Enter && CursorPos >= 0 && CursorPos < OPFORFaction.SecondaryObjectives.Count)
                {
                    EditEntry(OPFORFaction.SecondaryObjectives[CursorPos]);
                }
                else if (key.Key >= ConsoleKey.DownArrow && CursorPos + 1 >= 0 && CursorPos + 1 < OPFORFaction.SecondaryObjectives.Count)
                {
                    CursorPos += 1;
                }
                else if (key.Key == ConsoleKey.UpArrow && CursorPos - 1 >= 0 && CursorPos - 1 < OPFORFaction.SecondaryObjectives.Count)
                {
                    CursorPos -= 1;
                }

            }
        }
        public static void EditEntry(Models.SQFEntry Object)
        {
            Console.Clear();
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine($"Please write an entry for {Object.Name}. Type \"back\" to keep it as {Object.Entry}.");
                string input = Console.ReadLine();
                if(input.ToLower() == "back")
                {
                    exit = true;
                } else
                {
                    Object.Entry = input;
                    exit = true;
                }
            }
        }
    }
}
