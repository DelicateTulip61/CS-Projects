using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelTank : EnergySource
    {
        eFuelType m_FuelType;


        public FuelTank(float i_CurrentAmount, float i_MaxAmount, eFuelType i_FuelType) 
            : base(i_CurrentAmount, i_MaxAmount)
        { 
            m_FuelType = i_FuelType;
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public void Refuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            if (m_FuelType != i_FuelType)
            {
                throw new ArgumentException("Fuel Type selected does not match the Vehicle's Fuel Type!");
            }
            else
            {
                Fill(i_AmountToAdd);
            }
        }

        public void GetFuelDetails()
        {
            Console.WriteLine($"Fuel Type: {m_FuelType}");
            Console.WriteLine($"Current Fuel: {CurrentAmount:F1} liters");
            Console.WriteLine($"Tank Capacity: {MaxAmount:F1} liters");
        }
    }
}
