using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    internal class Program
    {
        abstract class Figure
        {
            private string _name;

            public string Name
            {
                get { return _name; }
            }

            public Figure(string name)
            {
                _name = name;
                Console.WriteLine($"Конструктор Figure: Створено фігуру {name}");
            }

            ~Figure()
            {
                Console.WriteLine($"Декструктор Figure: знищено фігуру {_name}");
            }

            public virtual double getArea()
            {
                return 0;
            }
        }

        class Circle : Figure
        {
            private double _radius;
               
            public Circle(string name, double radius) : base(name)
            {
                _radius = radius;
            }

            public override double getArea()
            {
                return Math.PI * _radius * _radius;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть імя кола: ");
            string circle_name = Console.ReadLine();
            Console.Write("Введіть радіус кола: ");
            int circle_radius = Convert.ToInt32(Console.ReadLine());

            Circle c = new Circle(circle_name, circle_radius);

            Console.WriteLine($"{c.Name}: Площа = {c.getArea():F2}");

            Console.ReadKey();

        }
    }
}

