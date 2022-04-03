using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Models
{
    class Menu
    {
        public List<MenuOption> MenuOptions;
        public string Introduction;
        public Menu(string Introduction = "")
        {
            this.Introduction = Introduction;
            this.MenuOptions = new List<MenuOption>();
            this.MenuOptions.Add(new MenuOption("Exit", (x) =>
            {
                Environment.Exit(0);
                return;
            }));
        }
        public void Add(string Name, Action<string> Fun)
        {
            MenuOption temp = this.MenuOptions[this.MenuOptions.Count - 1];
            this.MenuOptions.RemoveAt(this.MenuOptions.Count - 1);
            this.MenuOptions.Add(new MenuOption(Name, Fun));
            this.MenuOptions.Add(temp);
        }
        public void Draw()
        {
            bool exit = false;
            string input = "";
            do
            {
                Console.Clear();
                if(this.Introduction != "")
                {
                    Console.WriteLine(Introduction + "\n");
                }
                Console.WriteLine("The following options are available:");
                for (int i = 0; i < this.MenuOptions.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {this.MenuOptions[i].Name}");
                }
                Console.WriteLine("\nPlease select an option:");

                input = Console.ReadLine();

                if (int.TryParse(input, out int id) && id - 1 >= 0 && id - 1 < this.MenuOptions.Count)
                {
                    this.MenuOptions[id - 1].Fun(id.ToString());
                }

            } while (exit == false);
        }
    }
    class MenuOption
    {
        public string Name;
        public Action<string> Fun;
        public MenuOption(string Name, Action<string> Fun)
        {
            this.Name = Name;
            this.Fun = Fun;
        }
    }
}
