﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism
{
    internal class Worm : Animal
    {
        public int Length { get; set; }
        public override void DoSound()
        {
            Console.WriteLine("silent");
        }
        public override string Stats()
        {
            return $"{base.Stats()}, Length: {Length}";
        }
        public Worm(string name, string shortDescription, int age, int weight, int length) : base(name, shortDescription, age, weight)
        {
            Length = length;
        }

    }
}
