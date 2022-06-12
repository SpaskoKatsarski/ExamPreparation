using System;
using System.Linq;

namespace T02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forestField = new char[size, size];

            //Filling the field:
            for (int row = 0; row < forestField.GetLength(0); row++)
            {
                char[] rowInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < forestField.GetLength(1); col++)
                {
                    forestField[row, col] = rowInfo[col];
                }
            }

            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;

            int blackTrufflesEatenByBoar = 0;
            int summerTrufflesEatenByBoar = 0;
            int whiteTrufflesEatenByBoar = 0;

            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Collect")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);

                    if (AreCoordinatesValid(row, col, forestField))
                    {
                        //• Black truffle -'B'
                        //• Summer truffle -'S'
                        //• White truffle -'W'
                        if (forestField[row, col] == 'B')
                        {
                            blackTruffles++;
                            forestField[row, col] = '-';
                        }
                        else if (forestField[row, col] == 'S')
                        {
                            summerTruffles++;
                            forestField[row, col] = '-';
                        }
                        else if (forestField[row, col] == 'W')
                        {
                            whiteTruffles++;
                            forestField[row, col] = '-';
                        }
                    }
                }
                else if (cmdArgs[0] == "Wild_Boar")
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);
                    string direction = cmdArgs[3];

                    if (direction == "right")
                    {
                        for (int i = col; i < forestField.GetLength(1); i += 2)
                        {
                            if (forestField[row, i] == 'B')
                            {
                                blackTrufflesEatenByBoar++;
                                forestField[row, i] = '-';
                            }
                            else if (forestField[row, i] == 'S')
                            {
                                summerTrufflesEatenByBoar++;
                                forestField[row, i] = '-';
                            }
                            else if (forestField[row, i] == 'W')
                            {
                                whiteTrufflesEatenByBoar++;
                                forestField[row, i] = '-';
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2)
                        {
                            if (forestField[row, i] == 'B')
                            {
                                blackTrufflesEatenByBoar++;
                                forestField[row, i] = '-';
                            }
                            else if (forestField[row, i] == 'S')
                            {
                                summerTrufflesEatenByBoar++;
                                forestField[row, i] = '-';
                            }
                            else if (forestField[row, i] == 'W')
                            {
                                whiteTrufflesEatenByBoar++;
                                forestField[row, i] = '-';
                            }
                        }
                    }
                    else if (direction == "up")
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            if (forestField[i, col] == 'B')
                            {
                                blackTrufflesEatenByBoar++;
                                forestField[i, col] = '-';
                            }
                            else if (forestField[i, col] == 'S')
                            {
                                summerTrufflesEatenByBoar++;
                                forestField[i, col] = '-';
                            }
                            else if (forestField[i, col] == 'W')
                            {
                                whiteTrufflesEatenByBoar++;
                                forestField[i, col] = '-';
                            }
                        }
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < forestField.GetLength(0); i += 2)
                        {
                            if (forestField[i, col] == 'B')
                            {
                                blackTrufflesEatenByBoar++;
                                forestField[i, col] = '-';
                            }
                            else if (forestField[i, col] == 'S')
                            {
                                summerTrufflesEatenByBoar++;
                                forestField[i, col] = '-';
                            }
                            else if (forestField[i, col] == 'W')
                            {
                                whiteTrufflesEatenByBoar++;
                                forestField[i, col] = '-';
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {blackTrufflesEatenByBoar + summerTrufflesEatenByBoar + whiteTrufflesEatenByBoar} truffles.");

            for (int row = 0; row < forestField.GetLength(0); row++)
            {
                for (int col = 0; col < forestField.GetLength(1); col++)
                {
                    Console.Write($"{forestField[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        public static bool AreCoordinatesValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
