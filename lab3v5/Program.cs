using System;

namespace lab3
{
    class Program
    {
        abstract class Device
        {
            public string Name { get; set; }

            protected Device(string name)
            {
                Name = name;
            }

            // Метод PowerUseg() для реалізації обчислення споживання енергії.
            public abstract double PowerUseg();

            public virtual void PrintInfo()
            {
                Console.WriteLine($"{Name}: Cпоживання енергії за добу = {PowerUseg():F2} кВт");
            }
        }

        // Клас наслідник Ноутбук
        class Laptom : Device
        {
            private double _powerWatts;

            private double _hoursDay;

            public double PowerWatts
            {
                get => _powerWatts;
                set
                {
                    if (value <= 0)
                    {
                        Console.WriteLine("Енергія не може дорівнювати нулю!");
                    }
                    _powerWatts = value;
                }
            }

            public double HoursDay
            {
                get => _hoursDay;
                set => _hoursDay = value;
            }

            // Конструктор із виклико base()
            public Laptom(double powerWatts, double hoursDay) : base("Ноутбук")
            {
                PowerWatts = powerWatts;
                HoursDay = hoursDay;
            }

            // Реалізація абстриктого методу PowerUseg()
            public override double PowerUseg()
            {
                return _powerWatts * _hoursDay / 1000.0;
            }

            // Перевизначення методу PrintInfo()
            public override void PrintInfo()
            {
                Console.WriteLine($"{Name} Працює = {_hoursDay} год. Cпоживання енергії за добу = {PowerUseg():F2} кВт");
            }

        }

        // Клас наслідник холодильник
        class Fridge : Device
        {
            private double _powerWatts;

            private double _hoursDay;

            public double PowerWatts
            {
                get => _powerWatts;
                set
                {
                    if (value <= 0)
                    {
                        Console.WriteLine("Енергія не може дорівнювати нулю!");
                    }
                    _powerWatts = value;
                }
            }

            public double HoursDay
            {
                get => _hoursDay;
                set => _hoursDay = value;
            }

            // Конструктор із виклико base()
            public Fridge(double powerWatts, double hoursDay) : base("Холодильник")
            {
                PowerWatts = powerWatts;
                HoursDay = hoursDay;
            }
            
            // Реалізація абстриктого методу PowerUseg()
            public override double PowerUseg()
            {
                return _powerWatts * _hoursDay / 1000.0;
            }
        }

        static void Main(string[] args)
        {
            
            // Масив із створеними девайсам
            List<Device> devices = new List<Device>
            {
                new Laptom(125, 13),
                new Fridge(200, 11)
            };

            double totalPower = 0;

            foreach (var d in devices)
            {
                d.PrintInfo();
                totalPower += d.PowerUseg();
            }

            // Сумарний підрахунок споживання енергії
            Console.WriteLine($"\nСумарне споживання енергії за добу = {totalPower:F2} кВт");
        }
    }
}
