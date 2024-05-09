/*
We can perform binary search first to determine which rows we are going to work with, then perform binary search on that row.

To do part 2, we can see if the number is greater or less than the last number of the middle row.
If the target is greater, then we will look in the upper half of the matrix, if available.
If the target is smaller, then we will look in the lower half of the matrix.

If we find the target row, we can then perform a binary search on that row to find the target.
*/
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if (matrix.Length == 0 || matrix[0].Length == 0)
        {
            return false;
        }

        if (matrix.Length == 1 && matrix[0].Length == 1)
        {
            return matrix[0][0] == target;
        }

        var maxCol = matrix[0].Length - 1;
        var topRow = matrix.Length - 1;
        var botRow = 0;

        // First, use binary search on the rows to deduce the exact row we can work with.
        var targetRow = 0;

        while (botRow <= topRow)
        {
            var row = (botRow + topRow)/2;

            if (matrix[row][0] > target)
            {
                // If the target less than the first element in the row, we search in a smaller row.
                topRow -= 1;
            }
            else if (matrix[row][maxCol] < target)
            {
                // If the target greater than the last element in the row, we search in a larger row.
                botRow += 1;
            }
            else
            {
                // Otherwise, the target is in the row.
                targetRow = row;
                break;
            }
        }

        // Binary search throw all values in the target row.
        return BinarySearch(matrix[targetRow], 0, maxCol, target);
    }


    private bool BinarySearch(int[] arr, int l, int r, int target)
    {
        if (l > r)
        {
            return false;
        }

        var pivot = (l + r)/2;

        if (arr[pivot] > target)
        {
            // Look lower
            return BinarySearch(arr, l, pivot - 1, target);
        }
        else if (arr[pivot] < target)
        {
            // Look higher
            return BinarySearch(arr, pivot + 1, r, target);
        }
        else
        {
            return true;
        }
    }
}