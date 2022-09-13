using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_C_Sharp_Funamentals.Exercises
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Compete/Index/1206#7
    /// </summary>
    public static class Arrays
    {
        /// <summary>
        /// 01 Train
        /// </summary>
        public static void Train()
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(arr.Sum());
        }

        /// <summary>
        /// 02. Common Elements
        /// </summary>
        public static void CommonElements()
        {
            var arr1 = Console.ReadLine().Split(" ").ToArray();
            var arr2 = Console.ReadLine().Split(" ").ToArray();
            var res = new List<string>();

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr2[i] == arr1[j])
                    {
                        res.Add(arr1[j]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", res));
        }

        /// <summary>
        /// 3. Zig-Zag Arrays
        /// </summary>
        public static void ZigZagArrays()
        {
            var n = int.Parse(Console.ReadLine());
            var arr1 = new int[n];
            var arr2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    arr1[i] = arr[0];
                    arr2[i] = arr[1];
                }
                else
                {
                    arr1[i] = arr[1];
                    arr2[i] = arr[0];
                }
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }

        /// <summary>
        /// 04. Array Rotation
        /// </summary>
        public static void ArrayRotation()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var revs = int.Parse(Console.ReadLine());

            for (int i = 0; i < revs; i++)
            {
                var tmp = arr[0];

                for (int j = 1; j < arr.Length; j++)
                {
                    arr[j - 1] = arr[j];
                }

                arr[arr.Length - 1] = tmp;
            }

            Console.WriteLine(string.Join(" ", arr));
        }

        /// <summary>
        /// 5. Top Integers
        /// </summary>
        public static void TopIntegers()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var res = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                bool isBigger = true;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        isBigger = false;
                        break;
                    }
                }

                if (isBigger)
                {
                    res.Add(arr[i]);
                }
            }

            Console.WriteLine(string.Join(" ", res));
        }

        /// <summary>
        /// 06. Equal Sum
        /// </summary>
        public static void EqualSum()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                var sumLeft = 0;
                var sumRight = 0;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    sumRight += arr[j];
                }

                for (int k = 0; k < i; k++)
                {
                    sumLeft += arr[k];
                }

                if (sumLeft == sumRight)
                {
                    index = i;
                }
            }

            Console.WriteLine(index == -1 ? "no" : index.ToString());
        }

        /// <summary>
        /// 7. Max Sequence of Equal Elements
        /// </summary>
        public static void MaxSequenceOfEqualElements()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var startIndex = 0;
            var length = 1;
            var maxIndex = 0;
            var maxLength = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    length++;

                    if (length > maxLength)
                    {
                        maxLength = length;
                        maxIndex = startIndex;
                    }
                }
                else
                {
                    length = 1;
                    startIndex = i;
                }
            }

            for (int i = maxIndex; i < maxIndex + maxLength; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        /// <summary>
        /// 08. Magic Sum
        /// </summary>
        public static void MagicSum()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var num = int.Parse(Console.ReadLine());
            var res = new List<int[]>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == num)
                    {
                        res.Add(new int[] { arr[i], arr[j] });
                    }
                }
            }

            foreach (var pair in res)
            {
                Console.WriteLine(string.Join(" ", pair));
            }
        }
    }
}
