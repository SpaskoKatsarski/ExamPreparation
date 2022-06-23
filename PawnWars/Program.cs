using System;
using System.Collections.Generic;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBoard = new char[8, 8];

            int whiteRow = 0;
            int whiteCol = 0;

            int blackRow = 0;
            int blackCol = 0;

            for (int row = 0; row < 8; row++)
            {
                char[] rowInfo = Console.ReadLine().ToCharArray();

                for (int col = 0; col < 8; col++)
                {
                    if (rowInfo[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (rowInfo[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }

                    chessBoard[row, col] = rowInfo[col];
                }
            }

            while (true)
            {
                if (IsIndexValid(chessBoard, whiteRow - 1, whiteCol - 1) && chessBoard[whiteRow - 1, whiteCol - 1] == 'b')
                {
                    //We capture the black at the top left corner
                    char winLetter = GiveWinLetter(blackCol);
                    char winNumber = GiveWinNumber(blackRow);

                    Console.WriteLine($"Game over! White capture on {winLetter}{winNumber}."); //coordinates of black pawn
                    return;
                }
                else if (IsIndexValid(chessBoard, whiteRow - 1, whiteCol + 1) && chessBoard[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    //We capture the black at the top right corner
                    char winLetter = GiveWinLetter(blackCol);
                    char winNumber = GiveWinNumber(blackRow);

                    Console.WriteLine($"Game over! White capture on {winLetter}{winNumber}."); //coordinates of black pawn
                    return;
                }
                else
                {
                    whiteRow--;
                }

                if (whiteRow == 0)
                {
                    char finishLetter = FindFinishLetter(whiteCol);

                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {finishLetter}8.");
                    return;
                }
                else
                {
                    chessBoard[whiteRow + 1, whiteCol] = '-';
                    chessBoard[whiteRow, whiteCol] = 'w';
                }



                //---------------Black Logic--------------------
                if (IsIndexValid(chessBoard, blackRow + 1, blackRow - 1) && chessBoard[blackRow + 1, blackCol - 1] == 'w')
                {
                    //We capture the white at the bottom left corner
                    char winLetter = GiveWinLetter(whiteCol);
                    char winNumber = GiveWinNumber(whiteRow);

                    Console.WriteLine($"Game over! Black capture on {winLetter}{winNumber}."); //coordinates of white pawn
                    return;
                }
                else if (IsIndexValid(chessBoard, blackRow + 1, blackRow + 1) && chessBoard[blackRow + 1, blackRow + 1] == 'w')
                {
                    //We capture the white at the bottom right corner
                    char winLetter = GiveWinLetter(whiteCol);
                    char winNumber = GiveWinNumber(whiteRow);

                    Console.WriteLine($"Game over! Black capture on {winLetter}{winNumber}."); //coordinates of white pawn
                    return;
                }
                else
                {
                    blackRow++;
                }

                if (blackRow == 7)
                {
                    char finishLetter = FindFinishLetter(blackCol);

                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {finishLetter}1.");
                    return;
                }
                else
                {
                    chessBoard[blackRow - 1, blackCol] = '-';
                    chessBoard[blackRow, blackCol] = 'b';
                }
            }
        }

        public static bool IsIndexValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        public static char FindFinishLetter(int col) 
        {
            if (col == 0)
            {
                return 'a';
            }
            else if (col == 1)
            {
                return 'b';
            }
            else if (col == 2)
            {
                return 'c';
            }
            else if (col == 3)
            {
                return 'd';
            }
            else if (col == 4)
            {
                return 'e';
            }
            else if (col == 5)
            {
                return 'f';
            }
            else if (col == 6)
            {
                return 'g';
            }
            else if (col == 7)
            {
                return 'h';
            }

            return 'x';
        }

        public static char GiveWinNumber(int row)
        {
            if (row == 0)
            {
                return '8';
            }
            else if (row == 1)
            {
                return '7';
            }
            else if (row == 2)
            {
                return '6';
            }
            else if (row == 3)
            {
                return '5';
            }
            else if (row == 4)
            {
                return '4';
            }
            else if (row == 5)
            {
                return '3';
            }
            else if (row == 6)
            {
                return '2';
            }
            else if (row == 7)
            {
                return '1';
            }

            return 'x';
        }

        public static char GiveWinLetter(int col)
        {
            if (col == 0)
            {
                return 'a';
            }
            else if (col == 1)
            {
                return 'b';
            }
            else if (col == 2)
            {
                return 'c';
            }
            else if (col == 3)
            {
                return 'd';
            }
            else if (col == 4)
            {
                return 'e';
            }
            else if (col == 5)
            {
                return 'f';
            }
            else if (col == 6)
            {
                return 'g';
            }
            else if (col == 7)
            {
                return 'h';
            }

            return 'x';
        }
    }
}
