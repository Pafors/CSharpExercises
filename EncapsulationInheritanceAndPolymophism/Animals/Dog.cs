using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism.Animals
{
    internal class Dog : Animal
    {
        public string SpecialitySkill { get; set; }
        public override void DoSound()
        {
            Console.WriteLine("woofs");
        }

        public override string Stats()
        {
            return $"{base.Stats()}, Speciality skill: {SpecialitySkill}";
        }

        public string Whatever()
        {
            return "Can you see this?";
        }
        public Dog(string name, string shortDescription, int age, int weight, string specialitySkill) : base(name, shortDescription, age, weight)
        {
            SpecialitySkill = specialitySkill;
        }
    }
}
