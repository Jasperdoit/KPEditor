using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Builder.OPFOR
{
    class Express
    {
        public static void Draw()
        {
            Console.Clear();
            string input = "";
            while(input == "")
            {
                Console.Write("Please give your Faction a name: ");
                input = Console.ReadLine();
            }
            Models.OPFOR OPFORFaction = new Models.OPFOR(input);
            int step = 0;
            while(step <= 11)
            {
                switch(step)
                {
                    case 0:
                        step = InfantryDraw(step, OPFORFaction);
                        if (step < 0) step = 0;
                        break;
                    case 1:
                        step = SelectSecondary(step, OPFORFaction);
                        break;
                    case 2:
                        step = Input(step, OPFORFaction.MilitiaSquad);
                        break;
                    case 3:
                        step = Input(step, OPFORFaction.MilitiaVehicles);
                        break;
                    case 4:
                        step = Input(step, OPFORFaction.Vehicles);
                        break;
                    case 5:
                        step = Input(step, OPFORFaction.VehiclesLowIntensity);
                        break;
                    case 6:
                        step = Input(step, OPFORFaction.BattlegroupVehicles);
                        break;
                    case 7:
                        step = Input(step, OPFORFaction.BattlegroupVehiclesLowIntensity);
                        break;
                    case 8:
                        step = Assign(step, OPFORFaction, OPFORFaction.TroupTransport);
                        break;
                    case 9:
                        step = Assign(step, OPFORFaction, OPFORFaction.Choppers);
                        break;
                    case 10:
                        step = Input(step, OPFORFaction.Planes);
                        break;
                    case 11:
                        step = CompileFaction(step, OPFORFaction);
                        break;
                    case 12:
                        return;
                }
            }
        }

        public static int EditSoldier(Models.OPFORSoldier Soldier)
        {
            string input = "";
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Please write a classname for: {Soldier.Type}.");
                input = Console.ReadLine();
                if(input.ToLower() == "continue")
                {
                    return 0;
                } else if(input.ToLower() == "previous") { return 1; }
                else if(input.ToLower() == "next") return 2;
                else if(input.ToLower() == "back") return 3;
                else
                {
                    Soldier.SetClassname(input);
                    return 0;
                }
            }
        }

        public static int InfantryDraw(int step, Models.OPFOR OPFORFaction)
        {
            int count = 0;
            while(true)
            {
                if (count == OPFORFaction.InfantryList.Count)
                {
                    return ++step;
                } else if (count < 0)
                {
                    count = 0;
                } else if (count > OPFORFaction.InfantryList.Count)
                {
                    count = OPFORFaction.InfantryList.Count - 1;
                }
                int order = EditSoldier(OPFORFaction.InfantryList[count]);
                switch(order)
                {
                    case 0:
                        count++;
                        break;
                    case 1:
                        count--;
                        break;
                    case 2:
                        return ++step;
                    case 3:
                        return --step;
                }
            }
        }

        public static int InputMilitiaInfantry(int step, Models.SQFArray MilitiaSquad)
        {
            string input = "";
            while (true)
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
                if (MilitiaSquad.Count() > 0)
                {
                    Console.WriteLine("\t\"" + MilitiaSquad.Entries[MilitiaSquad.Count() - 1] + "\"");

                }
                Console.Write("];\nYour input: ");
                input = Console.ReadLine();
                if (input.ToLower() == "back")
                {
                    return --step;
                }
                else if (input.ToLower() == "next")
                {
                    return ++step;
                }
                else if (input.ToLower() == "del" && MilitiaSquad.Count() > 0)
                {
                    MilitiaSquad.RemoveLast();
                }
                else if (input.ToLower() == "clear" && MilitiaSquad.Count() > 0)
                {
                    MilitiaSquad.Entries.Clear();
                }
                else
                {
                    MilitiaSquad.AddEntry(input);
                }
            }
        }

        public static int Input(int step, Models.SQFArray Arr, string Introduction = "")
        {
            string input = "";
            while (true)
            {
                Console.Clear();
                if (Introduction != "")
                {
                    Console.WriteLine(Introduction);
                }
                Console.WriteLine("Write \"del\" if you wish to remove an entry.");
                Console.WriteLine("Write \"clear\" to clear all entries.");
                Console.WriteLine("Write \"back\" to go back to the previous menu.\n");
                Console.Write(Arr.Name + " = [\n");
                for (int i = 0; i < Arr.Count() - 1; i++)
                {
                    Console.WriteLine("\t\"" + Arr.Entries[i] + "\",");
                }
                if (Arr.Count() > 0)
                {
                    Console.WriteLine("\t\"" + Arr.Entries[Arr.Count() - 1] + "\"");

                }
                Console.Write("];\nYour input: ");
                input = Console.ReadLine();
                if (input.ToLower() == "back")
                {
                    return --step;
                }
                else if (input.ToLower() == "next")
                {
                    return ++step;
                }
                else if (input.ToLower() == "del" && Arr.Count() > 0)
                {
                    Arr.RemoveLast();
                }
                else if (input.ToLower() == "clear" && Arr.Count() > 0)
                {
                    Arr.Entries.Clear();
                }
                else
                {
                    Arr.AddEntry(input);
                }
            }
        }

        public static int SelectSecondary(int step, Models.OPFOR OPFORFaction)
        {
            int CursorPos = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please select the Secondary Objective Objects that corrospond to your faction.\n");
                for (int i = 0; i < OPFORFaction.SecondaryObjectives.Count; i++)
                {
                    Select((i, CursorPos) => i == CursorPos, i, CursorPos, OPFORFaction.SecondaryObjectives[i].Name + " -> " + OPFORFaction.SecondaryObjectives[i].Entry);
                }
                Select((len, CursorPos) => CursorPos == len, OPFORFaction.SecondaryObjectives.Count, CursorPos, "next");
                Select((len, CursorPos) => CursorPos == len + 1, OPFORFaction.SecondaryObjectives.Count, CursorPos, "back");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter && CursorPos >= 0 && CursorPos == OPFORFaction.SecondaryObjectives.Count)
                {
                    return ++step;
                }
                else if (key.Key == ConsoleKey.Enter && CursorPos >= 0 && CursorPos == OPFORFaction.SecondaryObjectives.Count + 1)
                {
                    return --step;
                }
                else if (key.Key == ConsoleKey.Enter && CursorPos >= 0 && CursorPos < OPFORFaction.SecondaryObjectives.Count)
                {
                    EditEntry(OPFORFaction.SecondaryObjectives[CursorPos]);
                }
                else if (key.Key >= ConsoleKey.DownArrow && CursorPos + 1 >= 0 && CursorPos + 1 < OPFORFaction.SecondaryObjectives.Count + 2)
                {
                    CursorPos += 1;
                }
                else if (key.Key == ConsoleKey.UpArrow && CursorPos - 1 >= 0 && CursorPos - 1 < OPFORFaction.SecondaryObjectives.Count + 2)
                {
                    CursorPos -= 1;
                }

            }
        }

        public static void Select(Func<int, int, bool> Condition, int Compare1, int Compare2, string Text)
        {
            if (Condition(Compare1, Compare2)) {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor= ConsoleColor.White;
            } else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine(Text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void EditEntry(Models.SQFEntry Object)
        {
            Console.Clear();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"Please write an entry for {Object.Name}. Type \"back\" to keep it as {Object.Entry}.");
                string input = Console.ReadLine();
                if (input.ToLower() == "back")
                {
                    exit = true;
                }
                else
                {
                    Object.Entry = input;
                    exit = true;
                }
            }
        }

        public static int Assign(int step, Models.OPFOR OPFORFaction, Models.SQFArray Goal, string introduction = "")
        {
            List<string> AvailableVehicles = new List<string>();
            int CursorPos = 0;
            foreach (var vehicle in OPFORFaction.BattlegroupVehicles.Entries)
            {
                if (!AvailableVehicles.Contains(vehicle)) AvailableVehicles.Add(vehicle);
            }
            foreach (var vehicle in OPFORFaction.BattlegroupVehiclesLowIntensity.Entries)
            {
                if (!AvailableVehicles.Contains(vehicle)) AvailableVehicles.Add(vehicle);
            }
            while (true)
            {
                Console.Clear();
                if(introduction != "")
                {
                    Console.WriteLine(introduction);
                }
                for (int i = 0; i < AvailableVehicles.Count; i++)
                {
                    if (i == CursorPos && Goal.Entries.Contains(AvailableVehicles[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (i == CursorPos)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (Goal.Entries.Contains(AvailableVehicles[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(AvailableVehicles[i]);
                }
                Select((x, y) => x == y, CursorPos, AvailableVehicles.Count, "Next");
                Select((x, y) => x == y + 1, CursorPos, AvailableVehicles.Count, "Back");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter && CursorPos == AvailableVehicles.Count)
                {
                    return ++step;
                }
                else if (key.Key == ConsoleKey.Enter && CursorPos == AvailableVehicles.Count + 1)
                {
                    return --step;
                }
                else if (key.Key == ConsoleKey.Enter && CursorPos >= 0 && CursorPos < AvailableVehicles.Count)
                {
                    if (Goal.Entries.Contains(AvailableVehicles[CursorPos]))
                    {
                        Goal.RemoveEntry(AvailableVehicles[CursorPos]);
                    }
                    else
                    {
                        Goal.AddEntry(AvailableVehicles[CursorPos]);
                    }
                }
                else if (key.Key >= ConsoleKey.DownArrow && CursorPos + 1 >= 0 && CursorPos + 1 < AvailableVehicles.Count + 2)
                {
                    CursorPos += 1;
                }
                else if (key.Key == ConsoleKey.UpArrow && CursorPos - 1 >= 0 && CursorPos - 1 < AvailableVehicles.Count + 2)
                {
                    CursorPos -= 1;
                }

            }
        }

        public static int CompileFaction(int count, Models.OPFOR OPFORFaction)
        {
            while (true)
            {
                Console.Clear();
                string IncompleteModules = Compile.CheckComplete(OPFORFaction);
                if (IncompleteModules != "")
                {
                    Console.WriteLine("WARNING! THE FOLLOWING FIELDS HAVE NOT BEEN SET:");
                    Console.WriteLine(IncompleteModules);
                    Console.WriteLine("ALL FIELDS MUST BE FILLED OUT BEFORE A FACTION FILE\n" +
                        "MAY BE COMPILED!\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                    return 0;
                }
                Console.WriteLine("Are you sure you want to compile the Faction? (y/n)");
                ConsoleKeyInfo input = Console.ReadKey();
                if (input.Key == ConsoleKey.Y)
                {
                    Compile.CompileFaction(OPFORFaction);
                    Console.WriteLine($"\r{OPFORFaction.FileName}.sqf has been exported.\n" +
                        $"Do note that if you had a custom opfor_ammobox_transport, you will need\n" +
                        $"to set the positions for the crates for this vehicle inside the config file.\n" +
                        $"Press any key to continue.");
                    Console.ReadKey();
                    return count++;
                }
                else if (input.Key == ConsoleKey.N)
                {
                    return 0;
                }
            }
        }

    }
}
