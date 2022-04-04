using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Builder.OPFOR
{
    class Military
    {
        public static void Draw(Models.OPFOR OPFORFaction)
        {
            Models.Menu menu = new Models.Menu();
            menu.Add("Infantry", x =>
            {
                Console.Clear();
                InfantryDraw(OPFORFaction);
                return false;
            });
            menu.Add("Vehicles", x =>
            {
                Console.Clear();
                MilitaryVehicles.Draw(OPFORFaction);
                return false;
            });
            menu.Draw();
        }
        public static void InfantryDraw(Models.OPFOR OPFORFaction)
        {
            string input = "";
            bool doExit = false;
            var OriginalColor = Console.ForegroundColor;
            do
            {
                Console.Clear();
                int Count = 1;
                foreach (Models.OPFORSoldier Soldier in OPFORFaction.InfantryList)
                {
                    if (Soldier.Classname != "")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"[{Count}] {Soldier.Type} -> {Soldier.Classname}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"[{Count}] {Soldier.Type}");
                    }
                    Count++;
                }
                Console.ForegroundColor = OriginalColor;
                Console.Write("\nIf the classname is ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Green");
                Console.ForegroundColor = OriginalColor;
                Console.Write(" then a value is assigned.");
                Console.WriteLine("You can always go back by writing \"back\".");
                Console.WriteLine("Select a classname to add/edit:");
                input = Console.ReadLine();
                if (input.ToLower() == "back") doExit = true;
                else if (input.ToLower() == "export")
                {
                    Export(OPFORFaction);
                }
                else if (int.TryParse(input, out int ID) && ID - 1 >= 0 && ID - 1 < OPFORFaction.InfantryList.Count)
                {
                    OPFORFaction.InfantryList[ID - 1] = EditSoldier(OPFORFaction.InfantryList[ID - 1]);
                }
            } while (!doExit);
        }
        public static Models.OPFORSoldier EditSoldier(Models.OPFORSoldier Soldier)
        {
            string input = "";
            while(input.ToLower() != "back")
            {
                Console.Clear();
                Console.WriteLine($"Please write a classname for: {Soldier.Type}.");
                input = Console.ReadLine();
                if(input.ToLower() != "back")
                {
                    Soldier.SetClassname(input);
                    return Soldier;
                }
            }
            return Soldier;
        }
        public static void Export(Models.OPFOR Faction)
        {
            string s = "";
            foreach(Models.OPFORSoldier Soldier in Faction.InfantryList)
            {
                s += Soldier.Compile() + "\n";
            }
            File.WriteAllText(Faction.FileName + ".sqf", s);
        }
    }
}
