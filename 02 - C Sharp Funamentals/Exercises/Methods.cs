using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_C_Sharp_Funamentals.Exercises
{
    /// <summary>
    /// https://judge.softuni.org/Contests/1209/Methods-Exercise
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// 1. Smallest of Three Numbers
        /// </summary>
        public static void SmallestOfThreeNumbers()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());

            var smallestBetween2 = GetSmallest(a, b);
            Console.WriteLine(GetSmallest(smallestBetween2, c));
        }

        private static int GetSmallest(int a, int b)
        {
            return a > b ? b : a;
        }



        /// <summary>
        /// 2. Vowels Count
        /// </summary>
        public static void VowelsCount()
        {
            var input = Console.ReadLine().ToLowerInvariant().ToCharArray();
            Console.WriteLine(CalculateVowels(input));
        }

        private static int CalculateVowels(char[] input)
        {
            var count = 0;
            var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            foreach (var characted in input)
            {
                if (vowels.Contains(characted))
                {
                    count++;
                }
            }

            return count;
        }



        /// <summary>
        /// 3. Characters in Range
        /// </summary>
        public static void CharactersInRange()
        {
            var char1 = char.Parse(Console.ReadLine());
            var char2 = char.Parse(Console.ReadLine());
            PrintCharactesInBewtween(char1, char2);
        }

        private static void PrintCharactesInBewtween(char char1, char char2)
        {
            var from = (int)char2 < (int)char1 ? char2 : char1;
            var to = (int)char2 < (int)char1 ? char1 : char2;

            for (int i = from + 1; i < to; i++)
            {
                Console.Write((char)i + " ");
            }
        }



        /// <summary>
        /// 4. Password Validator
        /// </summary>
        public static void PasswordValidator()
        {
            var password = Console.ReadLine();

            var validLength = ValidateLength(password);
            var validLettersAndDigits = ValidateLettersAndNumbers(password);
            var validNumberOfDigits = ValidateNumberOfDigits(password);

            if (validLength && validLettersAndDigits && validNumberOfDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool ValidateLettersAndNumbers(string password)
        {
            foreach (var chara in password)
            {
                if (!char.IsLetterOrDigit(chara))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateNumberOfDigits(string password)
        {
            var digitsCounter = 0;
            foreach (var chara in password)
            {
                if (char.IsNumber(chara))
                {
                    digitsCounter++;
                }
            }
            if (digitsCounter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                return false;
            }

            return true;
        }

        private static bool ValidateLength(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }

            return true;
        }



        /// <summary>
        /// 5. Add and Subtract
        /// </summary>
        public static void AddAndSubtract()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());

            var d = SumNumbers(a, b);
            Console.WriteLine(SubtractNumbers(d, c));
        }

        private static int SumNumbers(int a, int b)
        {
            return a + b;
        }

        private static int SubtractNumbers(int a, int b)
        {
            return a - b;
        }



        /// <summary>
        /// 6. Middle Characters
        /// </summary>
        public static void MiddleCharacters()
        {
            var input = Console.ReadLine();
            GetMiddleCharactes(input);
        }

        private static void GetMiddleCharactes(string input)
        {
            var isEven = input.Length % 2 == 0;
            var index = input.Length / 2;

            var arr = input.ToCharArray();
            if (isEven)
            {
                Console.WriteLine(arr[index - 1].ToString() + arr[index].ToString());
            }
            else
            {
                Console.WriteLine(arr[index]);
            }
        }



        /// <summary>
        ///7. NxN Matrix
        /// </summary>
        public static void NxNMatrix()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                WriteRows(n);
            }
        }

        private static void WriteRows(int n)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();
        }



        /// <summary>
        /// 8. Factorial Division
        /// </summary>
        public static void FactorialDivision()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var aL = CalculateFactorial(a);
            var bL = CalculateFactorial(b);

            double res = aL * 1.0 / bL;

            Console.WriteLine($"{res:f2}");
        }

        private static long CalculateFactorial(int n)
        {
            var res = 1L;
            for (int i = 1; i <= n; i++)
            {
                res *= i;
            }

            return res;
        }



        /// <summary>
        /// 09. Palindrome Integers
        /// </summary>
        public static void PalindromeIntegers()
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                var isPalindrome = true;
                var arr = input.ToCharArray();

                isPalindrome = ValidatePalindromString(isPalindrome, arr);

                input = Console.ReadLine();
            }
        }

        private static bool ValidatePalindromString(bool isPalindrome, char[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                {
                    isPalindrome = false;
                }
            }

            Console.WriteLine(isPalindrome);
            return isPalindrome;
        }



        /// <summary>
        /// 10. Top Number
        /// </summary>
        public static void TopNumber()
        {
            var input = int.Parse(Console.ReadLine());

            for (int i = 1; i < input; i++)
            {
                var isDivisibleBy8 = IsDivisibleBy8(i);
                var containsOddDigit = ContainsOddDigit(i);

                if (isDivisibleBy8 && containsOddDigit)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsDivisibleBy8(int input)
        {
            var sum = 0;

            while (input > 0)
            {
                var digit = input % 10;
                sum += digit;
                input /= 10;
            }

            return sum % 8 == 0;
        }

        static bool ContainsOddDigit(int input)
        {
            var hasOddDigit = false;

            while (input > 0)
            {
                var digit = input % 10;

                if (digit % 2 != 0)
                {
                    hasOddDigit = true;
                    break;
                }

                input /= 10;
            }

            return hasOddDigit;
        }



        /// <summary>
        /// 11. Array Manipulator
        /// </summary>
        public static void ArrayManipulator()
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var input = Console.ReadLine();
            while (input != "end")
            {
                var commands = input.Split().ToArray();

                switch (commands[0])
                {
                    case "exchange":
                        arr = ExchangeCommand(arr, commands);
                        break;
                    case "max":
                        GetIndex(arr, false, commands[1] == "even" ? 0 : 1);
                        break;
                    case "min":
                        GetIndex(arr, true, commands[1] == "even" ? 0 : 1);
                        break;
                    case "first":
                    case "last":
                        FindNumbers(arr, commands);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static void FindNumbers(int[] arr, string[] commands)
        {
            var isFirst = commands[0] == "first";
            var n = int.Parse(commands[1]);
            var isEven = commands[2] == "even" ? 0 : 1;

            if (n > arr.Length || n < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (n == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            var nums = new List<int>();
            var count = 0;

            if (isFirst)
            {

                foreach (var num in arr)
                {
                    if (num % 2 == isEven)
                    {
                        count++;
                        nums.Add(num);
                    }

                    if (count == n)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    if (arr[i] % 2 == isEven)
                    {
                        count++;
                        nums.Add(arr[i]);
                    }

                    if (count == n)
                    {
                        break;
                    }
                }

                nums.Reverse();
            }

            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        private static void GetIndex(int[] arr, bool min, int isEven)
        {
            var index = -1;
            var num = min ? int.MaxValue : int.MinValue;
            var hasMatches = arr.Any(r => r % 2 == isEven);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == isEven)
                {
                    if (min && num >= arr[i])
                    {
                        num = arr[i];
                        index = i;
                    }
                    else if (!min && num <= arr[i])
                    {
                        num = arr[i];
                        index = i;
                    }
                }
            }

            if (index == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static int[] ExchangeCommand(int[] arr, string[] commands)
        {
            var index = int.Parse(commands[1]);
            var newArr = new int[arr.Length];

            if (index >= arr.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }

            newArr = new int[arr.Length];
            var newArrIndex = 0;

            for (int i = index + 1; i < arr.Length; i++)
            {
                newArr[newArrIndex] = arr[i];
                newArrIndex++;
            }

            for (int i = 0; i <= index; i++)
            {
                newArr[newArrIndex] = arr[i];
                newArrIndex++;
            }

            return newArr;
        }
    }
}
