using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }   

    /// <summary>
    /// 8.	Threeuple
    /// </summary>
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var nameAddress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    //        var ct1 = new CustomTuple<string, string, string>(nameAddress[0] + " " + nameAddress[1], nameAddress[2], nameAddress[3]);

    //        var nameBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    //        var ct2 = new CustomTuple<string, int, string>(nameBeer[0], int.Parse(nameBeer[1]), nameBeer[2] == "drunk" ? "True" : "False");

    //        var lastLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    //        var ct3 = new CustomTuple<string, double, string>(lastLine[0], double.Parse(lastLine[1]), lastLine[2]);

    //        Console.WriteLine(ct1);
    //        Console.WriteLine(ct2);
    //        Console.WriteLine(ct3);
    //    }
    //}

    //public class CustomTuple<T1, T2, T3>
    //{
    //    private T1 item1;
    //    private T2 item2;
    //    private T3 item3;

    //    public CustomTuple(T1 item1, T2 item2, T3 item3)
    //    {
    //        this.item1 = item1;
    //        this.item2 = item2;
    //        this.item3 = item3;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{item1} -> {item2} -> {item3}";
    //    }
    //}

    /// <summary>
    /// 7.	Tuple
    /// </summary>
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var nameAddress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    //        var ct1 = new CustomTuple<string, string>(nameAddress[0] + " " + nameAddress[1], nameAddress[2]);

    //        var nameBeer = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    //        var ct2 = new CustomTuple<string, int>(nameBeer[0], int.Parse(nameBeer[1]));

    //        var lastLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    //        var ct3 = new CustomTuple<int, double>(int.Parse(lastLine[0]), double.Parse(lastLine[1]));

    //        Console.WriteLine(ct1);
    //        Console.WriteLine(ct2);
    //        Console.WriteLine(ct3);
    //    }
    //}

    //public class CustomTuple<T1, T2>
    //{
    //    private T1 item1;
    //    private T2 item2;

    //    public CustomTuple(T1 item1, T2 item2)
    //    {
    //        this.item1 = item1;
    //        this.item2 = item2;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{item1} -> {item2}";
    //    }
    //}
    
    /// <summary>
    /// 5.	Generic Count Method Strings
    /// 6.	Generic Count Method Doubles
    /// </summary>
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var n = int.Parse(Console.ReadLine());
    //        var list = new List<Box<double>>();

    //        for (int i = 0; i < n; i++)
    //        {
    //            var box = new Box<double>(double.Parse(Console.ReadLine()));
    //            list.Add(box);
    //        }

    //        var comparer = double.Parse(Console.ReadLine());

    //        Console.WriteLine(Count(list, comparer));
    //    }

    //    static int Count<T>(List<Box<T>> list, T comparer)
    //    {
    //        var counter = 0;

    //        foreach (var item in list)
    //        {
    //            if (item.AreEquals(comparer))
    //            {
    //                counter++;
    //            }
    //        }
    //        return counter;
    //    }
    //}

    //public class Box<T>
    //{
    //    private readonly T value;

    //    public Box(T input)
    //    {
    //        value = input;
    //    }

    //    public bool AreEquals(T x)
    //    {
    //        var comparer = Comparer<T>.Default;
    //        return comparer.Compare(value, x) > 0;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{value.GetType().FullName}: {value}";
    //    }
    //}

    /// <summary>
    /// 3.	Generic Swap Method Strings
    /// 4.	Generic Swap Method Integers
    /// </summary>
    /// <returns></returns>
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var n = int.Parse(Console.ReadLine());
    //        var list = new List<Box<int>>();

    //        for (int i = 0; i < n; i++)
    //        {
    //            var box = new Box<int>(int.Parse(Console.ReadLine()));
    //            list.Add(box);
    //        }

    //        var indeces = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    //        Swapper(list, indeces[0], indeces[1]);

    //        foreach (var box in list)
    //        {
    //            Console.WriteLine(box);
    //        }
    //    }

    //    public static void Swapper<T>(List<T> list, int index1, int index2)
    //    {
    //        var originalVal = list[index1];
    //        list[index1] = list[index2];
    //        list[index2] = originalVal;
    //    }
    //}

    //public class Box<T>
    //{
    //    private T value;

    //    public Box(T input)
    //    {
    //        value = input;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{value.GetType().FullName}: {value}";
    //    }
    //}

    /// <summary>
    /// 1.	Generic Box of String
    /// 2.	Generic Box of Integer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var n = int.Parse(Console.ReadLine());

    //        for (int i = 0; i < n; i++)
    //        {
    //            var input = int.Parse(Console.ReadLine());
    //            var box = new Box<int>(input);
    //            Console.WriteLine(box);
    //        }
    //    }
    //}

    //public class Box<T>
    //{
    //    private T value;

    //    public Box(T input)
    //    {
    //        value = input;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{value.GetType().FullName}: {value}";
    //    }
    //}
}
