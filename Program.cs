using System;
//Створіть клас ArrayManipulator, який має методи для роботи з масивами цілих чисел:
//Метод GenerateRandomArray(int length, int min, int max),
//який створює та повертає новий масив заданої довжини з випадковими числами в діапазоні від min до max.
//Метод FindMax(int[] array), який знаходить та повертає найбільший елемент у масиві.
//Метод SortArray(int[] array), який сортує масив у зростаючому порядку.
//Після створення класу запустіть програму, яка створює масив,
//знаходить найбільший елемент та сортує масив.
//Виведіть початковий масив, знайдений максимум та відсортований масив на консоль.
class Program
{
    class ArrayManipulator
    {
       

       public int[] GenerateRandomArray(int length, int min, int max)
        {
            Random random = new Random();
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(min, max + 1);
            }
            return array;
        }


        //public int SortArray(int[] Array)
        //{
        //    Console.WriteLine("Enter n:");
        //              int n = int.Parse(Console.ReadLine());
        //              int[] Array = new int[n];
        //              Console.WriteLine("Enter elements:");
        //              for(int i = 0; i < n; i++)
        //              {
        //                  Array[i] = int.Parse(Console.ReadLine());
        //              }
                        
        //              Array.Sort(Array);
        //}
    }


    static void Main()
    {
        ArrayManipulator manipulator = new ArrayManipulator();

    
        int[] array = manipulator.GenerateRandomArray(10, 1, 100);

        
        Console.WriteLine("Array:");
        Console.WriteLine(string.Join(", ", array));


    }
}
