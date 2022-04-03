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
            Tuple<string, Action<string>>[] Menu =
            {
                new Tuple<string, Action<string>>("OPFOR Creator", (x) =>
                {
                    Console.Clear();
                    BuilderMenu.DrawMenu();
                }),
                new Tuple<string, Action<string>>("Exit", (x) =>
                {
                    Environment.Exit(0);
                }),
            };
            bool exit = false;
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine("The following options are available:");
                for(int i = 0; i < Menu.Length; i++)
                {
                    Console.WriteLine($"[{i + 1}] {Menu[i].Item1}");
                }
                Console.WriteLine("\nPlease select an option:");

                input = Console.ReadLine();
                
                if(int.TryParse(input, out int id) && id - 1 >= 0 && id - 1 < Menu.Length)
                {
                    Menu[id - 1].Item2(Menu[id - 1].Item1);
                }
                if (input == "back" || input == "exit") exit = true;

            } while (exit == false);
        }
    }
}
