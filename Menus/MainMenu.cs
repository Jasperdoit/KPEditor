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
            Models.Menu Menu = new Models.Menu("Welcome to my cool little program!");
            Menu.Add("OPFOR Builder", (x) =>
            {
                Console.Clear();
                Menus.BuilderMenu.DrawMenu();
            });
            Menu.Draw();
        }
    }
}
