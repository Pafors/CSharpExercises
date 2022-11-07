using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwoFlowLoopsAndStringManipulation
{
    internal class Ticket
    {
        private string category = "";

        public string Category
        {
            get { return category; }
            private set { category = value; }
        }

        private uint price;
        public uint Price
        {
            get { return price; }
            private set { price = value; }
        }

        protected virtual void DeterminePrice(uint age)
        {
            if (age < 5 || age > 100)
            {
                Category = "Fritt inträde";
                Price = 0;
            }
            else if (age < 20)
            {
                Category = "Ungdomspris";
                Price = 80;
            }
            else if (age > 64)
            {
                Category = "Pensionärspris";
                Price = 90;
            }
            else
            {
                Category = "Standardpris";
                Price = 120;
            }
        }

        public Ticket(uint age)
        {
            DeterminePrice(age);
        }
    }
}
