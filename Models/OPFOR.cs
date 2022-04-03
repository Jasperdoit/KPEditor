using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPEditor.Models
{
    class OPFOR
    {
        public string FileName;
        public List<string> MilitiaSquad;
        public List<string> MilitiaVehicles;
        public List<string> Vehicles;
        public List<string> VehiclesLowIntensity;
        public List<string> BattlegroupVehicles;
        public List<string> BattlegroupVehiclesLowIntensity;
        public List<string> TroupTransport;
        public List<string> Choppers;
        public List<string> Planes;
        public OPFOR(string FileName)
        {
            this.FileName = FileName;
            this.MilitiaSquad = new List<string>();
            this.MilitiaVehicles = new List<string>();
            this.Vehicles = new List<string>();
            this.VehiclesLowIntensity = new List<string>();
            this.BattlegroupVehicles = new List<string>();
            this.BattlegroupVehiclesLowIntensity = new List<string>();
            this.TroupTransport = new List<string>();
            this.Choppers = new List<string>();
            this.Planes = new List<string>();
        }
    }
}
