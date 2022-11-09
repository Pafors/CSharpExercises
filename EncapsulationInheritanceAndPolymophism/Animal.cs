using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism
{
    abstract class Animal
    {
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Weight { get; set; }

        public abstract void DoSound();

        public virtual string Stats()
        {
            return $"Name:{Name}, Short descr:{ShortDescription}, Age:{Age}, Weight:{Weight}";
        }

        public Animal(string name, string shortDescription, int age, int weight)
        {
            Name = name;
            ShortDescription = shortDescription;
            Age = age;
            Weight = weight;
        }
    }
}
