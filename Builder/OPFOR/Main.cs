using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Builder.OPFOR
{
    class Main
    {
        public static void Draw()
        {
            // Add rename capabilities!!!
            string input = "";
            do
            {
                Console.WriteLine("Please give your faction file a name. This filename must not contain any spaces.");
                input = Console.ReadLine();
            } while (input == "" && input.Contains(" "));
            Models.OPFOR OPFORFaction = new Models.OPFOR(input);
            Models.Menu menu = new Models.Menu("From this menu you can select what you want to edit for a new faction!");
            menu.Add("Military", (x) =>
            {
                Console.Clear();
                Military.Draw(OPFORFaction);
                return false;
            });
            menu.Add("Militia", (x) =>
            {
                Console.Clear();
                Militia.Draw(OPFORFaction);
                return false;
            });
            menu.Add("BattleGroup", (x) =>
            {
                Console.Clear();
                Battlegroup.Draw(OPFORFaction);
                return false;
            });
            menu.Add("Rename", (x) =>
            {
                Console.Clear();
                Rename.Draw(OPFORFaction);
                return false;
            });
            menu.Add("Compile", (x) =>
            {
                Console.Clear();
                Compile.Draw(OPFORFaction);
                return false;
            });
            menu.Draw();
        }
    }
}
