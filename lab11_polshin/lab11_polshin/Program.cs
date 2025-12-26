using lab11_polshin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab11_polshin
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №11 — Вариант 19");
                Console.WriteLine("Анализ данных о сотрудниках...\n");

                // Путь к файлу
                string inputPath = "employees.csv";
                string outputPath = "output.txt";

                // Проверка наличия входного файла
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Ошибка: файл '{inputPath}' не найден.");
                    Console.ReadKey();
                    return;
                }

                // Чтение данных
                var lines = File.ReadAllLines(inputPath);
                if (lines.Length <= 1)
                {
                    Console.WriteLine("Файл пуст или содержит только заголовок.");
                    Console.ReadKey();
                    return;
                }

                // Пропускаем заголовок и парсим сотрудников
                var employees = new List<Employee>();
                for (int i = 1; i < lines.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lines[i]))
                    {
                        try
                        {
                            employees.Add(Employee.FromCsv(lines[i]));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Предупреждение: строка {i + 1} пропущена — {ex.Message}");
                        }
                    }
                }

                // 1. Сотрудники без логина ИЛИ пароля
                int noCreds = employees.Count(e => string.IsNullOrEmpty(e.Login) || string.IsNullOrEmpty(e.Password));

                // 2. Средние зарплаты
                var withFamily = employees.Where(e => e.HasFamily).ToList();
                var withoutFamily = employees.Where(e => !e.HasFamily).ToList();

                double avgWithFamily = withFamily.Any() ? withFamily.Average(e => e.Salary) : 0;
                double avgWithoutFamily = withoutFamily.Any() ? withoutFamily.Average(e => e.Salary) : 0;

                // 3. Машина есть, семьи нет
                int carNoFamily = employees.Count(e => e.HasCar && !e.HasFamily);

                // 4. Мин/макс по отделам (ожидаем 4 отдела)
                var departments = employees
                    .GroupBy(e => e.Department)
                    .ToDictionary(g => g.Key, g => new
                    {
                        Min = g.Min(x => x.Salary),
                        Max = g.Max(x => x.Salary)
                    });

                // Вывод в консоль
                Console.WriteLine($"1. Сотрудников без логина или пароля: {noCreds}");
                Console.WriteLine($"2. Средняя з/п: с семьёй = {avgWithFamily:F2}, без = {avgWithoutFamily:F2}");
                Console.WriteLine($"3. Машина есть, семьи нет: {carNoFamily}");
                Console.WriteLine("4. Мин/макс з/п по отделам:");
                foreach (var dept in departments.OrderBy(d => d.Key))
                {
                    Console.WriteLine($"   {dept.Key}: мин = {dept.Value.Min:F0}, макс = {dept.Value.Max:F0}");
                }

                // Запись в файл output.txt
                using (var writer = new StreamWriter(outputPath, false, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №11 — ОТЧЁТ");
                    writer.WriteLine(new string('=', 50));
                    writer.WriteLine($"1. Сотрудников без логина или пароля: {noCreds}");
                    writer.WriteLine($"2. Средняя з/п: с семьёй = {avgWithFamily:F2}, без = {avgWithoutFamily:F2}");
                    writer.WriteLine($"3. Машина есть, семьи нет: {carNoFamily}");
                    writer.WriteLine("4. Мин/макс з/п по отделам:");
                    foreach (var dept in departments.OrderBy(d => d.Key))
                    {
                        writer.WriteLine($"   {dept.Key}: мин = {dept.Value.Min:F0}, макс = {dept.Value.Max:F0}");
                    }
                }

                Console.WriteLine($"\nРезультат сохранён в '{outputPath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Критическая ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}