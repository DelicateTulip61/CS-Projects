using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Components;

namespace Ex03.GarageLogic.Concrete_Vehicles
{
    public class ElectricMotorcycle :Motorcycle
    {
        private const float k_BatteryCapacity = 2.6f;

        public ElectricMotorcycle(string i_LicensePlate, string i_ModelName)
            : base(i_LicensePlate, i_ModelName)
        {
            m_EnergySource = new Battery(0, k_BatteryCapacity);
        }
        public override void GetAllDetails()
        {
            base.GetAllDetails();  
            if (EnergySource is Battery battery)
            {
                Console.WriteLine("\n--- Battery Details ---");
                battery.GetElectricDetails();
            }
        }

    }
}
