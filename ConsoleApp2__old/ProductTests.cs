using System;
using ConsoleApp2__old;  // Импорт пространства имен тестируемого приложения
using NUnit.Framework;   // Импорт фреймворка для модульного тестирования NUnit

// Атрибут указывает, что этот класс содержит тесты
[TestFixture]
public class ProductTests
{
    // Тест для случая, когда n = 1
    [Test]
    public void When_N_Is_1_Returns_CorrectResult()
    {
        // Arrange (подготовка данных)
        int n = 1;  // Входное значение
        // Ожидаемый результат - квадрат косинуса 1 радиана
        double expected = Math.Pow(Math.Cos(1), 2);

        // Act (действие)
        double actual = Program.CalculateProduct(n);  // Вызов тестируемого метода

        // Assert (проверка)
        // Сравнение ожидаемого и фактического результатов с заданной точностью
        Assert.AreEqual(expected, actual, 0.0000001);
    }

    // Тест для случая, когда n = 5
    [Test]
    public void When_N_Is_5_Returns_CorrectResult()
    {
        // Arrange
        int n = 5;
        // Ожидаемый результат - произведение квадратов косинусов от 1 до 5
        double expected = Math.Pow(Math.Cos(1), 2) *
                         Math.Pow(Math.Cos(2), 2) *
                         Math.Pow(Math.Cos(3), 2) *
                         Math.Pow(Math.Cos(4), 2) *
                         Math.Pow(Math.Cos(5), 2);

        // Act
        double actual = Program.CalculateProduct(n);

        // Assert
        Assert.AreEqual(expected, actual, 0.0000001);
    }

    // Тест для проверки обработки нулевого значения
    [Test]
    public void When_N_Is_Zero_Throws_ArgumentException()
    {
        // Act & Assert
        // Проверяем, что метод выбрасывает ArgumentException при n = 0
        Assert.Throws<ArgumentException>(() => Program.CalculateProduct(0));
    }

    // Тест для проверки обработки отрицательного значения
    [Test]
    public void When_N_Is_Negative_Throws_ArgumentException()
    {
        // Act & Assert
        // Проверяем, что метод выбрасывает ArgumentException при отрицательном n
        Assert.Throws<ArgumentException>(() => Program.CalculateProduct(-5));
    }
}