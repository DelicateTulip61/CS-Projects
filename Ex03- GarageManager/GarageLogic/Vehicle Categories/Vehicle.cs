using Ex03.GarageLogic.Components;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
     public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseID;
        private float m_EnergyPercentage;
        private List<Wheel> m_Wheels;
        protected EnergySource m_EnergySource;


        public Vehicle(string i_LicenseID, string i_ModelName)
        {
            m_LicenseID = i_LicenseID;
            m_ModelName = i_ModelName;
            m_Wheels = new List<Wheel>();
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseID
        {
            get
            {
                return m_LicenseID;
            }
            set
            {
                m_LicenseID = value;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return (EnergySource.CurrentAmount / EnergySource.MaxAmount) * 100;
            }
            set
            {
                m_EnergyPercentage = value;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }

        public void InflateAllWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public void SetWheelsDetails(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.Manufacturer = i_ManufacturerName;
                wheel.CurrentAirPressure = i_CurrentAirPressure;
            }
        }


        public virtual void GetAllDetails()
        {
            Console.WriteLine($"Number of Wheels: {Wheels.Count}");

            Console.WriteLine("\n--- Wheels Details ---");
            for (int i = 0; i < Wheels.Count; i++)
            {
                Console.WriteLine($"Wheel {i + 1}:");
                Console.WriteLine($"  Manufacturer: {Wheels[i].Manufacturer}");
                Console.WriteLine($"  Current Air Pressure: {Wheels[i].CurrentAirPressure:F1}");
                Console.WriteLine($"  Max Air Pressure: {Wheels[i].MaxAirPressure:F1}");
            }

            Console.WriteLine($"\nEnergy Source: {EnergySource.CurrentAmount:F1}/{EnergySource.MaxAmount:F1}");
        }

    }
}
