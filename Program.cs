using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2__old
{
    class Program
    {
        // Главный метод программы
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для вычисления произведения cos²(i) от i=1 до n");

            try
            {
                // Получаем ввод от пользователя
                Console.Write("Введите значение n: ");
                int n = Convert.ToInt32(Console.ReadLine());

                // Проверка на положительное значение
                if (n <= 0)
                {
                    throw new ArgumentException("Значение n должно быть положительным числом.");
                }

                // Вычисление и вывод результата
                double result = CalculateProduct(n);
                Console.WriteLine($"Результат произведения: {result}");
            }
            catch (FormatException) // Ошибка формата ввода
            {
                Console.WriteLine("Ошибка: Введено некорректное значение. Пожалуйста, введите целое число.");
            }
            catch (OverflowException) // Переполнение при вводе
            {
                Console.WriteLine("Ошибка: Введенное значение слишком большое или слишком маленькое.");
            }
            catch (ArgumentException ex) // Некорректный аргумент
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex) // Все остальные исключения
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }

            // Завершение программы
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        /// <summary>
        /// Вычисляет произведение квадратов косинусов чисел от 1 до n
        /// </summary>
        /// <param name="n">Верхняя граница произведения</param>
        /// <returns>Результат вычисления произведения</returns>
        /// <exception cref="ArgumentException">Выбрасывается при n ≤ 0</exception>
        /// <exception cref="OverflowException">Выбрасывается при переполнении</exception>
        public static double CalculateProduct(int n)
        {
            // Проверка входного параметра
            if (n <= 0)
            {
                throw new ArgumentException("Значение n должно быть положительным числом.");
            }

            double product = 1.0; // Начальное значение произведения

            // Цикл вычисления произведения
            for (int i = 1; i <= n; i++)
            {
                // Вычисляем квадрат косинуса текущего числа
                double cosSquared = Math.Pow(Math.Cos(i), 2);

                // Умножаем на текущее значение произведения
                product *= cosSquared;

                // Проверка на переполнение или недополнение
                if (double.IsInfinity(product) // Бесконечность
                {
                    throw new OverflowException("Результат вычисления вышел за пределы допустимого диапазона.");
                }
                if (double.IsNaN(product)) // Не число
                {
                    throw new OverflowException("Результат вычисления не является допустимым числом.");
                }
            }

            return product;
        }
    }
}