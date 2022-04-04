using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Builder.OPFOR
{
    class MilitaryVehicles
    {
        public static void Draw(Models.OPFOR OPFORFaction)
        {
            Models.Menu menu = new Models.Menu();
            menu.Add("High Alert Vehicles", x =>
            {
                Console.Clear();
                OPFORFaction.Vehicles.Input("Please add your High Alert Vehicle entries");
                return false;
            });
            menu.Add("Low Alert Vehicles", x =>
            {
                Console.Clear();
                OPFORFaction.VehiclesLowIntensity.Input("Please add your Low Alert Vehicle entries");
                return false;
            });
            menu.Add("Planes", x =>
            {
                Console.Clear();
                OPFORFaction.Planes.Input("Please add your Plane entries");
                return false;
            });
            menu.Draw();
        }
    }
}
