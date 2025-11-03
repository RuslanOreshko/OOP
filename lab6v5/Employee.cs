using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;


namespace Lab6v5
{
    // Клас є моделю даних.
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string position, int salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }
    }

    // Власний делегат.
    delegate bool SalaryCheck(double salary);

    class Program
    {
        static void Main()
        {
            // Колекція об'ктів класу.
            List<Employee> employees = new List<Employee>
            {
                new Employee("Руслан", "Бекенд розробник", 10001),
                new Employee("Олексій", "Тестувальник", 20000),
                new Employee("Іван", "Підприємець", 12000),
                new Employee("Крістіна", "Дизайнер", 9000),
            };

            // Власний і анонімний делегат. перевірка чи зарплата більше за 10к.
            SalaryCheck hightSalary = delegate (double s)
            {
                return s > 10000;
            };

            // Вивід працівників із зп більш 10к в консоль.
            Console.WriteLine("Працівники із зп більше 10к:");
            foreach (var emp in employees)
            {
                if (hightSalary(emp.Salary))
                {
                    Console.WriteLine($"{emp.Name} - {emp.Position} - {emp.Salary}");
                }
            }

            Console.WriteLine();

            // Вбудований делегат Func. Вибирає працівників із зп меншою за 10к.
            Func<Employee, bool> lowSalary = e => e.Salary <= 10000;
            Console.WriteLine("зп ниже 10к:");
            foreach (var emp in employees.Where(lowSalary))
            {
                Console.WriteLine($"{emp.Name} - {emp.Position} - {emp.Salary}");
            }

            Console.WriteLine();

            // Вбудований делегат Action, виводить всіх працівників.
            Action<Employee> printEmployees = e =>
                Console.WriteLine($"{e.Name} | {e.Position} | {e.Salary}");
            Console.WriteLine("Вивід усіх працівників: ");
            employees.ForEach(printEmployees);

            Console.WriteLine();

            // Вбудований делегат Predicate, перевіряє чи є в колекції підприємець.
            Predicate<Employee> isSntrepreneur = e => e.Position == "Підприємець";
            Console.WriteLine("Перевірка чи є підриємець");
            Console.WriteLine(employees.Exists(isSntrepreneur) ? "-Є підприємець" : "-Немає підприємця");

            Console.WriteLine();

            // Linq сортирує працівників від від меншої зп до більшої за допомогою `OrderBy`
            Console.WriteLine("Відсортування за зп");
            var sorted = employees.OrderBy(e => e.Salary).Select(e => $"{e.Name} ({e.Salary})");
            foreach (var emp in sorted)
            {
                Console.WriteLine(emp);
            }
        }
    }
}