public class Solution {
    public bool IsValidSudoku(char[][] board) {
        if (!AreRowsValid(board))
        {
            return false;
        }

        if (!AreColumnsValid(board))
        {
            return false;
        }

        if (!AreGridsValid(board))
        {
            return false;
        }

        return true;
    }


    private bool AreRowsValid(char[][] board)
    {
        for (int i = 0; i < board.Length; i++) // i is row index
        {
            var set = new HashSet<char>();

            for (int j = 0; j < board[i].Length; j++) // j is column index
            {
                var cell = board[i][j];
                // Console.WriteLine($"Cell: [row:{i} x column:{j}] = {board[i][j]}");

                // Skip over blank cells.
                if (cell == '.')
                {
                    continue;
                }

                // If the set has already seen this value, the board fails.
                if (set.Contains(cell))
                {
                    return false;
                }
                else
                {
                    set.Add(cell);
                }
            }
        }

        return true;
    }


    private bool AreColumnsValid(char[][] board)
    {
        for (int j = 0; j < board.Length; j++) // j is row index
        {
            var set = new HashSet<char>();

            for (int i = 0; i < board[j].Length; i++) // i is column index
            {
                var cell = board[i][j];
                //Console.WriteLine($"Cell: [row:{j} x column:{i}] = {board[i][j]}");

                // Skip over blank cells.
                if (cell == '.')
                {
                    continue;
                }

                // If the set has already seen this value, the board fails.
                if (set.Contains(cell))
                {
                    return false;
                }
                else
                {
                    set.Add(cell);
                }
            }
        }

        return true;
    }


    private bool AreGridsValid(char[][] board)
    {
        if (!IsGridValid(board, 0, 0)) { return false; };
        if (!IsGridValid(board, 3, 0)) { return false; };
        if (!IsGridValid(board, 6, 0)) { return false; };

        if (!IsGridValid(board, 0, 3)) { return false; };
        if (!IsGridValid(board, 3, 3)) { return false; };
        if (!IsGridValid(board, 6, 3)) { return false; };

        if (!IsGridValid(board, 0, 6)) { return false; };
        if (!IsGridValid(board, 3, 6)) { return false; };
        if (!IsGridValid(board, 6, 6)) { return false; };

        return true;
    }


    private bool IsGridValid(char[][] board, int startCellRow, int startCellColumn)
    {
        var set = new HashSet<char>();
        for (int i = startCellRow; i < startCellRow + 3; i++)
        {
            for (int j = startCellColumn; j < startCellColumn + 3; j++)
            {
                var cell = board[i][j];
                //Console.WriteLine($"Cell: [row:{i} x column:{j}] = {board[i][j]}");

                // Skip over blank cells.
                if (cell == '.')
                {
                    continue;
                }

                // If the set has already seen this value, the board fails.
                if (set.Contains(cell))
                {
                    return false;
                }
                else
                {
                    set.Add(cell);
                }
            }
        }

        //Console.WriteLine($"Set Analyzed: {string.Join(",", set)}");

        return true;
    }
}