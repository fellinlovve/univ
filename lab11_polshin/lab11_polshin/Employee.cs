using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11_polshin

{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool HasFamily { get; set; }
        public bool HasCar { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        /// <summary>
        /// Создаёт объект Employee из строки CSV (без заголовка)
        /// </summary>
        public static Employee FromCsv(string line)
        {
            var parts = line.Split(',');
            if (parts.Length != 8)
                throw new ArgumentException("Неверный формат строки CSV");

            return new Employee
            {
                ID = int.Parse(parts[0].Trim()),
                Name = parts[1].Trim(),
                Login = parts[2].Trim(),
                Password = parts[3].Trim(),
                HasFamily = bool.Parse(parts[4].Trim()),
                HasCar = bool.Parse(parts[5].Trim()),
                Department = parts[6].Trim(),
                Salary = double.Parse(parts[7].Trim())
            };
        }
    }
}
