using System;
using System.Collections.Generic;
using System.Linq;

namespace Armory
{
    internal class Program
    {
        /// <summary>
        /// 100/100
        /// https://judge.softuni.org/Contests/Practice/Index/3285#1
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var armory = new char[n, n];
            var officerPosition = (row: 0, col: 0);
            var firstMirror = (row: -1, col: -1);
            var secondMirror = (row: -1, col: -1);
            var boughtItems = 0;

            for (int row = 0; row < n; row++)
            {
                var inputArr = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    armory[row, col] = inputArr[col];

                    if (inputArr[col] == 'A')
                    {
                        officerPosition.row = row;
                        officerPosition.col = col;
                    }
                    else if (inputArr[col] == 'M')
                    {
                        if (firstMirror.row == -1)
                        {
                            firstMirror.row = row;
                            firstMirror.col = col;
                        }
                        else
                        {
                            secondMirror.row = row;
                            secondMirror.col = col;
                        }
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "right")
                {
                    if (NavigateArmory(armory, ref boughtItems, ref officerPosition, secondMirror, 0, 1))
                    {
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (NavigateArmory(armory, ref boughtItems, ref officerPosition, secondMirror, 0, -1))
                    {
                        break;
                    }
                }
                else if (command == "up")
                {
                    if (NavigateArmory(armory, ref boughtItems, ref officerPosition, secondMirror, -1, 0))
                    {
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (NavigateArmory(armory, ref boughtItems, ref officerPosition, secondMirror, 1, 0))
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"The king paid {boughtItems} gold coins. ");
            PrintMatrix(armory);
        }

        static bool ValidateOfficerPosition(char[,] armory, ref (int row, int col) officerPosition, int rowOffset, int colOffset)
        {
            if (officerPosition.row + rowOffset < 0 || officerPosition.row + rowOffset >= armory.GetLength(0)
                || officerPosition.col + colOffset < 0 || officerPosition.col + colOffset >= armory.GetLength(1))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"I do not need more swords!");
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsCurrentPositionMirror(char[,] armory, ref (int row, int col) officerPosition, int rowOffset, int colOffset)
        {
            if (armory[officerPosition.row + rowOffset, officerPosition.col + colOffset] == 'M')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsCurrentPositionSword(char[,] armory, ref (int row, int col) officerPosition, int rowOffset, int colOffset)
        {
            if (char.IsDigit(armory[officerPosition.row + rowOffset, officerPosition.col + colOffset]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool NavigateArmory(char[,] armory, ref int boughtItems, ref (int row, int col) officerPosition, (int row, int col) secondMirror, int rowOffset, int colOffset)
        {
            if (ValidateOfficerPosition(armory, ref officerPosition, rowOffset, colOffset))
            {
                armory[officerPosition.row, officerPosition.col] = '-';
                officerPosition.row += rowOffset;
                officerPosition.col += colOffset;
                return true;
            }
            else if (IsCurrentPositionMirror(armory, ref officerPosition, rowOffset, colOffset))
            {
                armory[officerPosition.row, officerPosition.col] = '-';
                armory[officerPosition.row + rowOffset, officerPosition.col + colOffset] = '-';
                armory[secondMirror.row, secondMirror.col] = 'A';

                officerPosition = secondMirror;
                return false;
            }
            else if (IsCurrentPositionSword(armory, ref officerPosition, rowOffset, colOffset))
            {
                boughtItems += int.Parse(armory[officerPosition.row + rowOffset, officerPosition.col + colOffset].ToString());

                armory[officerPosition.row, officerPosition.col] = '-';
                armory[officerPosition.row + rowOffset, officerPosition.col + colOffset] = 'A';

                officerPosition.row += rowOffset;
                officerPosition.col += colOffset;
                var shouldBreak = boughtItems >= 65;

                if (shouldBreak)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Very nice swords, I will come back for more!");
                }

                return shouldBreak;
            }
            else
            {
                armory[officerPosition.row, officerPosition.col] = '-';
                armory[officerPosition.row + rowOffset, officerPosition.col + colOffset] = 'A';

                officerPosition.row += rowOffset;
                officerPosition.col += colOffset;
                return false;
            }
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
