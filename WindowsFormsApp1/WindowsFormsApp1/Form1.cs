using System;
using System.Windows.Forms;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Двумерный массив для хранения текстовых полей матрицы
        private TextBox[,] matrixTextBoxes;

        // Текущий размер матрицы (по умолчанию 3x3)
        private int matrixSize = 3;

        // Конструктор формы
        public Form1()
        {
            InitializeComponent(); // Стандартная инициализация компонентов
            InitializeMatrixControls(); // Наша кастомная инициализация
        }

        // Инициализация элементов управления
        private void InitializeMatrixControls()
        {
            // Создаем метку для выбора размера матрицы
            Label sizeLabel = new Label
            {
                Text = "Размер матрицы:",
                Location = new System.Drawing.Point(10, 10) // Позиция на форме
            };
            Controls.Add(sizeLabel); // Добавляем на форму

            // Числовое поле для выбора размера матрицы
            NumericUpDown sizeInput = new NumericUpDown
            {
                Location = new System.Drawing.Point(120, 10),
                Minimum = 2,  // Минимальный размер
                Maximum = 10, // Максимальный размер
                Value = matrixSize // Текущее значение
            };

            // Обработчик изменения размера
            sizeInput.ValueChanged += (s, e) =>
            {
                matrixSize = (int)sizeInput.Value;
                CreateMatrixInputs(); // Пересоздаем поля матрицы
            };
            Controls.Add(sizeInput);

            // Кнопка сортировки диагонали
            Button sortDiagonalButton = new Button
            {
                Text = "Сортировать по диагонали",
                Location = new System.Drawing.Point(10, 40),
                Width = 200
            };
            sortDiagonalButton.Click += SortButtonClick;
            Controls.Add(sortDiagonalButton);

            // Кнопка сортировки всей матрицы
            Button sortMatrixButton = new Button
            {
                Text = "Сортировать всю матрицу",
                Location = new System.Drawing.Point(220, 40),
                Width = 200
            };
            sortMatrixButton.Click += SortMatrixButtonClick;
            Controls.Add(sortMatrixButton);

            // Создаем начальные поля для матрицы
            CreateMatrixInputs();
        }

        // Создание текстовых полей для ввода матрицы
        private void CreateMatrixInputs()
        {
            // Удаляем старые поля, если они есть
            if (matrixTextBoxes != null)
            {
                for (int i = 0; i < matrixTextBoxes.GetLength(0); i++)
                    for (int j = 0; j < matrixTextBoxes.GetLength(1); j++)
                        if (matrixTextBoxes[i, j] != null)
                            Controls.Remove(matrixTextBoxes[i, j]);
            }

            // Создаем новый массив текстовых полей
            matrixTextBoxes = new TextBox[matrixSize, matrixSize];
            int startY = 80; // Начальная позиция по Y
            int startX = 10; // Начальная позиция по X

            // Заполняем матрицу текстовыми полями
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrixTextBoxes[i, j] = new TextBox
                    {
                        Location = new System.Drawing.Point(startX + j * 60, startY + i * 30),
                        Width = 50,
                        Text = "0" // Значение по умолчанию
                    };
                    Controls.Add(matrixTextBoxes[i, j]);
                }
            }
        }

        // Обработчик нажатия кнопки сортировки диагонали
        private void SortButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Собираем элементы главной диагонали
                int[] diagonal = new int[matrixSize];
                for (int i = 0; i < matrixSize; i++)
                {
                    diagonal[i] = int.Parse(matrixTextBoxes[i, i].Text);
                }

                Array.Sort(diagonal); // Сортируем диагональ

                // Возвращаем отсортированные значения
                for (int i = 0; i < matrixSize; i++)
                {
                    matrixTextBoxes[i, i].Text = diagonal[i].ToString();
                }

                MessageBox.Show("Диагональ отсортирована по возрастанию!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сортировке: {ex.Message}", "Ошибка");
            }
        }

        // Обработчик нажатия кнопки сортировки всей матрицы
        private void SortMatrixButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Создаем одномерный массив для всех элементов
                int[] allElements = new int[matrixSize * matrixSize];
                int index = 0;

                // Собираем все элементы матрицы
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        allElements[index++] = int.Parse(matrixTextBoxes[i, j].Text);
                    }
                }

                Array.Sort(allElements); // Сортируем все элементы
                index = 0;

                // Заполняем матрицу отсортированными значениями
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        matrixTextBoxes[i, j].Text = allElements[index++].ToString();
                    }
                }

                MessageBox.Show("Матрица отсортирована по возрастанию!", "Успех");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сортировке: {ex.Message}", "Ошибка");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
