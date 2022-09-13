using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _03_C_Sharp_Advanced.Exercises
{
    public static class MultidimensionalArrays
    {
        private static void PrintMatrix<T>(T[,] matrix)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
            Console.ResetColor();
        }

        /// <summary>
        /// 1. Diagonal Difference
        /// </summary>
        public static void DiagonalDifference()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = inputArr[j];
                }
            }

            var sum1 = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum1 += matrix[i, i];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    sum1 -= matrix[i, j];
                    i++;
                }
            }

            Console.WriteLine(Math.Abs(sum1));
        }

        /// <summary>
        /// 2. Squares in Matrix
        /// </summary>
        public static void SquaresInMatrix()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new string[dimensions[0], dimensions[1]];

            var count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var allSame = new List<string> { matrix[i, j], matrix[i, j + 1], matrix[i + 1, j], matrix[i + 1, j + 1] }.Distinct().Count() == 1;

                    if (allSame && matrix[i, j] == matrix[i, j + 1] && matrix[i + 1, j] == matrix[i + 1, j + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        /// <summary>
        /// 3. Maximal Sum 80/100
        /// </summary>
        public static void MaximalSum()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new int[dimensions[0], dimensions[1]];

            var sum = 0;
            var sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    var row1 = new List<int> { matrix[i, j], matrix[i, j + 1], matrix[i, j + 2] };
                    var row2 = new List<int> { matrix[i + 1, j], matrix[i + 1, j + 1], matrix[i + 1, j + 2] };
                    var row3 = new List<int> { matrix[i + 2, j], matrix[i + 2, j + 1], matrix[i + 2, j + 2] };

                    var currentSum = row1.Sum() + row2.Sum() + row3.Sum();

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        sb.Clear();
                        sb.AppendLine(string.Join(" ", row1));
                        sb.AppendLine(string.Join(" ", row2));
                        sb.AppendLine(string.Join(" ", row3));
                    }
                }
            }

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// 4. Matrix Shuffling
        /// </summary>
        public static void MatrixShuffling()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new string[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var parameters = input.Split().ToArray();
                if (parameters[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    var swapFromRowBool = int.TryParse(parameters[1], out var swapFromRow);
                    var swapFromColBool = int.TryParse(parameters[2], out var swapFromCol);

                    var swapToRowBool = int.TryParse(parameters[3], out var swapToRow);
                    var swapToColBool = int.TryParse(parameters[4], out var swapToCol);

                    if (!swapFromRowBool || !swapFromColBool || !swapToRowBool || !swapToColBool
                        || swapFromRow >= matrix.GetLength(0) || swapFromRow < 0
                        || swapFromCol >= matrix.GetLength(1) || swapFromCol < 0
                        || swapToRow >= matrix.GetLength(0) || swapToRow < 0
                        || swapToCol >= matrix.GetLength(1) || swapToCol < 0
                        || parameters.Skip(1).Count() > 4)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        var toVal = matrix[swapToRow, swapToCol];

                        matrix[swapToRow, swapToCol] = matrix[swapFromRow, swapFromCol];
                        matrix[swapFromRow, swapFromCol] = toVal;

                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write(matrix[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 5. Snake Moves
        /// </summary>
        public static void SnakeMoves()
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var snake = Console.ReadLine().ToList();
            var matrix = new char[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var snakeList = new List<char>(snake);

                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = snakeList.FirstOrDefault();
                        snakeList.Remove(snakeList.FirstOrDefault());

                        if (!snakeList.Any())
                        {
                            snakeList = new List<char>(snake);
                        }
                    }
                }
                else
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        matrix[i, j] = snakeList.FirstOrDefault();
                        snakeList.Remove(snakeList.FirstOrDefault());

                        if (!snakeList.Any())
                        {
                            snakeList = new List<char>(snake);
                        }
                    }
                }

                snakeList.Reverse();
                while (snakeList.Any())
                {
                    snake.Insert(0, snakeList[0]);
                    snakeList.RemoveAt(0);
                    snake.RemoveAt(snake.Count - 1);
                }
            }

            PrintMatrix(matrix);
        }

        /// <summary>
        /// 6. Jagged Array Manipulator 87/100
        /// </summary>
        public static void JaggedArrayManipulator()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new BigInteger[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();
            }

            for (int i = 0; i <= n - 2; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] /= 2;
                    }

                    if (i + 1 <= n)
                    {
                        for (int j = 0; j < matrix[i + 1].Length; j++)
                        {
                            matrix[i + 1][j] /= 2;
                        }
                    }
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (input.StartsWith("Add"))
                {
                    var parameteres = input.Split().Skip(1).Select(long.Parse).ToArray();
                    var row = parameteres[0];
                    var col = parameteres[1];
                    var value = parameteres[2];

                    if (row >= 0 && row < matrix.Length)
                    {
                        if (col >= 0 && col < matrix[row].Length)
                        {
                            matrix[row][col] += value;
                        }
                    }

                }
                else if (input.StartsWith("Subtract"))
                {
                    var parameteres = input.Split().Skip(1).Select(long.Parse).ToArray();
                    var row = parameteres[0];
                    var col = parameteres[1];
                    var value = parameteres[2];

                    if (row >= 0 && row < matrix.Length)
                    {
                        if (col >= 0 && col < matrix[row].Length)
                        {
                            matrix[row][col] -= value;
                        }
                    }
                }
            }

            foreach (var item in matrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        /// <summary>
        /// 7. Knight Game
        /// </summary>
        public static void KnightGame()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            var count = 0;

            while (true)
            {
                var maxAttacks = 0;
                var knightRow = 0;
                var knightCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == '0')
                        {
                            continue;
                        }

                        var currentMax = 0;

                        //top
                        CalculateAttacks(ref currentMax, matrix, row + 2, col - 1);
                        CalculateAttacks(ref currentMax, matrix, row + 2, col + 1);

                        //right
                        CalculateAttacks(ref currentMax, matrix, row + 1, col + 2);
                        CalculateAttacks(ref currentMax, matrix, row - 1, col + 2);

                        //bot
                        CalculateAttacks(ref currentMax, matrix, row - 2, col + 1);
                        CalculateAttacks(ref currentMax, matrix, row - 2, col - 1);

                        //left
                        CalculateAttacks(ref currentMax, matrix, row + 1, col - 2);
                        CalculateAttacks(ref currentMax, matrix, row - 1, col - 2);

                        if (currentMax > maxAttacks)
                        {
                            maxAttacks = currentMax;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    matrix[knightRow, knightCol] = '0';
                    count++;
                }
                else
                {
                    Console.WriteLine(count);
                    break;
                }
            }

            static void CalculateAttacks(ref int currentMax, char[,] matrix, int row, int col)
            {
                if (ValidateRowCol(matrix, row, col) && matrix[row, col] == 'K')
                {
                    currentMax++;
                }

                static bool ValidateRowCol(char[,] matrix, int row, int col)
                {
                    return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
                }
            }
        }

        /// <summary>
        /// 8. Bombs 90/100
        /// </summary>
        public static void Bombs()
        {
            var n = int.Parse(Console.ReadLine());
            var field = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = input[j];
                }
            }

            var commands = new Queue<List<int>>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(i => i.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()));

            while (commands.Any())
            {
                var command = commands.Dequeue();
                var row = command[0];
                var col = command[1];
                var bomb = field[row, col];

                //top
                CalculateCell(field, row - 1, col - 1, bomb);
                CalculateCell(field, row - 1, col, bomb);
                CalculateCell(field, row - 1, col + 1, bomb);

                //mid
                CalculateCell(field, row, col - 1, bomb);
                CalculateCell(field, row, col + 1, bomb);

                //bot
                CalculateCell(field, row + 1, col - 1, bomb);
                CalculateCell(field, row + 1, col, bomb);
                CalculateCell(field, row + 1, col + 1, bomb);

                field[row, col] = 0;
            }

            var sum = 0;
            var activeCells = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] > 0)
                    {
                        sum += field[i, j];
                        activeCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix(field);

            static bool CalculateCell(int[,] field, int row, int col, int bomb)
            {
                if (ValidateRowCol(field, row, col) && bomb > 0 && field[row, col] > 0)
                {
                    field[row, col] -= bomb;
                    return true;
                }

                return false;

                static bool ValidateRowCol(int[,] matrix, int row, int col)
                {
                    return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
                }
            }
        }
    }
}
