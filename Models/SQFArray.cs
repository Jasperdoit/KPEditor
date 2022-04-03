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
        public string Compile()
        {
            string contents = $"{this.Name} = [\n";
            for(int i = 0; i < Entries.Count - 1; i++)
            {
                contents += $"\t\"{this.Entries[i]}\",\n";
            }
            contents += $"\t\"{this.Entries[this.Entries.Count - 1]}\"\n";
            contents += $"];";
            return contents;
        }
    }
}
