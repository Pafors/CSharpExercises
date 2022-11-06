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

        public Ticket(uint age)
        {
            if (age < 5 || age > 100)
            {
                Category = "Fritt inträde";
                price = 0;
            }
            else if (age < 20)
            {
                Category = "Ungdomspris";
                price = 80;
                //Console.WriteLine("Ungdomspris: 80 kr");
            }
            else if (age > 64)
            {
                Category = "Pensionärspris";
                Price = 90;
                //Console.WriteLine("Pensionärspris: 90 kr");
            }
            else
            {
                Category = "Standardpris";
                Price = 120;
                //Console.WriteLine("Standardpris: 120 kr");
            }
            Category = category;
            Price = price;
        }
    }
}
