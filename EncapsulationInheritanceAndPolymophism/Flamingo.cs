using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism
{
    internal class Flamingo : Bird
    {
        public int NeckLength { get; set; }

        public override string Stats()
        {
            return $"{base.Stats()}, Necklength: {NeckLength}";
        }
        public Flamingo(string name, string shortDescription, int age, int weight, int wingSpan, int neckLength) : base(name, shortDescription, age, weight, wingSpan)
        {
            NeckLength = neckLength;
        }

    }
}
