/*
We can solve this problem using quicksort. However, that would be time complexity O(n log n).
The number of times the array is rotated n is hidden from us, yet it sounds crucial to the solution. How so?

The only way to write an algorithm that run in O(log n) time is to binary search, meaning that
we must throw away half the options at each decision.

If we pick any random num at nums[i], we know that:
1. If the number is the largest, the numbers to the left and right are all smaller. The number to the
    immediate right will be the smallest.
2. If the number is the smallest, the numbers to the left and right are all bigger.
3. For any other number in between, the numbers to the immediate left are smaller,
    while the numbers to the immediate right are bigger.

How do we choose a number to start?
1. By position: Selecting the middle number, then try determining if it falls in any of the three above.
In all likelihood, the number falls under context 3. We may need to try looking in both halves regardless
(even if all numbers to the left are smaller, the smallest may be in the right side.)

[6,7,8,9,10,11,-4,-3,-2,-1,0,1,2,3,4,5] nums[7] = -3

nums[0]=6, nums[6]=-4 -> Smallest number found here (-4).
nums[8]=-2, nums[15]=5

[6,7,8,9,10,11,-4] nums[3] = 9

nums[0]=6, nums[2]=8
nums[4]=10, nums[5]=-4 -> Smallest number found here (-4).

[10,11,-4] nums[1] = 11

nums[0]=10
nums[2]=-4 => the answer is here

*/

public class Solution {
    public int FindMin(int[] nums) {
        var left = 0;
        var right = nums.Length - 1;

        Console.WriteLine($"{string.Join(",",nums)}");

        while (left <= right)
        {
            var pivot = (right + left)/2;

            var left1Pos = left;
            var left2Pos = ((pivot-1)<left) ? left : pivot-1;
            var right1Pos = ((pivot+1)>right) ? right : pivot+1;
            var right2Pos = right;

            Console.WriteLine($"Positn [{left} {left2Pos}] {pivot} [{right1Pos} {right2Pos}]");

            var left1 = nums[left1Pos];
            var left2 = nums[left2Pos];
            var right1 = nums[right1Pos];
            var right2 = nums[right2Pos];

            Console.WriteLine($"Values [{left1} {left2}] {nums[pivot]} [{right1} {right2}]");

            if (nums[pivot] < left2 && nums[pivot] < right1)
            {
                //Console.WriteLine($"Case 3");
                return nums[pivot];
            }
            else if (left2 < nums[pivot] && right1 < nums[pivot])
            {
                //Console.WriteLine($"Case 4");
                return nums[right1Pos];
            }

            var leftSmallest = Math.Min(left1, left2) < Math.Min(right1, right2);

            if (Math.Min(left1, left2) < Math.Min(right1, right2))
            {
                //Console.WriteLine($"Case 1");
                // The smaller number should be in the left subarray.
                right = left2Pos;
            }
            else if (Math.Min(left1, left2) > Math.Min(right1, right2))
            {
                //Console.WriteLine($"Case 2");
                // The smaller number should be in the right subarray.
                left = right1Pos;
            }
            else
            {
                //Console.WriteLine($"Case 5");
                return nums[pivot];
            }
        }

        return 0;
    }
}