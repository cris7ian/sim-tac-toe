public class TicTacToe
{
    private char[,] board;

    public TicTacToe()
    {
        board = new char[3, 3];
        InitializeBoard();
    }

    // Initialize the board with empty spaces
    private void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    // Make a move on the board
    public bool SetPosition(int row, int col, char currentPlayer)
    {
        if (row < 0 || row > 2 || col < 0 || col > 2)
        {
            return false; // Invalid move
        }

        board[row, col] = currentPlayer;
        return true;
    }

    // Check if there is a winner
    public bool CheckWin(char currentPlayer)
    {
        // Check rows, columns, and diagonals
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                return true;
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                return true;
        }

        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
            return true;

        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
            return true;

        return false;
    }

    public char Winner()
    {
        if (CheckWin('x'))
        {
            return 'x';
        }
        else if (CheckWin('o'))
        {
            return 'o';
        }
        else
        {
            return '-';
        }
    }

    // Check if the board is full (a draw)
    public bool IsDraw()
    {
        foreach (char spot in board)
        {
            if (spot == ' ')
                return false;
        }
        return true;
    }

    // Optional: Display the board (for debugging or logging purposes)
    public void DebugBoard()
    {
        string boardString = "";
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                boardString += board[i, j];
                if (j < 2) boardString += "|";
            }
            boardString += "\n";
            if (i < 2) boardString += "-----\n";
        }
        UnityEngine.Debug.Log(boardString);
    }
}