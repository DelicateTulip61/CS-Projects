
using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private float m_CurrentAmount;
        private float m_MaxAmount;

        protected EnergySource(float i_CurrentAmount, float i_MaxAmount)
        {
            if (i_CurrentAmount < 0)
            {
                throw new ArgumentException("Current Amount can't be negative!");
            }

            if (i_CurrentAmount + m_CurrentAmount > m_MaxAmount)
            {
                throw new ValueRangeException(m_MaxAmount, 0, "Amount to add exceeds maximum allowed.");
            }
            m_CurrentAmount = i_CurrentAmount;
            m_MaxAmount = i_MaxAmount;
        }

        public float CurrentAmount
        {
            get
            {
                return m_CurrentAmount;
            }
            protected set
            {
                m_CurrentAmount = value;
            }
        }
    
        public float MaxAmount
        {
            get
            {
                return m_MaxAmount; 
            }
        }  

        public void Fill(float i_AmountToAdd)
        {
            if (i_AmountToAdd < 0)
            {
                throw new ArgumentException("Amount to add must be postitive");
            }
            if (m_CurrentAmount + i_AmountToAdd > m_MaxAmount)
            {
                throw new ValueRangeException(m_MaxAmount, 0, "Amount to add exceeds maximum allowed.");
            }
            m_CurrentAmount += i_AmountToAdd;
        }
    }
}
