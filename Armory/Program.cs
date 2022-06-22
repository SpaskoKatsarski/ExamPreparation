using System;
using System.Linq;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] armory = new char[n, n];
            int officerRow = 0;
            int officerCol = 0;

            for (int i = 0; i < armory.GetLength(0); i++)
            {
                char[] rowInfo = Console.ReadLine()
                    .ToCharArray();

                for (int j = 0; j < armory.GetLength(1); j++)
                {
                    armory[i, j] = rowInfo[j];

                    if (armory[i, j] == 'A')
                    {
                        officerRow = i;
                        officerCol = j;
                    }
                }
            }

            int collectedCoins = 0;
            
            while (collectedCoins < 65)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    if (!IsIndexValid(armory, officerRow - 1, officerCol))
                    {
                        break;
                    }

                    armory[officerRow, officerCol] = '-';
                    officerRow--;

                    if (char.IsDigit(armory[officerRow, officerCol]))
                    {
                        collectedCoins += int.Parse(armory[officerRow, officerCol].ToString());
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        int mirrorRow = 0;
                        int mirrorCol = 0;

                        armory[officerRow, officerCol] = '-';
                        MoveToOtherMirror(armory, ref mirrorRow, ref mirrorCol);

                        officerRow = mirrorRow;
                        officerCol = mirrorCol;
                    }

                    armory[officerRow, officerCol] = 'A';
                }
                else if (command == "down")
                {
                    if (!IsIndexValid(armory, officerRow + 1, officerCol))
                    {
                        break;
                    }

                    armory[officerRow, officerCol] = '-';
                    officerRow++;

                    if (char.IsDigit(armory[officerRow, officerCol]))
                    {
                        collectedCoins += int.Parse(armory[officerRow, officerCol].ToString());
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        int mirrorRow = 0;
                        int mirrorCol = 0;

                        armory[officerRow, officerCol] = '-';
                        MoveToOtherMirror(armory, ref mirrorRow, ref mirrorCol);

                        officerRow = mirrorRow;
                        officerCol = mirrorCol;
                    }

                    armory[officerRow, officerCol] = 'A';
                }
                else if (command == "left")
                {
                    if (!IsIndexValid(armory, officerRow, officerCol - 1))
                    {
                        break;
                    }

                    armory[officerRow, officerCol] = '-';
                    officerCol--;

                    if (char.IsDigit(armory[officerRow, officerCol]))
                    {
                        collectedCoins += int.Parse(armory[officerRow, officerCol].ToString());
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        int mirrorRow = 0;
                        int mirrorCol = 0;

                        armory[officerRow, officerCol] = '-';
                        MoveToOtherMirror(armory, ref mirrorRow, ref mirrorCol);

                        officerRow = mirrorRow;
                        officerCol = mirrorCol;
                    }

                    armory[officerRow, officerCol] = 'A';
                }
                else if (command == "right")
                {
                    if (!IsIndexValid(armory, officerRow, officerCol + 1))
                    {
                        break;
                    }

                    armory[officerRow, officerCol] = '-';
                    officerCol++;

                    if (char.IsDigit(armory[officerRow, officerCol]))
                    {
                        collectedCoins += int.Parse(armory[officerRow, officerCol].ToString());
                    }
                    else if (armory[officerRow, officerCol] == 'M')
                    {
                        int mirrorRow = 0;
                        int mirrorCol = 0;

                        armory[officerRow, officerCol] = '-';
                        MoveToOtherMirror(armory, ref mirrorRow, ref mirrorCol);

                        officerRow = mirrorRow;
                        officerCol = mirrorCol;
                    }

                    armory[officerRow, officerCol] = 'A';
                }
            }

            if (collectedCoins < 65)
            {
                armory[officerRow, officerCol] = '-';
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {collectedCoins} gold coins.");

            for (int i = 0; i < armory.GetLength(0); i++)
            {
                for (int j = 0; j < armory.GetLength(1); j++)
                {
                    Console.Write(armory[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsIndexValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        public static void MoveToOtherMirror(char[,] matrix, ref int mirrorRow, ref int mirrorCol)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'M')
                    {
                        mirrorRow = i;
                        mirrorCol = j;

                        return;
                    }
                }
            }

            throw new ArgumentException("Second mirror not found.");
        }
    }
}
