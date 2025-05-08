using System;
using DoubleLinkedListLibrary;

class Program
{
    static void Main()
    {
        var list1 = new DoubleLinkedList();
        var list2 = new DoubleLinkedList();

        list1.AddToHead(10.5);
        list1.AddToHead(5.3);
        list1.AddToHead(8.2);
        list1.AddToHead(12.7);
        list1.AddToHead(4.1);
        list1.AddToHead(6.9);
        list1.AddToHead(10.11);

        Console.WriteLine("Elements of list1: ");
        foreach (var value in list1)
        {
            Console.Write(value + "  ");
        }
        Console.WriteLine();

        Console.WriteLine($"\nElement with index 2: {list1[2]}");

        list1.Delete(2);
        Console.WriteLine("\nList1 after deleting third element");
        foreach (var value in list1)
        {
            Console.Write(value + "  ");
        }
        Console.WriteLine();

        var lessThanAverage = list1.LessThanAverage();
        Console.WriteLine($"\nFirst element that is less than average: {lessThanAverage}");

        double sumAfterMax = list1.SumAfterMax();
        Console.WriteLine($"\nSum of elements after the biggest one: {sumAfterMax}");

        double x = 8.0;
        list2 = list1.GetGreaterThan(x);
        Console.WriteLine($"\nElemenets of list1 > {x}:");
        foreach (var value in list2)
        {
            Console.Write(value + "  ");
        }
        Console.WriteLine();

        list1.DeleteBeforeMax();
        Console.WriteLine("\nList1 after deleting all elements before the gratest one");
        foreach (var value in list1)
        {
            Console.Write(value + "  ");
        }

    }
}
