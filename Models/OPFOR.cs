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
        public List<OPFORSoldier> InfantryList;
        public SQFArray MilitiaSquad;
        public SQFArray MilitiaVehicles;
        public SQFArray Vehicles;
        public SQFArray VehiclesLowIntensity;
        public SQFArray BattlegroupVehicles;
        public SQFArray BattlegroupVehiclesLowIntensity;
        public SQFArray TroupTransport;
        public SQFArray Choppers;
        public SQFArray Planes;

        public void InfantryListBuilder()
        {
            this.InfantryList.Add(new OPFORSoldier("opfor_officer", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_squad_leader", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_team_leader", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_sentry", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_rifleman", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_rpg", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_grenadier", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_machinegunner", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_heavygunner", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_marksman", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_sharpshooter", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_sniper", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_at", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_aa", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_medic", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_engineer", ""));
            this.InfantryList.Add(new OPFORSoldier("opfor_paratrooper", ""));
        }
        public OPFOR(string FileName)
        {
            this.FileName = FileName;
            this.InfantryList = new List<OPFORSoldier>(); InfantryListBuilder();
            this.MilitiaSquad = new SQFArray("militia_squad");
            this.MilitiaVehicles = new SQFArray("militia_vehicles");
            this.Vehicles = new SQFArray("opfor_vehicles");
            this.VehiclesLowIntensity = new SQFArray("opfor_vehicles_low_intensity");
            this.BattlegroupVehicles = new SQFArray("opfor_battlegroup_vehicles");
            this.BattlegroupVehiclesLowIntensity = new SQFArray("opfor_battlegroup_vehicles_low_intensity");
            this.TroupTransport = new SQFArray("opfor_troup_transports");
            this.Choppers = new SQFArray("opfor_choppers");
            this.Planes = new SQFArray("opfor_air");
        }
    }
}
