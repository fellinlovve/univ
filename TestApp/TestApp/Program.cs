using System;
using System.Diagnostics;

namespace TestApp
{
    /// <summary>
    /// Класс "Тест", содержащий тему, вопрос и правильный ответ.
    /// </summary>
    public class Test
    {
        // Поля класса
        public string Theme { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }

        // Конструктор по умолчанию
        public Test()
        {
            Theme = "Без темы";
            Question = "Без вопроса";
            CorrectAssistant();
        }

        // Перегруженный конструктор: тема, вопрос, ответ
        public Test(string theme, string question, string correctAnswer)
        {
            Theme = theme;
            Question = question;
            CorrectAnswer = correctAnswer;

#if DEBUG
            Console.WriteLine($"[DEBUG] Создан объект Test: {Theme}");
#endif
        }

        // Перегруженный конструктор: только вопрос и ответ (тема по умолчанию)
        public Test(string question, string correctAnswer) : this("Общая тема", question, correctAnswer)
        {
#if DEBUG
            Console.WriteLine($"[DEBUG] Создан объект Test без указания темы.");
#endif
        }

        // Метод вывода вопроса
        public void DisplayQuestion()
        {
            Console.WriteLine($"Вопрос ({Theme}): {Question}");
        }

        // Перегруженный метод получения ответа (от пользователя)
        public bool CheckAnswer()
        {
            Console.Write("Ваш ответ: ");
            string userAnswer = Console.ReadLine();
            return CheckAnswer(userAnswer);
        }

        // Перегруженный метод для проверки заданного ответа
        public bool CheckAnswer(string userAnswer)
        {
            bool isCorrect = string.Equals(userAnswer, CorrectAnswer, StringComparison.OrdinalIgnoreCase);

#if DEBUG
            Console.WriteLine($"[DEBUG] Проверка ответа: '{userAnswer}' == '{CorrectAnswer}' → {isCorrect}");
#endif

            return isCorrect;
        }

        // Перегруженный метод вывода результата (с пользовательским сообщением)
        public void ShowResult(bool isCorrect, string customCorrectMessage = null, string customIncorrectMessage = null)
        {
            if (isCorrect)
            {
                string message = customCorrectMessage ?? "Правильно!";
                Console.WriteLine(message);
            }
            else
            {
                string message = customIncorrectMessage ?? "Неправильно.";
                Console.WriteLine(message);
            }

#if DEBUG
            Console.WriteLine($"[DEBUG] Результат показан. Ответ верен: {isCorrect}");
#endif
        }

        // Вывод всей информации об объекте
        public void DisplayInfo()
        {
            Console.WriteLine($"Тема: {Theme}");
            Console.WriteLine($"Вопрос: {Question}");
            Console.WriteLine($"Правильный ответ: {CorrectAnswer}");
        }

        // Вспомогательный метод для инициализации ответа по умолчанию (для конструктора по умолчанию)
        private void CorrectAssistant()
        {
            CorrectAnswer = "Ответ не задан";
        }
    }

    // Пример использования класса
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("=== РЕЖИМ ОТЛАДКИ (DEBUG) ===");
#else
            Console.WriteLine("=== РЕЖИМ ВЫПУСКА (RELEASE) ===");
#endif

            // Пример 1: создание через конструктор по умолчанию
            var test1 = new Test();
            test1.DisplayInfo();
            Console.WriteLine();

            // Пример 2: создание с указанием всех данных
            var test2 = new Test("Математика", "Сколько будет 2 + 2?", "4");
            test2.DisplayQuestion();
            bool result = test2.CheckAnswer(); // Ввод ответа с консоли
            test2.ShowResult(result);
            Console.WriteLine();

            // Пример 3: создание без темы
            var test3 = new Test("Какой город является столицей Франции?", "Париж");
            test3.DisplayInfo();
            test3.ShowResult(test3.CheckAnswer("Париж"), "Отлично!", "Попробуйте ещё раз.");
        }
    }
}