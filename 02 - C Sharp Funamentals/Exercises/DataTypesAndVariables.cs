using System;
using System.Numerics;

namespace _02_C_Sharp_Funamentals.Exercises
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Compete/Index/1205#0
    /// </summary>
    public static class DataTypesAndVariables
    {
        /// <summary>
        /// 01
        /// </summary>
        public static void IntegerOperations()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var d = int.Parse(Console.ReadLine());

            long result = ((a + b) / c) * d;

            Console.WriteLine(result);
        }

        /// <summary>
        /// 02
        /// </summary>
        public static void SumDigits()
        {
            var a = int.Parse(Console.ReadLine());
            var sum = 0;

            while (a > 0)
            {
                sum += a % 10;
                a /= 10;
            }

            Console.WriteLine(sum);
        }

        /// <summary>
        /// 03
        /// </summary>
        public static void Elevator()
        {
            var a = decimal.Parse(Console.ReadLine());
            var b = decimal.Parse(Console.ReadLine());

            var c = Math.Ceiling(a / b);

            Console.WriteLine(c);
        }

        /// <summary>
        /// 04
        /// </summary>
        public static void SumOfChars()
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = 0; i < n; i++)
            {
                var character = (int)char.Parse(Console.ReadLine());
                sum += character;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }

        /// <summary>
        /// 05
        /// </summary>
        private static void PrintPartOfASCIITable()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }

        /// <summary>
        /// 06
        /// </summary>
        public static void TriplesOfLatinLetters()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.WriteLine($"{(char)(97 + i)}{(char)(97 + j)}{(char)(97 + k)}");
                    }
                }
            }
        }

        /// <summary>
        /// 07
        /// </summary>
        private static void WaterOverflow()
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = 0; i < n; i++)
            {
                var a = int.Parse(Console.ReadLine());

                if (sum + a <= 255)
                {
                    sum += a;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(sum);
        }

        /// <summary>
        /// 08
        /// </summary>
        public static void BeerKegs()
        {
            var n = int.Parse(Console.ReadLine());
            var name = "";
            var sum = 0d;

            for (int i = 0; i < n; i++)
            {
                var label = Console.ReadLine();
                var radius = double.Parse(Console.ReadLine());
                var height = int.Parse(Console.ReadLine());

                var volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > sum)
                {
                    sum = volume;
                    name = label;
                }
            }

            Console.WriteLine(name);
        }

        /// <summary>
        /// 09
        /// </summary>
        public static void SpiceMustFlow()
        {
            var start = int.Parse(Console.ReadLine());
            var sum = 0;
            var count = 0;

            while (start >= 100)
            {
                sum += start - 26;
                start -= 10;
                count++;
            }

            if (sum >= 26)
            {
                sum -= 26;
            }

            Console.WriteLine(count);
            Console.WriteLine(sum);
        }

        /// <summary>
        /// 10
        /// </summary>
        public static void PokeMon()
        {
            var n = int.Parse(Console.ReadLine());
            var n1 = n;
            var m = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());

            var pokes = 0;

            while (n1 >= m)
            {
                n1 -= m;
                pokes++;

                if (n / 2 == n1)
                {
                    if (y > 0)
                    {
                        n1 /= y;
                    }
                }
            }

            Console.WriteLine(n1);
            Console.WriteLine(pokes);
        }

        /// <summary>
        /// 11
        /// </summary>
        public static void Snowballs()
        {
            var n = int.Parse(Console.ReadLine());
            BigInteger sum = 0;
            var snowVal = 0;
            var timeVal = 0;
            var qualityVal = 0;

            for (int i = 0; i < n; i++)
            {
                var snow = int.Parse(Console.ReadLine());
                var time = int.Parse(Console.ReadLine());
                var quality = int.Parse(Console.ReadLine());

                BigInteger value = BigInteger.Pow(snow / time, quality);

                if (value > sum)
                {
                    sum = value;
                    snowVal = snow;
                    timeVal = time;
                    qualityVal = quality;
                }
            }

            Console.WriteLine($"{snowVal} : {timeVal} = {sum} ({qualityVal})");
        }
    }
}
