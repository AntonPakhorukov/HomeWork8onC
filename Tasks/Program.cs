/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2

Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки 
с наименьшей суммой элементов: 1 строка

Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18

Дополнительная задача (60): Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)

Дополнительная задача 2 (62):. Напишите программу, 
которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/
Console.Clear();
Console.Write("Введите номер задачи: ");
int task = Convert.ToInt32(Console.ReadLine());
int[,] GetBinaryArray()
{
    Console.Write("Введите количество строк двуменрного массива: ");
    int row = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов двумерного массива: ");
    int column = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[row, column];
    return array;
}
int[,] GetMatrix()
{
    Console.Write("Введите размер матрицы: ");
    int size = Convert.ToInt32(Console.ReadLine());
    int[,] matrix = new int[size, size];
    return matrix;
}
int[,] FillBinaryArrayRandom(int[,] inputArray)
{
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            inputArray[i, j] = new Random().Next(1, 10);
        }
    }
    return inputArray;
}
void PrintBinaryArray(int[,] inputArray)
{
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            Console.Write(inputArray[i, j] + " ");
        }
        Console.WriteLine();
    }
}

switch (task)
{
    case 54:
        Task54();
        break;
    case 56:
        Task56();
        break;
    case 58:
        Task58();
        break;
    case 60:
        Task60();
        break;
    case 62:
        Task62();
        break;
}
void Task54()
{
    /*
Задача 54: Задайте двумерный массив. Напишите программу, 
которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/
    Console.Clear();
    int[,] array = GetBinaryArray();
    array = FillBinaryArrayRandom(array);
    PrintBinaryArray(array);
    int[,] ChangeMaxToMinBinaryArray(int[,] inputArray)
    {
        int number = 0;
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++)
            {
                for (int k = 0; k < inputArray.GetLength(1) - 1; k++)
                {
                    if (inputArray[i, k] < inputArray[i, k + 1])
                    {
                        number = inputArray[i, k];
                        inputArray[i, k] = inputArray[i, k + 1];
                        inputArray[i, k + 1] = number;
                    }
                }
            }
        }
        return inputArray;
    }
    Console.WriteLine();
    array = ChangeMaxToMinBinaryArray(array);
    PrintBinaryArray(array);
}
void Task56()
{
    /*
    Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
    которая будет находить строку с наименьшей суммой элементов.
    Например, задан массив:
    1 4 7 2
    5 9 2 3
    8 4 2 4
    5 2 6 7
    Программа считает сумму элементов в каждой строке и выдаёт номер строки 
    с наименьшей суммой элементов: 1 строка
    */
    Console.Clear();
    int[,] array = GetBinaryArray();
    array = FillBinaryArrayRandom(array);
    Console.Clear();
    PrintBinaryArray(array);
    int GetBinaryArraToArray(int[,] inputArray)
    {
        int[] sum = new int[inputArray.GetLength(0)];
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++)
            {
                sum[i] += inputArray[i, j];
            }
        }
        Console.WriteLine("[" + String.Join(", ", sum) + "]");
        int index = 1;
        int minSum = sum[0];
        for (int i = 1; i <= sum.Length - 1; i++)
        {
            if (sum[i] < minSum)
            {
                minSum = sum[i];
                index = i + 1;
            }
        }
        return index;
    }
    Console.WriteLine();
    int result = GetBinaryArraToArray(array);
    Console.WriteLine($"Наименьшая сумма элементов в строке {result}");
}
void Task58()
{
    /*
    Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
    Например, даны 2 матрицы:
    2 4 | 3 4
    3 2 | 3 3
    Результирующая матрица будет:
    18 20
    15 18
    */
    Console.Clear();
    Console.Write("Введите количество строк первой матрицы: ");
    int row1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов первой матрицы: ");
    int column1 = Convert.ToInt32(Console.ReadLine());
    int[,] matrix1 = new int[row1, column1];
    Console.Write("Введите количество столбцов второй матрицы: ");
    int column2 = Convert.ToInt32(Console.ReadLine());
    int[,] matrix2 = new int[column1, column2];
    Console.Clear();
    matrix1 = FillBinaryArrayRandom(matrix1);
    matrix2 = FillBinaryArrayRandom(matrix2);
    int size = matrix1.GetLength(0);
    if (matrix1.GetLength(1) < matrix2.GetLength(1))
    {
        size = matrix2.GetLength(1);
    }

    void PrintTwoMatrix(int[,] inputMatrix1, int[,] inputMatrix2, int size)
    {
        for (int i = 0; i < inputMatrix1.GetLength(0); i++)
        {
            for (int j = 0; j < inputMatrix1.GetLength(1); j++)
            {
                Console.Write(inputMatrix1[i, j] + " ");
            }

            Console.Write(" |  ");
            for (int k = 0; k < inputMatrix2.GetLength(1); k++)
            {
                if (i < inputMatrix2.GetLength(0)) // додбавил if чтобы вывести второй массив с меншими строками
                {
                    Console.Write(inputMatrix2[i, k] + " ");
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine();
        }
    }
    Console.Clear();
    PrintTwoMatrix(matrix1, matrix2, size);
    int[,] multiplyMatrix(int[,] matrix1, int[,] matrix2, int size)
    {
        if (matrix2.GetLength(1) < size) size = matrix2.GetLength(1);
        int[,] multiply = new int[matrix1.GetLength(0), size];
        for (int i = 0; i < multiply.GetLength(0); i++)
        {
            for (int j = 0; j < size; j++) // = s-1
            {
                for (int x = 0; x < multiply.GetLength(0); x++)
                {
                    if (x < matrix2.GetLength(0))
                    {
                        multiply[i, j] += matrix1[i, x] * matrix2[x, j];
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        return multiply;
    }
    int[,] result = multiplyMatrix(matrix1, matrix2, size);
    Console.WriteLine();
    PrintBinaryArray(result);
}
void Task60()
{
    /*
    Дополнительная задача (60): Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
    Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
    Массив размером 2 x 2 x 2
    66(0,0,0) 25(0,1,0)
    34(1,0,0) 41(1,1,0)
    27(0,0,1) 90(0,1,1)
    26(1,0,1) 55(1,1,1)
    */
    Console.Clear();
    Console.Write("Введите первое значение трехмернорго массива: ");
    int first = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите второе значение трехмерного массива: ");
    int second = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите третье значение трехмерного массива: ");
    int thied = Convert.ToInt32(Console.ReadLine());
    int[,,] array3 = new int[first, second, thied];
    for (int i = 0; i < array3.GetLength(0); i++)
    {
        for (int j = 0; j < array3.GetLength(1); j++)
        {
            for (int k = 0; k < array3.GetLength(2); k++)
            {
                array3[j, k, i] = new Random().Next(1, 100);
                Console.Write(array3[j, k, i] + "(" + j + "," + k + "," + i + ") ");
            }
            Console.WriteLine();
        }
    }
}
void Task62()
{
    /*
    Дополнительная задача 2 (62):. Напишите программу, 
    которая заполнит спирально массив 4 на 4.
    Например, на выходе получается вот такой массив:
    01 02 03 04
    12 13 14 05
    11 16 15 06
    10 09 08 07
    */
    Console.Clear();
    void PrintBinaryArray2(int[,] inputArray)
    {
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++)
            {
                if (inputArray[i, j] < 10)
                {
                    Console.Write($"0{inputArray[i, j]} ");
                }
                else
                {
                    Console.Write(inputArray[i, j] + " ");
                }
            }
            Console.WriteLine();
        }
    }
    // Console.Write("Введите размер двумерного массива: ");
    // int size = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[4, 4];
    int[,] FillSpiralArray(int[,] inputArray)
    {
        int number1 = 1;
        int number2 = inputArray.GetLength(1);
        int number3 = number2 * 2 - number1;
        int number4 = number3 + number2 - number1;
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++)
            {
                if (i == 0)
                {
                    inputArray[i, j] = number1;
                    number1++;
                }
                else if (i == inputArray.GetLength(0) - 1)
                {
                    inputArray[j, i] = number1 - 1;
                    inputArray[i, j] = number3 + number3 - number1 + 1;
                    number1++;
                }
                else if (i > 0 && i < inputArray.GetLength(1) - 1)
                {
                    inputArray[i, 0] = number4 + number2 - i - 1;
                }
            }
        }
        for (int i = 1; i < inputArray.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < inputArray.GetLength(1) - 1; j++)
            {
                if (i == 1)
                {
                    inputArray[i, j] = inputArray[1, 0] + j;
                }
                else if (i == inputArray.GetLength(0) - inputArray[0,1] && j > 1 && j < inputArray.GetLength(1)-1)
                {
                    inputArray[j, i] = inputArray[1,0] + inputArray[0,inputArray.GetLength(0) - inputArray[0,3] + j];
                 } else if (i == inputArray.GetLength(0) - inputArray[0,1]) {
                    for (int k = 2; k > 0; k--) {
                        inputArray[i,k] = inputArray.GetLength(0) * inputArray.GetLength(1);
                    }                    
                }
            }
        }
        return inputArray;
    }
    array = FillSpiralArray(array);
    Console.WriteLine();
    PrintBinaryArray2(array);
}