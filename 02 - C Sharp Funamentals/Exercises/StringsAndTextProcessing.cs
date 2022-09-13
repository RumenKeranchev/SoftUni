using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_C_Sharp_Funamentals.Exercises
{
    /// <summary>
    /// https://judge.softuni.org/Contests/Compete/Index/1217#0
    /// </summary>
    internal static class StringsAndTextProcessing
    {
        /// <summary>
        /// 01. Valid Usernames
        /// </summary>
        public static void ValidUsernames()
        {
            var input = Console.ReadLine().Split(", ").ToList();

            var result = new List<string>();

            foreach (var line in input)
            {
                if (line.Length >= 3 && line.Length <= 16)
                {
                    var isValid = false;

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (char.IsLetter(line[i]) || char.IsNumber(line[i]) || line[i] == '-' || line[i] == '_')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        result.Add(line);
                    }
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 02. Character Multiplier
        /// </summary>
        public static void CharacterMultiplier()
        {
            var input = Console.ReadLine().Split().ToList();
            var sum = 0;

            if (input[0].Length > input[1].Length)
            {
                for (int i = 0; i < input[0].Length; i++)
                {
                    if (input[1].Length - 1 >= i)
                    {
                        sum += input[0][i] * input[1][i];
                    }
                    else
                    {
                        sum += input[0][i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < input[1].Length; i++)
                {
                    if (input[0].Length - 1 >= i)
                    {
                        sum += input[0][i] * input[1][i];
                    }
                    else
                    {
                        sum += input[1][i];
                    }
                }
            }

            Console.WriteLine(sum);
        }

        /// <summary>
        /// 03. Extract File
        /// </summary>
        public static void ExtractFile()
        {
            var input = Console.ReadLine();

            var lastIndexOfSlash = input.LastIndexOf('\\');
            var lastIndexOfDot = input.LastIndexOf('.');

            var extension = input.Substring(lastIndexOfDot + 1);
            var file = input.Substring(lastIndexOfSlash + 1, lastIndexOfDot - lastIndexOfSlash - 1);

            Console.WriteLine($"File name: {file}");
            Console.WriteLine($"File extension: {extension}");
        }

        /// <summary>
        /// 04. Caesar Cipher
        /// </summary>
        public static void CaesarCipher()
        {
            var input = Console.ReadLine().ToCharArray();

            var sb = new StringBuilder();

            foreach (var chara in input)
            {
                sb.Append((char)(chara + 3));
            }

            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// 05. Multiply Big Number
        /// </summary>
        public static void MultiplyBigNumber()
        {
            var stringInput = Console.ReadLine();
            var input = stringInput.ToArray().Select(c => int.Parse(c.ToString())).ToList();
            var b = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            if (stringInput == "0" || b == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var rem = 0;

            for (int i = input.Count - 1; i >= 0; i--)
            {
                var digit = (input[i] * b) + rem;

                var toAppend = digit % 10;
                rem = digit / 10;

                sb.Insert(0, toAppend);
            }

            if (rem > 0)
            {
                sb.Insert(0, rem);
            }

            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// 06. Replace Repeating Chars
        /// </summary>
        public static void ReplaceRepeatingChars()
        {
            var input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                var chara1 = input[i];
                var len = 0;

                for (int j = i + 1; j <= input.Length - 1; j++)
                {
                    var chara2 = input[j];

                    if (chara1 == chara2)
                    {
                        len++;
                    }
                    else
                    {
                        break;
                    }
                }

                input = input.Remove(i, len);
            }

            Console.WriteLine(input);
        }

        /// <summary>
        /// 07. String Explosion
        /// </summary>
        public static void StringExplosion()
        {
            var input = Console.ReadLine();

            var rem = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == '>')
                {
                    var strength = Math.Max(int.Parse(input[i + 1].ToString()) + rem, 1);
                    var len = 0;

                    for (int j = 1; j <= strength; j++)
                    {
                        if (i + j >= input.Length)
                        {
                            break;
                        }

                        if (input[i + j] == '>')
                        {
                            rem = strength - len;
                            break;
                        }
                        else
                        {
                            len++;
                        }
                    }

                    var remaingingLength = input.Substring(i + 1).Length;

                    len = len > remaingingLength ? remaingingLength : len;

                    input = input.Remove(i + 1, len);
                }
                else
                {
                    continue;
                }
            }

            if (rem > 0)
            {
                var lastIndexOfPunch = input.LastIndexOf('>');
                var remaingingLength = input.Substring(lastIndexOfPunch).Length;

                rem = rem > remaingingLength ? remaingingLength : rem;

                input.Remove(lastIndexOfPunch, rem);
            }

            Console.WriteLine(input);
        }

        /// <summary>
        /// 08. Letters Change Numbers
        /// </summary>
        public static void LettersChangeNumbers()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = new List<decimal>();

            foreach (var item in input)
            {
                var number = decimal.Parse(item.Substring(1, item.Length - 2));
                var firstChar = item[0];
                var firstCharPos = AlphabetPosition(firstChar);
                var secondChar = item[item.Length - 1];
                var secondCharPos = AlphabetPosition(secondChar);

                if (char.IsUpper(firstChar))
                {
                    number /= firstCharPos;
                }
                else
                {
                    number *= firstCharPos;
                }

                if (char.IsUpper(secondChar))
                {
                    number -= secondCharPos;
                }
                else
                {
                    number += secondCharPos;
                }

                result.Add(number);
            }

            Console.WriteLine($"{result.Sum():f2}");

            static int AlphabetPosition(char c)
            {
                return char.ToUpper(c) - 64;
            }
        }
    }
}
