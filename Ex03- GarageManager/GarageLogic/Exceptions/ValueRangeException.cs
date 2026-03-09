using System;

namespace Ex03.GarageLogic.Exceptions
{
    internal class ValueRangeException : Exception
    {
        public float MaxValue
        {
            get;
        }
        public float MinValue
        {
            get;
        }

        public ValueRangeException(float i_MaxValue, float i_MinValue, string i_Message)
            : base(i_Message)
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }
    }
}
