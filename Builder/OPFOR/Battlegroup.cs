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
            Models.Menu menu = new Models.Menu("From this menu, you can change everything related to battlegroups\n" +
                "Transport vehicles and helicopters should be in one of the battlegroup vehicle lists.");
            menu.Add("High Alert Battlegroup Vehicles", x =>
            {
                Console.Clear();
                OPFORFaction.BattlegroupVehicles.Input("Please fill in your High Alert Battlegroup entries.");
                return false;
            });
            menu.Add("Low Alert Battlegroup Vehicles", x =>
            {
                Console.Clear();
                OPFORFaction.BattlegroupVehiclesLowIntensity.Input("Please fill in your Low Alert Battlegroup entries.");
                return false;
            });
            menu.Add("Assign Transport", x =>
            {
                Console.Clear();
                AssignTransport(OPFORFaction);
                return false;
            });
            menu.Add("Assign Helicopter", x =>
            {
                Console.Clear();
                AssignChopper(OPFORFaction);
                return false;
            });
            menu.Draw();
        }
        public static void AssignTransport(Models.OPFOR OPFORFaction)
        {
            bool exit = false;
            List<string> AvailableVehicles = new List<string>();
            int CursorPos = 0;
            foreach(var vehicle in OPFORFaction.BattlegroupVehicles.Entries)
            {
                if(!AvailableVehicles.Contains(vehicle)) AvailableVehicles.Add(vehicle);
            }
            foreach (var vehicle in OPFORFaction.BattlegroupVehiclesLowIntensity.Entries)
            {
                if (!AvailableVehicles.Contains(vehicle)) AvailableVehicles.Add(vehicle);
            }
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Please select the vehicles to add as transport vehicles.\n");
                for(int i = 0; i < AvailableVehicles.Count; i++)
                {
                    if(i == CursorPos && OPFORFaction.TroupTransport.Entries.Contains(AvailableVehicles[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.White;
                    } else if (i == CursorPos)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (OPFORFaction.TroupTransport.Entries.Contains(AvailableVehicles[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Black;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(AvailableVehicles[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Backspace)
                {
                    exit = true;
                } 
                else if (key.Key == ConsoleKey.Enter && CursorPos >= 0 && CursorPos < AvailableVehicles.Count)
                {
                    if(OPFORFaction.TroupTransport.Entries.Contains(AvailableVehicles[CursorPos]))
                    {
                        OPFORFaction.TroupTransport.RemoveEntry(AvailableVehicles[CursorPos]);
                    }
                    else
                    {
                        OPFORFaction.TroupTransport.AddEntry(AvailableVehicles[CursorPos]);
                    }
                }
                else if (key.Key >= ConsoleKey.DownArrow && CursorPos + 1 >= 0 && CursorPos + 1 < AvailableVehicles.Count)
                {
                    CursorPos += 1;
                }
                else if (key.Key == ConsoleKey.UpArrow && CursorPos - 1 >= 0 && CursorPos - 1 < AvailableVehicles.Count)
                {
                    CursorPos -= 1;
                }

            }
        }
        public static void AssignChopper(Models.OPFOR OPFORFaction)
        {
            bool exit = false;
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
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Please select the vehicles to add as a helicopter.\n");
                for (int i = 0; i < AvailableVehicles.Count; i++)
                {
                    if (i == CursorPos && OPFORFaction.Choppers.Entries.Contains(AvailableVehicles[i]))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (i == CursorPos)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (OPFORFaction.Choppers.Entries.Contains(AvailableVehicles[i]))
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape || key.Key == ConsoleKey.Backspace)
                {
                    exit = true;
                }
                else if (key.Key == ConsoleKey.Enter && CursorPos >= 0 && CursorPos < AvailableVehicles.Count)
                {
                    if (OPFORFaction.Choppers.Entries.Contains(AvailableVehicles[CursorPos]))
                    {
                        OPFORFaction.Choppers.RemoveEntry(AvailableVehicles[CursorPos]);
                    }
                    else
                    {
                        OPFORFaction.Choppers.AddEntry(AvailableVehicles[CursorPos]);
                    }
                }
                else if (key.Key >= ConsoleKey.DownArrow && CursorPos + 1 >= 0 && CursorPos + 1 < AvailableVehicles.Count)
                {
                    CursorPos += 1;
                }
                else if (key.Key == ConsoleKey.UpArrow && CursorPos - 1 >= 0 && CursorPos - 1 < AvailableVehicles.Count)
                {
                    CursorPos -= 1;
                }

            }
        }

    }
}
