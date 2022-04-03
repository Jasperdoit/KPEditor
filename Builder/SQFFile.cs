using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace KPEditor.Builder
{
    class SQFFile
    {
        public static void Write(string Filename, string Contents)
        {
            File.WriteAllText(Filename + ".sqf", Contents);
        }
        public static string Read(string Filename)
        {
            if (File.Exists(Filename + ".sqf")) {
                return File.ReadAllText(Filename + ".sqf");
            }
            return null;
        }
    }
}
