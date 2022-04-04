using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KPEditor.Builder.OPFOR
{
    class Compile
    {
        public static string CheckComplete(Models.OPFOR OPFORFaction)
        {
            string IncompleteModules = "";
            foreach(var Soldier in OPFORFaction.InfantryList)
            {
                if (Soldier.Classname == "")
                {
                    IncompleteModules += "Infantry\n";
                    break;
                }
            }
            if (OPFORFaction.MilitiaSquad.IsEmpty()) IncompleteModules += "Militia Squad\n";
            if (OPFORFaction.MilitiaVehicles.IsEmpty()) IncompleteModules += "Militia Vehicles\n";
            if (OPFORFaction.Vehicles.IsEmpty()) IncompleteModules += "High Alert Military Vehicles\n";
            if (OPFORFaction.VehiclesLowIntensity.IsEmpty()) IncompleteModules += "Low Alert Military Vehicles\n";
            if (OPFORFaction.BattlegroupVehicles.IsEmpty()) IncompleteModules += "High Alert Battlegroup Vehicles\n";
            if (OPFORFaction.BattlegroupVehiclesLowIntensity.IsEmpty()) IncompleteModules += "Low Alert Battlegroup Vehicles\n";
            if (OPFORFaction.TroupTransport.IsEmpty()) IncompleteModules += "Transport Vehicles\n";
            if (OPFORFaction.Choppers.IsEmpty()) IncompleteModules += "Helicopters\n";
            if (OPFORFaction.Planes.IsEmpty()) IncompleteModules += "Planes\n";

            return IncompleteModules;
        }
        public static void Draw(Models.OPFOR OPFORFaction)
        {
            bool exit = false;
            while(!exit)
            {
                Console.Clear();
                string IncompleteModules = CheckComplete(OPFORFaction);
                if (IncompleteModules != "")
                {
                    Console.WriteLine("WARNING! THE FOLLOWING FIELDS HAVE NOT BEEN SET:");
                    Console.WriteLine(IncompleteModules);
                    Console.WriteLine("ALTHOUGH, IT IS STILL POSSIBLE TO COMPILE THE FACTION IN THIS STATE," +
                        "IT MAY RESULT IN THE FACTION NOT LOADING IN-GAME. PLEASE MAKE SURE THAT ALL THE FIELDS" +
                        "HAVE BEEN SET UP CORRECTLY.\n");
                }
                Console.WriteLine("Are you sure you want to compile the Faction?");
                ConsoleKeyInfo input = Console.ReadKey();
                if(input.Key == ConsoleKey.Y)
                {
                    CompileFaction(OPFORFaction);
                    Console.WriteLine($"{OPFORFaction.FileName}.sqf has been exported.\n" +
                        $"Do note that if you had a custom opfor_ammobox_transport, you will need" +
                        $"to set the positions for the crates for this vehicle inside the config file." +
                        $"Press any key to continue.");
                    Console.ReadKey();
                    exit = true;
                } else if(input.Key == ConsoleKey.N)
                {
                    exit = true;
                }
            }
        }
        public static void CompileFaction(Models.OPFOR OPFORFaction)
        {
            string Compiled = "";
            foreach(var Soldier in OPFORFaction.InfantryList)
            {
                Compiled += Soldier.Compile() + "\n";
            }
            Compiled += "\n";
            foreach (var Object in OPFORFaction.SecondaryObjectives)
            {
                Compiled += Object.Compile() + "\n";
            }
            Compiled += "\n";
            Compiled += OPFORFaction.MilitiaSquad.Compile() + "\n";
            Compiled += OPFORFaction.MilitiaVehicles.Compile() + "\n";
            Compiled += OPFORFaction.Vehicles.Compile() + "\n";
            Compiled += OPFORFaction.VehiclesLowIntensity.Compile() + "\n";
            Compiled += OPFORFaction.BattlegroupVehicles.Compile() + "\n";
            Compiled += OPFORFaction.BattlegroupVehiclesLowIntensity.Compile() + "\n";
            Compiled += OPFORFaction.TroupTransport.Compile() + "\n";
            Compiled += OPFORFaction.Choppers.Compile() + "\n";
            Compiled += OPFORFaction.Planes.Compile() + "\n";
            File.WriteAllText(OPFORFaction.FileName + ".sqf", Compiled);
        }
    }
}
