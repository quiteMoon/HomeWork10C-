using System.Text;

namespace HomeWork10C_
{
    internal class Program
    {
        public class Employee
        {
            public string FullName { get; set; }
            public string Position { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public decimal Salary { get; set; }
        }

        public class Firm
        {
            public string Name { get; set; }
            public DateTime FoundedDate { get; set; }
            public string BusinessProfile { get; set; }
            public string Director { get; set; }
            public int EmployeeCount => Employees.Count;
            public string Address { get; set; }
            public List<Employee> Employees { get; set; } = new List<Employee>();
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = UTF8Encoding.UTF8;
            Console.OutputEncoding = UTF8Encoding.UTF8;

            var firms = new List<Firm>
        {
            new Firm
            {
                Name = "FoodTech",
                FoundedDate = DateTime.Now.AddYears(-3),
                BusinessProfile = "Marketing",
                Director = "John White",
                Address = "London",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Lionel Messi", Position = "Manager", Phone = "231234567", Email = "lionel@foodtech.com", Salary = 5000 },
                    new Employee { FullName = "Diego Maradona", Position = "Developer", Phone = "245678901", Email = "diego@foodtech.com", Salary = 4000 },
                }
            },
            new Firm
            {
                Name = "WhiteFood",
                FoundedDate = DateTime.Now.AddYears(-1),
                BusinessProfile = "IT",
                Director = "Mary Black",
                Address = "New York",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Cristiano Ronaldo", Position = "Manager", Phone = "231111111", Email = "cristiano@whitefood.com", Salary = 7000 },
                    new Employee { FullName = "Lionel Messi", Position = "Developer", Phone = "238765432", Email = "lionel@whitefood.com", Salary = 5500 },
                }
            },
            new Firm
            {
                Name = "ITPro",
                FoundedDate = DateTime.Now.AddYears(-5),
                BusinessProfile = "IT",
                Director = "Anna Smith",
                Address = "London",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Lionel Messi", Position = "Developer", Phone = "237654321", Email = "lionel@itpro.com", Salary = 6000 },
                    new Employee { FullName = "David Beckham", Position = "Manager", Phone = "236543210", Email = "david@itpro.com", Salary = 7000 },
                }
            },
            new Firm { Name = "MarketingGuru", FoundedDate = DateTime.Now.AddYears(-4), BusinessProfile = "Marketing", Director = "Peter White", Address = "Chicago" },
            new Firm { Name = "FinanceExperts", FoundedDate = DateTime.Now.AddYears(-6), BusinessProfile = "Finance", Director = "Emma Green", Address = "London" }
        };

            var allFirms = firms.Select(f => f);
            var foodFirms = firms.Where(f => f.Name.Contains("Food"));
            var marketingFirms = firms.Where(f => f.BusinessProfile == "Marketing");
            var marketingOrITFirms = firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT");
            var largeFirms = firms.Where(f => f.EmployeeCount > 100);
            var mediumSizedFirms = firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300);
            var londonFirms = firms.Where(f => f.Address == "London");
            var whiteDirectors = firms.Where(f => f.Director.Split(' ').Last() == "White");
            var olderThanTwoYears = firms.Where(f => (DateTime.Now - f.FoundedDate).TotalDays > 730);
            var exactly123DaysOld = firms.Where(f => (DateTime.Now - f.FoundedDate).TotalDays == 123);
            var blackDirectorAndWhiteName = firms.Where(f => f.Director.Split(' ').Last() == "Black" && f.Name.Contains("White"));

            var firmName = "FoodTech";
            var employeesOfFirm = firms.Where(f => f.Name == firmName).SelectMany(f => f.Employees);
            decimal salaryThreshold = 4500;
            var highSalaryEmployees = firms.Where(f => f.Name == firmName).SelectMany(f => f.Employees).Where(e => e.Salary > salaryThreshold);
            var managers = firms.SelectMany(f => f.Employees).Where(e => e.Position == "Manager");
            var phoneStartsWith23 = firms.SelectMany(f => f.Employees).Where(e => e.Phone.StartsWith("23"));
            var emailStartsWithDi = firms.SelectMany(f => f.Employees).Where(e => e.Email.StartsWith("di", StringComparison.OrdinalIgnoreCase));
            var lionelEmployees = firms.SelectMany(f => f.Employees).Where(e => e.FullName.Contains("Lionel"));

            Console.WriteLine("Фірми з назвою, що містить 'Food':");
            foreach (var firm in foodFirms) Console.WriteLine(firm.Name);

            Console.WriteLine("\nМенеджери:");
            foreach (var emp in managers) Console.WriteLine(emp.FullName);

            Console.WriteLine("\nПрацівники з ім'ям Lionel:");
            foreach (var emp in lionelEmployees) Console.WriteLine(emp.FullName);
        }
    }
}
