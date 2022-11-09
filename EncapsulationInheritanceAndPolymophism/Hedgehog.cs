using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism
{
    internal class Hedgehog : Animal
    {
        public int NrOfSpikes { get; set; }
        public override void DoSound()
        {
            Console.WriteLine("grunts");
        }

        public override string Stats()
        {
            return $"{base.Stats()}, Number of spikes: {NrOfSpikes}";
        }
        public Hedgehog(string name, string shortDescription, int age, int weight, int nrOfSpikes) : base(name, shortDescription, age, weight)
        {
            NrOfSpikes = nrOfSpikes;
        }
    }
}
