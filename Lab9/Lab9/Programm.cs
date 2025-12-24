using System;

public class Programm
{
    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Clear();

        Console.Title = "Лабораторная работа №9";

        // Создаем объекты
        Human h = new Human("Иванов Иван Иванович", 50);
        h.Plus(5);
        h.Minus(1);
        h.DrawObject();

        Console.WriteLine("\n\n\n");

        Car car = new Car("Hyundai", "ix35", 120);
        car.Plus(25);
        car.Minus(11);
        car.DrawObject();

        DemonstratePolymorphism();

        Console.ReadKey();
    }

    static void DemonstratePolymorphism()
    {
        Console.WriteLine("\n=== Демонстрация полиморфизма ===\n");

        ICalculate[] calculators = { new Human("Петров Петр Петрович", 30), new Car("Toyota", "Camry", 80) };

        foreach (var calc in calculators)
        {
            if (calc is Human human)
            {
                human.Plus(10);
                Console.WriteLine($"Человек после +10: {human.Name}");
            }
            else if (calc is Car car)
            {
                car.Minus(20);
                Console.WriteLine($"Машина после -20: {car.Name}");
            }
        }

        IVisual[] visuals = { new Human("Сидоров Сидор Сидорович", 45), new Car("BMW", "X5", 150) };

        foreach (var visual in visuals)
        {
            visual.DrawObject();
            Console.WriteLine();
        }
    }
}
