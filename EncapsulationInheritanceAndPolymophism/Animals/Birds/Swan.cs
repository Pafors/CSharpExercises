using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism.Animals.Birds
{
    internal class Swan : Bird
    {
        public string NestingLocation { get; set; }
        public override string Stats()
        {
            return $"{base.Stats()}, Nesting location: {NestingLocation}";
        }
        public Swan(string name, string shortDescription, int age, int weight, int wingSpan, string nestingLocation) : base(name, shortDescription, age, weight, wingSpan)
        {
            NestingLocation = nestingLocation;
        }
    }
}
