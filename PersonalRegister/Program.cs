namespace PersonalRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Employees = new List<Employee>();
            bool aktiv = true;
            while (aktiv)
            {


                Console.WriteLine("== Personal registret ==");
                Console.WriteLine("(1) Skriv in post");
                Console.WriteLine("(2) Visa alla registerposter");
                Console.WriteLine("(3) Avsluta");
                Console.WriteLine("");
                Console.Write("Ditt val: ");
                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        Console.Write("Fullständigt namn: ");
                        string fullname = Console.ReadLine();

                        Console.Write("Lön: ");
                        string salary = Console.ReadLine();

                        if (fullname == "" || salary == "")
                        {
                            Console.WriteLine("Information saknas, ingen ny post läggs till");
                        }
                        else
                        {
                            var employee = new Employee(fullname, salary);
                            Employees.Add(employee);
                        }
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");

                        foreach (var employee in Employees)
                        {
                            Console.WriteLine("NAMN: {0}, LÖN: {1}", employee.Fullname, employee.Salary);
                        }
                        break;
                    case "3":
                        aktiv = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen");
                        break;
                }
            }





        }
    }

    internal class Employee
    {
        private string? fullname;
        private int salary;

        public Employee(string? fullname, string salary)
        {
            this.fullname = fullname;
            this.salary = Int32.Parse(salary);
        }

        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

    }
}