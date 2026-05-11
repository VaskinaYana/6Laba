using System;

namespace OOP_Task2
{
    class Money
    {
        private uint rubles;
        private byte kopeks;

        // Конструктор без параметров
        public Money()
        {
            rubles = 0;
            kopeks = 0;
        }

        // Конструктор с параметрами
        public Money(uint rub, byte kop)
        {
            rubles = rub;

            if (kop < 100)
            {
                kopeks = kop;
            }
            else
            {
                kopeks = 0;
            }
        }

        // Конструктор копирования
        public Money(Money other)
        {
            rubles = other.rubles;
            kopeks = other.kopeks;
        }

        // Свойство Rubles
        public uint GetRubles()
        {
            return rubles;
        }

        public void SetRubles(uint value)
        {
            rubles = value;
        }

        // Свойство Kopeks
        public byte GetKopeks()
        {
            return kopeks;
        }

        public void SetKopeks(byte value)
        {
            if (value < 100)
            {
                kopeks = value;
            }
        }

        // Метод вычитания копеек
        public Money SubtractKopeks(uint value)
        {
            uint total = rubles * 100 + kopeks;

            if (value >= total)
            {
                return new Money(0, 0);
            }

            total = total - value;

            uint newRubles = total / 100;
            byte newKopeks = (byte)(total % 100);

            return new Money(newRubles, newKopeks);
        }

        // Перегрузка оператора -
        public static Money operator -(Money money, uint value)
        {
            return money.SubtractKopeks(value);
        }

        public override string ToString()
        {
            return rubles + " руб. " + kopeks + " коп.";
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введите рубли: ");
            uint rub = uint.Parse(Console.ReadLine());

            Console.Write("Введите копейки (0-99): ");
            byte kop = byte.Parse(Console.ReadLine());

            Money m1 = new Money(rub, kop);

            Console.WriteLine("\nОбъект:");
            Console.WriteLine(m1);

            // Конструктор копирования
            Money copy = new Money(m1);
            Console.WriteLine("Копия:");
            Console.WriteLine(copy);

            Console.Write("\nСколько копеек вычесть? ");
            uint x = uint.Parse(Console.ReadLine());

            // Метод
            Money result1 = m1.SubtractKopeks(x);
            Console.WriteLine("Через метод: " + result1);

            // Перегруженный оператор
            Money result2 = m1 - x;
            Console.WriteLine("Через оператор - : " + result2);
        }
    }
}