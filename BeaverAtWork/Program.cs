using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                char[] rowInfo = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rowInfo[j];
                }
            }

            int beaverRow = 0;
            int beaverCol = 0;
            bool foundBeaver = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                        foundBeaver = true;
                        break;
                    }
                }

                if (foundBeaver)
                {
                    break;
                }
            }

            Stack<char> branches = new Stack<char>();
            bool hasMoreBranches = true;

            string command;
            while ((command = Console.ReadLine()) != "end" && hasMoreBranches)
            {
                if (command == "up")
                {
                    matrix[beaverRow, beaverCol] = '-';
                    if (IsAtBorder(matrix, beaverRow - 1, beaverCol))
                    {
                        if (branches.Count > 0)
                            branches.Pop();
                    }
                    else
                    {
                        beaverRow--;
                    }

                    if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        if (beaverRow - 1 < 0)
                        {
                            //Opposite direction
                            matrix[beaverRow, beaverCol] = '-';
                            beaverRow = matrix.GetLength(0) - 1;
                        }
                        else
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            beaverRow = 0;
                        }
                    }

                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branches.Push(matrix[beaverRow, beaverCol]);
                    }

                    matrix[beaverRow, beaverCol] = 'B';
                }
                else if (command == "down")
                {
                    matrix[beaverRow, beaverCol] = '-';

                    if (IsAtBorder(matrix, beaverRow + 1, beaverCol))
                    {
                        if (branches.Count > 0)
                            branches.Pop();
                    }
                    else
                    {
                        beaverRow++;
                    }

                    if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';

                        if (beaverRow + 1 >= matrix.GetLength(0))
                        {
                            //Opposite direction
                            beaverRow = 0;
                        }
                        else
                        {
                            beaverRow = matrix.GetLength(0) - 1;
                        }
                    }

                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branches.Push(matrix[beaverRow, beaverCol]);
                    }

                    matrix[beaverRow, beaverCol] = 'B';
                }
                else if (command == "left")
                {
                    matrix[beaverRow, beaverCol] = '-';

                    if (IsAtBorder(matrix, beaverRow, beaverCol - 1))
                    {
                        if (branches.Count > 0)
                            branches.Pop();
                    }
                    else
                    {
                        beaverCol--;
                    }

                    if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';

                        if (matrix[beaverRow, beaverCol - 1] < 0)
                        {
                            //Opposite direction
                            beaverCol = matrix.GetLength(1) - 1;
                        }
                        else
                        {
                            beaverCol = 0;
                        }
                    }

                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branches.Push(matrix[beaverRow, beaverCol]);
                    }

                    matrix[beaverRow, beaverCol] = 'B';
                }
                else if (command == "right")
                {
                    matrix[beaverRow, beaverCol] = '-';

                    if (IsAtBorder(matrix, beaverRow, beaverCol + 1))
                    {
                        if (branches.Count > 0)
                            branches.Pop();
                    }
                    else
                    {
                        beaverCol++;
                    }

                    if (matrix[beaverRow, beaverCol] == 'F')
                    {
                        matrix[beaverRow, beaverCol] = '-';

                        if (matrix[beaverRow, beaverCol - 1] < 0)
                        {
                            //Opposite direction
                            beaverCol = matrix.GetLength(1) - 1;
                        }
                        else
                        {
                            beaverCol = 0;
                        }
                    }

                    if (char.IsLower(matrix[beaverRow, beaverCol]))
                    {
                        branches.Push(matrix[beaverRow, beaverCol]);
                    }

                    matrix[beaverRow, beaverCol] = 'B';
                }

                hasMoreBranches = false;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (char.IsLower(matrix[row, col]))
                        {
                            hasMoreBranches = true;
                            break;
                        }
                    }

                    if (hasMoreBranches)
                    {
                        break;
                    }
                }
            }

            int branchesLeft = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (char.IsLower(matrix[row, col]))
                    {
                        branchesLeft++;
                    }
                }
            }

            if (!hasMoreBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse().ToList())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesLeft} branches left.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }

        }

        public static bool IsAtBorder(char[,] matrix, int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }
    }
}
