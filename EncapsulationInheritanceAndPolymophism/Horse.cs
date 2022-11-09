using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism
{
    internal class Horse: Animal
    {
        public bool IsTrained { get; set; }
        public override void DoSound()
        {
            Console.WriteLine("neighs");
        }
        public override string Stats()
        {
            return $"{base.Stats()}, Is trained: {IsTrained}";
        }
        public Horse(string name, string shortDescription, int age, int weight, bool isTrained = false) : base(name, shortDescription, age, weight)
        {
            IsTrained = isTrained;
        }
    }
}
