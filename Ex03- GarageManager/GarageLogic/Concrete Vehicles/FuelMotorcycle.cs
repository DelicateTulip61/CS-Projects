using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Components;

namespace Ex03.GarageLogic.Concrete_Vehicles
{
    public class FuelMotorcycle : Motorcycle
    {
        private const float k_TankCapacity = 6.8f;
        private const eFuelType k_FuelType = eFuelType.Octan98;

        public FuelMotorcycle(string i_LicensePlate, string i_ModelName)
                    : base(i_LicensePlate, i_ModelName)
        {
            m_EnergySource = new FuelTank(0, k_TankCapacity, k_FuelType);
        }

        public override void GetAllDetails()
        {
            base.GetAllDetails();
            if (EnergySource is FuelTank fuelTank)
            {
                Console.WriteLine("\n--- Fuel Tank Details ---");
                fuelTank.GetFuelDetails();
            }
        }


    }
}
