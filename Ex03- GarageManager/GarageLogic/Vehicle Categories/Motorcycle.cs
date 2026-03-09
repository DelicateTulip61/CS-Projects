using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Components;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumOfWheels = 2;
        private const float k_MaxWheelAirPressure = 29f;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public eLicenseType LicenseType
        {
            get 
            { 
                return m_LicenseType; 
            }
            set 
            { 
                m_LicenseType = value; 
            }
        }

        public int EngineVolume
        {
            get 
            { 
                return m_EngineVolume; 
            }
            set 
            { 
                m_EngineVolume = value; 
            }
        }

        protected Motorcycle(string i_LicensePlate, string i_ModelName)
        : base(i_LicensePlate, i_ModelName)
        {
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                Wheels.Add(new Wheel("Default", 0, k_MaxWheelAirPressure));
            }
        }

        public override void GetAllDetails()
        {
            base.GetAllDetails();
            Console.WriteLine($"License Type: {LicenseType}");
            Console.WriteLine($"Engine Volume: {EngineVolume}");
        }
    }
}
