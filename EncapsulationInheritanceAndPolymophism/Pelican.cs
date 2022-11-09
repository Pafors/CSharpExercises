using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism
{
    internal class Pelican : Bird
    {
        public int BeakVolume { get; set; }
        public override string Stats()
        {
            return $"{base.Stats()}, Beak volume: {BeakVolume}";
        }
        public Pelican(string name, string shortDescription, int age, int weight, int wingSpan, int beakVolume) : base(name, shortDescription, age, weight, wingSpan)
        {
            BeakVolume = beakVolume;
        }
    }
}
