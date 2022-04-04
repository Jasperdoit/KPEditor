using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Builder.OPFOR
{
    class Militia
    {
        public static void Draw(Models.OPFOR OPFORFaction)
        {
            Models.Menu menu = new Models.Menu();
            menu.Add("Infantry", x =>
            {
                Console.Clear();
                InputInfantry(OPFORFaction.MilitiaSquad);
                return false;
            });
            menu.Add("Vehicles", x =>
            {
                Console.Clear();
                InputVehicles(OPFORFaction.MilitiaVehicles);
                return false;
            });
            menu.Draw();
        }

        public static void InputInfantry(Models.SQFArray MilitiaSquad)
        {
            bool exit = false;
            string input = "";
            while(!exit)
            {
                Console.Clear();
                Console.WriteLine("Please write down your militia unit entries. Write \"del\" if you wish to remove an entry.");
                Console.WriteLine("Write \"clear\" to clear all entries.");
                Console.WriteLine("Write \"back\" to go back to the previous menu.\n");
                Console.Write(MilitiaSquad.Name + " = [\n");
                for (int i = 0; i < MilitiaSquad.Count() - 1; i++)
                {
                    Console.WriteLine("\t\"" + MilitiaSquad.Entries[i] + "\",");
                }
                if(MilitiaSquad.Count() > 0)
                {
                    Console.WriteLine("\t\"" + MilitiaSquad.Entries[MilitiaSquad.Count() - 1] + "\"");

                }
                Console.Write("];\nYour input: ");
                input = Console.ReadLine();
                if(input.ToLower() == "back")
                {
                    exit = true;
                } else if (input.ToLower() == "del" && MilitiaSquad.Count() > 0)
                {
                    MilitiaSquad.RemoveLast();
                } else if (input.ToLower() == "clear" && MilitiaSquad.Count() > 0)
                {
                    MilitiaSquad.Entries.Clear();
                } else
                {
                    MilitiaSquad.AddEntry(input);
                }
            }
        }
        public static void InputVehicles(Models.SQFArray MilitiaVehicles)
        {
            bool exit = false;
            string input = "";
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Please write down your militia vehicle entries. Write \"del\" if you wish to remove an entry.");
                Console.WriteLine("Write \"clear\" to clear all entries.");
                Console.WriteLine("Write \"back\" to go back to the previous menu.\n");
                Console.Write(MilitiaVehicles.Name + " = [\n");
                for(int i = 0; i < MilitiaVehicles.Count() - 1; i++)
                {
                    Console.WriteLine("\t\"" + MilitiaVehicles.Entries[i] + "\",");
                }
                if (MilitiaVehicles.Count() > 0)
                {
                    Console.WriteLine("\t\"" + MilitiaVehicles.Entries[MilitiaVehicles.Count() - 1] + "\"");

                }
                Console.Write("];\nYour input: ");
                input = Console.ReadLine();
                if (input.ToLower() == "back")
                {
                    exit = true;
                }
                else if (input.ToLower() == "del" && MilitiaVehicles.Count() > 0)
                {
                    MilitiaVehicles.RemoveLast();
                }
                else if (input.ToLower() == "clear" && MilitiaVehicles.Count() > 0)
                {
                    MilitiaVehicles.Entries.Clear();
                }
                else
                {
                    MilitiaVehicles.AddEntry(input);
                }
            }
        }
    }
}
