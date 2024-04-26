/*
Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49

Originally, you would think that given index i and j, that if height[i] > height[j], then you would never want height[j].
This is actually not the case. Consider this array:

[1,8,1,1]

Even though height[1] > height[0], the correct answer here involves height[0] and height[2].

Using two pointer where left = 0 and right = height.Length-1, we can arrive at a solution.
However, it cannot be as simple as incrementing pointers based on the height of the current pointer.

One assertion I can make is that we know that the area is limited by the smallest height.
we can move the left wall inward until we find a taller wall. We can do the same for the right wall,
moving it inward until we find a taller wall.
*/

public class Solution {
    public int MaxArea(int[] height) {


        var maxVolume = 0;

        var left = 0;
        var right = height.Length - 1;

        while (left < right)
        {
            var leftHeight = height[left];
            var rightHeight = height[right];

            // The volume is bound by the lowest wall.
            var lowerWall = Math.Min(leftHeight, rightHeight); 
            var volume = lowerWall * (right - left);

            maxVolume = Math.Max(volume, maxVolume);

            if (leftHeight > rightHeight)
            {
                // If the right wall is the shorter wall, keep pushing it left
                // until we find a taller wall. Ones to the left with the same or shorter height
                // will never be a part of the answer.
                right -= 1;
                
                while (height[right] <= rightHeight && left < right)
                {
                    right -= 1;
                }
            }
            else
            {
                // If the left wall is the shorter wall, keep pushing it right
                // until we find a taller wall. Ones to the right with the same or shorter height
                // will never be a part of the answer.
                left += 1;

                while (height[left] <= leftHeight && left < right)
                {
                    left += 1;
                }
            }
        }

        return maxVolume;
    }
}