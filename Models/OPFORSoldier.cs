using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Models
{
    class OPFORSoldier
    {
        public string Type;
        public string Classname;
        public OPFORSoldier(string Type, string Classname)
        {
            this.Type = Type;
            this.Classname = Classname;
        }
        public void SetClassname(string Classname)
        {
            this.Classname=Classname;
        }
        public string Compile()
        {
            return $"{this.Type} = \"{this.Classname}\";";
        }
    }
}
