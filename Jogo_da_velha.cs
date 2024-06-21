using System;

namespace JogoDaVelha
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char player = 'X';

        static void Main(string[] args)
        {
            int turn = 1;
            bool isWin = false;

            while (turn <= 9 && !isWin)
            {
                Console.Clear();
                DisplayBoard();
                PlayerMove();
                isWin = CheckWin();

                if (!isWin)
                {
                    player = player == 'X' ? 'O' : 'X';
                }
                turn++;
            }

            Console.Clear();
            DisplayBoard();

            if (isWin)
            {
                Console.WriteLine($"Parabéns! O jogador {player} venceu!");
            }
            else
            {
                Console.WriteLine("O jogo terminou em empate!");
            }
        }

        static void DisplayBoard()
        {
            Console.WriteLine("Jogo da Velha");
            Console.WriteLine();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            Console.WriteLine();
        }

        static void PlayerMove()
        {
            int choice;
            bool isValidMove = false;

            while (!isValidMove)
            {
                Console.WriteLine($"Jogador {player}, escolha um número: ");
                choice = int.Parse(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < 9 && board[choice] != 'X' && board[choice] != 'O')
                {
                    board[choice] = player;
                    isValidMove = true;
                }
                else
                {
                    Console.WriteLine("Movimento inválido! Tente novamente.");
                }
            }
        }

        static bool CheckWin()
        {
            // Linhas
            if ((board[0] == player && board[1] == player && board[2] == player) ||
                (board[3] == player && board[4] == player && board[5] == player) ||
                (board[6] == player && board[7] == player && board[8] == player))
            {
                return true;
            }

            // Colunas
            if ((board[0] == player && board[3] == player && board[6] == player) ||
                (board[1] == player && board[4] == player && board[7] == player) ||
                (board[2] == player && board[5] == player && board[8] == player))
            {
                return true;
            }

            // Diagonais
            if ((board[0] == player && board[4] == player && board[8] == player) ||
                (board[2] == player && board[4] == player && board[6] == player))
            {
                return true;
            }

            return false;
        }
    }
}
