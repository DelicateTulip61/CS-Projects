using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Components;

namespace Ex03.GarageLogic.Vehicle_Categories
{
    public abstract class Truck : Vehicle
    {
        private const int k_NumOfWheels = 12;
        private const float k_MaxWheelAirPressure = 26f;
        private bool m_IsDangerous;
        private float m_CargoVolume;

        protected Truck(string i_LicensePlate, string i_ModelName)
                        : base(i_LicensePlate, i_ModelName)
        {

            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel("Default", 0, k_MaxWheelAirPressure));
            }
        }

        public bool IsDangerous
        {
            get 
            { 
                return m_IsDangerous; 
            }
            set 
            { 
                m_IsDangerous = value; 
            }
        }

        public float CargoVolume
        {
            get 
            { 
                return m_CargoVolume; 
            }
            set 
            { 
                m_CargoVolume = value; 
            }
        }


        public override void GetAllDetails()
        {
            base.GetAllDetails();
            Console.WriteLine($"Is Dangerous: {IsDangerous}");
            Console.WriteLine($"Cargo Volume: {CargoVolume:F1}");
        }
    }
}
