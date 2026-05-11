using System;

namespace OOP_Task
{
    // Базовый класс
    class LogicalPair
    {
        private bool first;
        private bool second;

        // Конструктор
        public LogicalPair(bool a, bool b)
        {
            first = a;
            second = b;
        }

        // Конструктор копирования
        public LogicalPair(LogicalPair other)
        {
            first = other.first;
            second = other.second;
        }

        // Импликация
        public bool Implication()
        {
            return !first || second;
        }

        public override string ToString()
        {
            return "First = " + first + ", Second = " + second;
        }

        public bool GetFirst()
        {
            return first;
        }

        public bool GetSecond()
        {
            return second;
        }

        public void SetValues(bool a, bool b)
        {
            first = a;
            second = b;
        }
    }

    // Производный класс
    class LogicalExpression : LogicalPair
    {
        private string name;

        public LogicalExpression(bool a, bool b, string n)
            : base(a, b)
        {
            name = n;
        }

        // Конструктор копирования
        public LogicalExpression(LogicalExpression other)
            : base(other)
        {
            name = other.name;
        }

        // Метод: эквивалентность
        public bool IsEqual()
        {
            return GetFirst() == GetSecond();
        }

        // Метод: инверсия
        public void Invert()
        {
            SetValues(!GetFirst(), !GetSecond());
        }

        public override string ToString()
        {
            return "Name = " + name + ", " + base.ToString();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введите first (true/false): ");
            bool a = bool.Parse(Console.ReadLine());

            Console.Write("Введите second (true/false): ");
            bool b = bool.Parse(Console.ReadLine());

            // Базовый класс
            LogicalPair obj = new LogicalPair(a, b);
            Console.WriteLine(obj);
            Console.WriteLine("Импликация = " + obj.Implication());

            // Копия
            LogicalPair copy = new LogicalPair(obj);
            Console.WriteLine("Копия: " + copy);

            // Производный класс
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            LogicalExpression expr = new LogicalExpression(a, b, name);
            Console.WriteLine(expr);
            Console.WriteLine("Эквивалентность = " + expr.IsEqual());

            expr.Invert();
            Console.WriteLine("После инверсии: " + expr);

            // Копия производного
            LogicalExpression exprCopy = new LogicalExpression(expr);
            Console.WriteLine("Копия: " + exprCopy);
        }
    }
}
