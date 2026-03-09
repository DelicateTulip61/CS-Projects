using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Components;

namespace Ex03.GarageLogic
{
     public abstract class Car : Vehicle
    {
        private const int k_NumOfWheels = 5;
        private const float k_MaxWheelAirPressure = 33f;
        private eCarColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public eCarColor Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        protected Car (string i_LicensePlate, string i_ModelName)
        : base (i_LicensePlate, i_ModelName) 
        {
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel("Default", 0, k_MaxWheelAirPressure));
            }
        }

        public override void GetAllDetails()
        {
            base.GetAllDetails();
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Number of Doors: {NumberOfDoors}");
        }
    }
}
