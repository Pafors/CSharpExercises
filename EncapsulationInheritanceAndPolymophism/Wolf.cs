using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism
{
    internal class Wolf : Animal
    {
        public string HierarchyPosition { get; set; }
        public override void DoSound()
        {
            Console.WriteLine("howls");
        }

        public override string Stats()
        {
            return $"{base.Stats()}, Hierarchy position: {HierarchyPosition}";
        }

        public Wolf(string name, string shortDescription, int age, int weight, string hierarchyPosition) : base(name, shortDescription, age, weight)
        {
            HierarchyPosition = hierarchyPosition;
        }

    }
}
