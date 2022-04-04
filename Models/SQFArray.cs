using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Models
{
    class SQFArray
    {
        public string Name;
        public List<string> Entries;
        public SQFArray(string Name)
        {
            this.Name = Name;
            this.Entries = new List<string>();
        }
        public void AddEntry(string Entry)
        {
            Entries.Add(Entry);
        }
        public void AddEntries(List<string> Entries)
        {
            this.Entries.AddRange(Entries);
        }
        public void ClearEntries()
        {
            this.Entries.Clear();
        }
        public void RemoveEntry(string Entry)
        {
            if (this.Entries.Contains(Entry))
            {
                this.Entries.Remove(Entry);
            }
        }
        public int Count()
        {
            return this.Entries.Count();
        }
        public void RemoveLast()
        {
            if (this.Entries.Last() != null)
            this.Entries.RemoveAt(this.Entries.Count() - 1);
        }
        public bool IsEmpty()
        {
            return this.Count() == 0;
        }

        public void Input(string Introduction = "")
        {
            bool exit = false;
            string input = "";
            while (!exit)
            {
                Console.Clear();
                if(Introduction != "")
                {
                    Console.WriteLine(Introduction);
                }
                Console.WriteLine("Write \"del\" if you wish to remove an entry.");
                Console.WriteLine("Write \"clear\" to clear all entries.");
                Console.WriteLine("Write \"back\" to go back to the previous menu.\n");
                Console.Write(this.Name + " = [\n");
                for (int i = 0; i < this.Count() - 1; i++)
                {
                    Console.WriteLine("\t\"" + this.Entries[i] + "\",");
                }
                if (this.Count() > 0)
                {
                    Console.WriteLine("\t\"" + this.Entries[this.Count() - 1] + "\"");

                }
                Console.Write("];\nYour input: ");
                input = Console.ReadLine();
                if (input.ToLower() == "back")
                {
                    exit = true;
                }
                else if (input.ToLower() == "del" && this.Count() > 0)
                {
                    this.RemoveLast();
                }
                else if (input.ToLower() == "clear" && this.Count() > 0)
                {
                    this.Entries.Clear();
                }
                else
                {
                    this.AddEntry(input);
                }
            }
        }

        public string Compile()
        {
            string contents = $"{this.Name} = [\n";
            for(int i = 0; i < Entries.Count - 1; i++)
            {
                contents += $"\t\"{this.Entries[i]}\",\n";
            }
            if (this.Entries.Count > 0)
            {
                contents += $"\t\"{this.Entries[this.Entries.Count - 1]}\"\n";
            }
            contents += $"];";
            return contents;
        }
    }
}
