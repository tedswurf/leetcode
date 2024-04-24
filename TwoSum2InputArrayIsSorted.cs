/*
This problem has a unique constraint - The solution must use only constant extra space.
This means, a dataset of 100000 must require the same space as a dataset of 2.
This means we cannot use the traditional Two Sum solution of using a Dictionary to store the <num, index> pair,
given that this solution would have space complexity O(n).


We must consider the fact that the array is sorted such that numbers[i+1] >= numbers[i]. Hence, non-decreasing.

Given the solution contains two numbers, we can use two pointers to traverse the array from the start and end, going inwards.

Note that the answer involves adding 1 to the indices because the problem is 1-indexed, meaning they start at 1, not 0.
*/


public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var left = 0;
        var right = numbers.Length - 1;

        while (true)
        {
            var sum = numbers[left] + numbers[right];

            if (sum == target)
            {
                break;
            }

            if (sum > target)
            {
                right -= 1;
            }

            if (sum < target)
            {
                left += 1;
            }
        }

        return new int[2] { left+=1, right+=1 };
    }
}