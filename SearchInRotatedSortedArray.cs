/*
I think this problem may be entirely similar to FindMinimumInRotatedSortedArray.
In that problem, we found a pivot in the middle of an array. We then compare nums[left] against nums[pivot].
If nums[left] <= nums[pivot], the array to the left is sorted, and the smaller number may be to the right.
If nums[left] > nums[pivot], the array to the right contain all larger numbers. The smaller number is to the left.

The difference here is that instead of just comparing value at pivot, we also compare to the target. First we need to use binary search to find a sorted side. This is the dependable, predictable side.
If nums[pivot] == target, return pivot.
if nums[left] <= nums[pivot], the left subarray is sorted. If target is in this subarray, search left, else search right
else (if nums[left] > nums[pivot]), the right subarray is sorted. If target is in this subarray, search right, else go left

*/

public class Solution {
    public int Search(int[] nums, int target) {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var pivot = (left + right)/2;

            //Console.WriteLine($"nums[{left}]={nums[left]} nums[{pivot}]={nums[pivot]} nums[{right}]={nums[right]}");

            if (nums[pivot] == target)
            {
                return pivot;
            }
            else if (nums[left] <= nums[pivot])
            {
                // Left subarray is sorted.
                if (target < nums[pivot] && target >= nums[left])
                {
                    // Target is in the left subarray
                    //Console.WriteLine($"1. Go left");
                    right = pivot - 1;
                }
                else
                {
                    // Target is in right subarray
                    //Console.WriteLine($"1. Go right");
                    left = pivot + 1;
                }
            }
            else
            {
                // Right subarray is sorted.
                if (target > nums[pivot] && target <= nums[right])
                {
                    // Target is in right subarray
                    //Console.WriteLine($"2. Go right");
                    left = pivot + 1;
                }
                else
                {
                    // Target is in left subarray
                    //Console.WriteLine($"2. Go left");
                    right = pivot - 1;
                }
            }
        }

        return -1;
    }
}