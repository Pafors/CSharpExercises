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

                        if (fullname == "" || salary == "" || !salary.All(Char.IsDigit))
                        {
                            Console.WriteLine("*INFO* Namn eller lön saknar riktig data, ingen ny post läggs till");
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
                        if (Employees.Count == 0)
                        {
                            Console.WriteLine("(registret är tomt)");
                        }
                        else
                        {
                            foreach (var employee in Employees)
                            {
                                Console.WriteLine("NAMN: {0}, LÖN: {1}", employee.Fullname, employee.Salary.ToString());
                            }
                        }
                        Console.WriteLine("");
                        break;

                    case "3":
                        Console.WriteLine("Är du säker (j/n)?");
                        string konfirmeraAvslut = Console.ReadLine();
                        if (konfirmeraAvslut.ToLower() == "j")
                        {
                            aktiv = false;
                        }
                        break;

                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Ogiltigt val, försök igen");
                        Console.WriteLine("");
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
            this.salary = Int32.Parse(salary); // Ingen koll för värden större än vad "int" klarar av
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