using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Components
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }
            set
            {
                m_Manufacturer = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            private set
            {
                m_MaxAirPressure = value;
            }
        }

        public void Inflate(float i_AirToAdd)
        {
            if (i_AirToAdd < 0)
            {
                throw new ArgumentException("Air to add must be postitive");
            }
            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ValueRangeException(m_MaxAirPressure, 0, "Air pressure exceeds maximum allowed.");
            }
            m_CurrentAirPressure += i_AirToAdd;
        }

        public void InflateToMax()
        {
            Inflate(MaxAirPressure - CurrentAirPressure);
        }
    }
}