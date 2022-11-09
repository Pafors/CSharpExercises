using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism.Animals.Birds
{
    internal class Bird : Animal
    {
        public int WingSpan { get; set; }
        public Bird(string name, string shortDescription, int age, int weight, int wingSpan) : base(name, shortDescription, age, weight)
        {
            WingSpan = wingSpan;
        }

        public override string Stats()
        {
            return $"{base.Stats()}, Wingspan: {WingSpan} cm";
        }
        public override void DoSound()
        {
            Console.WriteLine("sings");
        }
    }
}
