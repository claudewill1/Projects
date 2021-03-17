using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    class TicTacToe
    {
		private char[][] board =
		{
			new char[3],
			new char[3],
			new char[3]
		};
		private char winner;
		public TicTacToe()
        {
			ResetBoard();
        }

		public void CreateBoard()
		{
			for (int i = 0; i < 3; ++i)
			{
				for (int j = 0; j < 3; ++j)
				{
					Console.Write(board[i][j]);
					if (j < 2)
					{
						Console.Write("|");
					}
				}
				Console.Write("\n");
			}
			Console.Write("\n");
		}
		public bool AddToken(char t, uint x, uint y)
        {
			bool ok = false;
			if(x < 3 && y < 3 && board[x][y] == '-')
            {
				board[x][y] = t;
				ok = true;
            }
			return ok;
        }

		public bool MakeMyMove()
        {
			unsafe
			{
				fixed (char* p = board[0])
				{
					for (int i = 0; i < 9; i++)
					{
						if (*p == '-')
						{
							*p = 'O';
							return true;
						}

                        
					}

					return false;
				}
			}
			
			
		}
		public bool Play()
        {
			bool quit = false;
			ResetBoard();
			CreateBoard();

            while (true)
            {
                if (!MakeYourMove())
                {
					quit = true;
					break;
                }

				if(CheckForWinner('X') || IsFull())
                {
					CreateBoard();
					break;
                }
				MakeMyMove();
				CreateBoard();
				if(CheckForWinner('O') || IsFull())
                {
					break;
                }
            }
			return quit;
        }
		public bool Winner(ref char c)
        {
            if (!IsFull())
            {
				if(winner != 'N')
                {
					c = winner;
					return true;
                }
            }
			return false;
        }

		public void ResetBoard()
        {
			winner = 'N';
            unsafe
            {
				fixed (char* p = board[0])
                {
					for (int i = 0; i < 9; i++)
					{
						*p = '-';

					}
				}
            }
			
        }
		public bool IsFull()
        {
            unsafe
            {
				fixed (char* p = board[0])
                {
					for (int i = 0; i < 9; ++i)
					{
						if (*p == '-')
						{
							return false;
						}
					}
					return true;
				}
            }
        }
	}
}
