using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Menus
{
    class BuilderMenu
    {
        public static void DrawMenu()
        {
            Models.Menu menu = new Models.Menu("From this menu you can choose what kind of preset you wish to work on.");
            menu.Add("OPFOR Faction", (x) =>
            {
                Console.Clear();
                Builder.OPFOR.Main.Draw();
                return false;
            });
            menu.Draw();
        }
    }
}
