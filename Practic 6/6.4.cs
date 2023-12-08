using System;

class Program
{
    static char[,] board = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static char currentPlayer = 'X';

    static void Main()
    {
        do
        {
            Console.Clear();
            DrawBoard();

            int choice;
            bool validInput;

            do
            {
                Console.WriteLine($"Ходит игрок {currentPlayer}. Введите номер ячейки (1-9):");
                validInput = int.TryParse(Console.ReadLine(), out choice);

                if (!validInput || choice < 1 || choice > 9 || IsCellOccupied(choice))
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                    validInput = false;
                }

            } while (!validInput);

            UpdateBoard(choice);
        } while (!IsGameFinished());

        Console.Clear();
        DrawBoard();
        Console.WriteLine("Игра окончена!");

        if (IsWinner())
        {
            Console.WriteLine($"Игрок {currentPlayer} победил!");
        }
        else
        {
            Console.WriteLine("Ничья!");
        }
    }

    static void DrawBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{board[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static void UpdateBoard(int choice)
    {
        char symbol = (currentPlayer == 'X') ? 'X' : 'O';

        switch (choice)
        {
            case 1: board[0, 0] = symbol; break;
            case 2: board[0, 1] = symbol; break;
            case 3: board[0, 2] = symbol; break;
            case 4: board[1, 0] = symbol; break;
            case 5: board[1, 1] = symbol; break;
            case 6: board[1, 2] = symbol; break;
            case 7: board[2, 0] = symbol; break;
            case 8: board[2, 1] = symbol; break;
            case 9: board[2, 2] = symbol; break;
        }

        SwitchPlayer();
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    static bool IsCellOccupied(int choice)
    {
        switch (choice)
        {
            case 1: return board[0, 0] == 'X' || board[0, 0] == 'O';
            case 2: return board[0, 1] == 'X' || board[0, 1] == 'O';
            case 3: return board[0, 2] == 'X' || board[0, 2] == 'O';
            case 4: return board[1, 0] == 'X' || board[1, 0] == 'O';
            case 5: return board[1, 1] == 'X' || board[1, 1] == 'O';
            case 6: return board[1, 2] == 'X' || board[1, 2] == 'O';
            case 7: return board[2, 0] == 'X' || board[2, 0] == 'O';
            case 8: return board[2, 1] == 'X' || board[2, 1] == 'O';
            case 9: return board[2, 2] == 'X' || board[2, 2] == 'O';
            default: return true;
        }
    }

    static bool IsGameFinished()
    {
        return IsBoardFull() || IsWinner();
    }

    static bool IsBoardFull()
    {
        foreach (var cell in board)
        {
            if (cell != 'X' && cell != 'O')
            {
                return false;
            }
        }
        return true;
    }

    static bool IsWinner()
    {
        return CheckRows() || CheckColumns() || CheckDiagonals();
    }

    static bool CheckRows()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return true;
            }
        }
        return false;
    }

    static bool CheckColumns()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
            {
                return true;
            }
        }
        return false;
    }

    static bool CheckDiagonals()
    {
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return true;
        }

        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return true;
        }

        return false;
    }
}
