using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02
{
    internal class Program
    {
        /// <summary>
        /// 02. Beaver at Work
        /// 100/100
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pond = new char[n, n];
            var beaverPosition = (row: 0, col: 0);
            var branches = new List<char>();

            for (int row = 0; row < n; row++)
            {
                var inputArr = Console.ReadLine().Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var cleaned = string.Join("", inputArr).ToCharArray();


                for (int col = 0; col < n; col++)
                {
                    pond[row, col] = cleaned[col];

                    if (cleaned[col] == 'B')
                    {
                        beaverPosition.row = row;
                        beaverPosition.col = col;
                    }
                }
            }

            var command = Console.ReadLine();

            while (command != "end")
            {

                if (command == "right")
                {
                    NavigatePond(pond, branches, ref beaverPosition, 0, 1, false);
                }
                else if (command == "left")
                {
                    NavigatePond(pond, branches, ref beaverPosition, 0, -1, false);
                }
                else if (command == "up")
                {
                    NavigatePond(pond, branches, ref beaverPosition, -1, 0, true);
                }
                else if (command == "down")
                {
                    NavigatePond(pond, branches, ref beaverPosition, 1, 0, true);
                }


                if (GetRemainingBranches(pond) == 0)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            var allBranches = GetRemainingBranches(pond);

            Console.ForegroundColor = ConsoleColor.Red;
            if (allBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {allBranches} branches left.");
            }

            PrintMatrix(pond);
        }

        private static int GetRemainingBranches(char[,] pond)
        {
            var allBranches = 0;
            foreach (var row in pond)
            {
                if (char.IsLetter(row) && char.IsLower(row))
                {
                    allBranches++;
                }
            }

            return allBranches;
        }

        static bool ValidateBeaverPosition(char[,] pond, ref (int row, int col) beaverPosition, int rowOffset, int colOffset, List<char> branches)
        {
            if (beaverPosition.row + rowOffset < 0 || beaverPosition.row + rowOffset >= pond.GetLength(0)
                || beaverPosition.col + colOffset < 0 || beaverPosition.col + colOffset >= pond.GetLength(1))
            {
                branches.Remove(branches.LastOrDefault());
                return true;
            }

            return false;
        }

        static bool IsCurrentPositionWood(char[,] pond, ref (int row, int col) beaverPosition, int rowOffset, int colOffset, List<char> branches)
        {
            var currentPosition = pond[beaverPosition.row + rowOffset, beaverPosition.col + colOffset];

            if (char.IsLower(currentPosition))
            {
                branches.Add(currentPosition);
                return true;
            }

            return false;
        }

        static bool IsCurrentPositionFish(char[,] pond, ref (int row, int col) beaverPosition, int rowOffset, int colOffset)
        {
            if (pond[beaverPosition.row + rowOffset, beaverPosition.col + colOffset] == 'F')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void NavigatePond(char[,] pond, List<char> branches, ref (int row, int col) beaverPosition, int rowOffset, int colOffset, bool upDown)
        {
            if (ValidateBeaverPosition(pond, ref beaverPosition, rowOffset, colOffset, branches))
            {
                //PrintMatrix(pond);
                return;
            }

            if (IsCurrentPositionWood(pond, ref beaverPosition, rowOffset, colOffset, branches))
            {
                pond[beaverPosition.row, beaverPosition.col] = '-';
                pond[beaverPosition.row + rowOffset, beaverPosition.col + colOffset] = 'B';
                beaverPosition.row += rowOffset;
                beaverPosition.col += colOffset;
            }
            else if (IsCurrentPositionFish(pond, ref beaverPosition, rowOffset, colOffset))
            {
                var fishPosition = (row: beaverPosition.row + rowOffset, col: beaverPosition.col + colOffset);
                pond[beaverPosition.row, beaverPosition.col] = '-';
                pond[fishPosition.row, fishPosition.col] = '-';
                beaverPosition.row += rowOffset;
                beaverPosition.col += colOffset;

                //up/down

                if (upDown)
                {
                    if (fishPosition.row == 0 && rowOffset == -1)
                    {
                        pond[pond.GetLength(0) - 1, beaverPosition.col] = 'B';
                        beaverPosition.row = pond.GetLength(0) - 1;

                        IsCurrentPositionWood(pond, ref beaverPosition, 0, 0, branches);
                    }
                    else if (fishPosition.row == pond.GetLength(0) - 1 && rowOffset == 1)
                    {
                        pond[0, beaverPosition.col] = 'B';
                        beaverPosition.row = 0;

                        IsCurrentPositionWood(pond, ref beaverPosition, 0, 0, branches);
                    }
                    else
                    {
                        pond[pond.GetLength(0) - 1, beaverPosition.col] = 'B';
                        beaverPosition.row = pond.GetLength(0) - 1;

                        IsCurrentPositionWood(pond, ref beaverPosition, 0, 0, branches);
                    }
                }
                else
                {
                    //left/right
                    if (fishPosition.col == 0 && colOffset == -1)
                    {
                        pond[beaverPosition.row, pond.GetLength(1) - 1] = 'B';
                        beaverPosition.col = pond.GetLength(1) - 1;

                        IsCurrentPositionWood(pond, ref beaverPosition, 0, 0, branches);
                    }
                    else if (fishPosition.col == pond.GetLength(1) - 1 && colOffset == 1)
                    {
                        pond[beaverPosition.row, 0] = 'B';
                        beaverPosition.col = 0;

                        IsCurrentPositionWood(pond, ref beaverPosition, 0, 0, branches);
                    }
                    else
                    {
                        pond[beaverPosition.row, pond.GetLength(1) - 1] = 'B';
                        beaverPosition.col = pond.GetLength(1) - 1;

                        IsCurrentPositionWood(pond, ref beaverPosition, 0, 0, branches);
                    }
                }
            }
            else
            {
                pond[beaverPosition.row, beaverPosition.col] = '-';
                pond[beaverPosition.row + rowOffset, beaverPosition.col + colOffset] = 'B';

                beaverPosition.row += rowOffset;
                beaverPosition.col += colOffset;
            }

            //PrintMatrix(pond);
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            var sb = new StringBuilder();

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = "";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row += matrix[i, j] + " ";
                }

                sb.AppendLine(row.Trim());
            }

            Console.WriteLine(sb.ToString());
            Console.ResetColor();
        }
    }
}
