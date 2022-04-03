using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Models
{
    class SQFEntry
    {
        public string Name;
        public string Entry;
        public SQFEntry(string Name, string Entry)
        {
            this.Name = Name;
            this.Entry = Entry;
        }
        public string Compile()
        {
            return $"{this.Name} = \"{this.Entry}\";";
        }
    }
}
