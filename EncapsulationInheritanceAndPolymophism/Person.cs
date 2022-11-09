using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationInheritanceAndPolymophism
{
    internal class Person
    {
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                try
                {
                    if (value > 0) { age = value; }
                    else
                    {
                        throw new ArgumentException("Age kan bara tilldelas ett värde större än 0");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private string fName = String.Empty;
        public string FName
        {
            get { return fName; }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 10)
                    {
                        throw new ArgumentException("FName är obligatorisk och får inte vara mindre än 2 tecken eller längre än 10 tecken");
                    }
                    else
                    {
                        fName = value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private string lName = String.Empty;

        public string LName
        {
            get { return lName; }
            set
            {
                try
                {
                    if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 15)
                    {
                        throw new ArgumentException("LName är obligatorisk och får inte vara mindre än 3 tecken eller större än 15 tecken");
                    }
                    else
                    {
                        lName = value;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public double Height { get; set; }
        public double Weight { get; set; }

        public Person(int age, string fname, string lname, double height = 0, double weight = 0)
        {
            Age = age;
            FName = fname;
            LName = lname;
            Height = height;
            Weight = weight;
        }


    }
}
