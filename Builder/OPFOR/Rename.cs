using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Builder.OPFOR
{
    class Rename
    {
        public static void Draw(Models.OPFOR OPFORFaction)
        {
            bool exit = false;
            string input = "";
            while (!exit)
            {
                Console.WriteLine($"Please write a new name for \"{OPFORFaction.FileName}.sqf\" The \".sqf\" is already included.");
                Console.WriteLine($"Write \"back\" to discard this change.");
                input = Console.ReadLine();
                if (input.ToLower() == "back")
                {
                    exit = true;
                }
                else
                {
                    OPFORFaction.FileName = input;
                    Console.Clear();
                    Console.WriteLine($"The new name is \"{OPFORFaction.FileName}.sqf\". Press any key to continue.");
                    Console.ReadKey();
                    exit = true;
                }
            }
        }
    }
}
