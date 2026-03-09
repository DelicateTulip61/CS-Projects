using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Battery : EnergySource
    {

        public Battery(float i_CurrentAmount, float i_MaxAmount) : base(i_CurrentAmount, i_MaxAmount) { }

        public void Recharge (float i_AmountToAdd)
        {
            Fill(i_AmountToAdd);
        }

        public void GetElectricDetails()
        {
            Console.WriteLine($"Battery Capacity: {MaxAmount:F1} ");
            Console.WriteLine($"Current Charge: {CurrentAmount:F1} ");
            Console.WriteLine($"Remaining Time: {GetRemainingHours():F1} hours");
        }

        private float GetRemainingHours()
        {
            return (MaxAmount - CurrentAmount); 
        }
    }
}
