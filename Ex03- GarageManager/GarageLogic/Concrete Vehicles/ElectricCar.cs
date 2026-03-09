using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Components;

namespace Ex03.GarageLogic.Concrete_Vehicles
{
     public class ElectricCar : Car
    {
        private const float k_BatteryCapacity = 4.2f;

        public ElectricCar(string i_LicensePlate, string i_ModelName)
            : base (i_LicensePlate, i_ModelName) 
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
