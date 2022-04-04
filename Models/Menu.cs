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
        public Menu(string Introduction = "", bool IsExit = false)
        {
            this.Introduction = Introduction;
            this.MenuOptions = new List<MenuOption>();
            if(IsExit)
            {
                this.MenuOptions.Add(new MenuOption("Exit", (x) =>
                {
                    return true;
                }));
            } else
            {
                this.MenuOptions.Add(new MenuOption("Back", (x) =>
                {
                    return true;
                }));
            }
            
        }
        public void Add(string Name, Func<string, bool> Fun)
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
                if (this.Introduction != "")
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

                if (int.TryParse(input, out int id) && id == MenuOptions.Count)
                {
                    exit = true;
                }
                else if (int.TryParse(input, out int id2) && id2 - 1 >= 0 && id2 - 1 < this.MenuOptions.Count)
                {
                    this.MenuOptions[id - 1].Fun(id.ToString());
                }

            } while (exit == false);
        }
    }
    class MenuOption
    {
        public string Name;
        public Func<string, bool> Fun;
        public MenuOption(string Name, Func<string, bool> Fun)
        {
            this.Name = Name;
            this.Fun = Fun;
        }
    }
}
