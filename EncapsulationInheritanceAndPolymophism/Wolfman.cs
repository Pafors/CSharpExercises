using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism
{
    internal class Wolfman : Wolf, IPerson
    {
        public int YearsLivingWithWolfs { get; set; }
        public void Talk(string sentence)
        {
            Console.WriteLine($"{sentence}");
        }

        public override string Stats()
        {
            return $"{base.Stats()}, Years living with wolfs: {YearsLivingWithWolfs}";
        }

        public Wolfman(string name, string shortDescription, int age, int weight, string hierarchyPosition, int yearsLivingWithWolfs) : base(name, shortDescription, age, weight, hierarchyPosition)
        {
            YearsLivingWithWolfs = yearsLivingWithWolfs;
        }

    }
}
