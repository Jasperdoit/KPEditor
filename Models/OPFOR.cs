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
        public List<SQFEntry> SecondaryObjectives;

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
            this.SecondaryObjectives = new List<SQFEntry>();
                this.SecondaryObjectives.Add(new SQFEntry("opfor_mrap", "O_MRAP_02_F"));
                this.SecondaryObjectives.Add(new SQFEntry("opfor_mrap_armed", "O_MRAP_02_hmg_F"));
                this.SecondaryObjectives.Add(new SQFEntry("opfor_transport_helo", "O_Heli_Transport_04_bench_F"));
                this.SecondaryObjectives.Add(new SQFEntry("opfor_transport_truck", "O_Truck_03_covered_F"));
                this.SecondaryObjectives.Add(new SQFEntry("opfor_ammobox_transport", "O_Truck_03_transport_F"));
                this.SecondaryObjectives.Add(new SQFEntry("opfor_fuel_truck", "O_Truck_03_fuel_F"));
                this.SecondaryObjectives.Add(new SQFEntry("opfor_ammo_truck", "O_Truck_03_ammo_F"));
                this.SecondaryObjectives.Add(new SQFEntry("opfor_fuel_container", "Land_Pod_Heli_Transport_04_fuel_F"));
                this.SecondaryObjectives.Add(new SQFEntry("opfor_ammo_container", "Land_Pod_Heli_Transport_04_ammo_F"));
                this.SecondaryObjectives.Add(new SQFEntry("opfor_flag", "Flag_CSAT_F"));
        }
    }
}
