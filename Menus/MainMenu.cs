using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Menus
{
    class MainMenu
    {
        public static void Draw()
        {
            Models.Menu Menu = new Models.Menu("Welcome to my cool little program!", true);
            Menu.Add("Faction Builder", (x) =>
            {
                Console.Clear();
                BuilderMenu.DrawMenu();
                return false;
            });
            Menu.Draw();
        }
    }
}
