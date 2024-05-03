/*
Firstly, I think this problem can probably be better solved with a sliding window algorithm.
we keep the left pointer on the temp of the ith day, then shift the right pointer until we find a higher number.
Once found, we update the ith result with the length of the window.
After that, the left pointer increments, while the right pointer resets to the immediate right.

**** ACTUALLY SLIDING WINDOW IS NOT THE BEST SOLUTION ****
The sliding window solution breaks when presented with a bogus testcase of 100x99, followed by oneX100. Cheating!!

But given this is a stack problem, we should try with a stack.
Can we somehow keep asc/desc adjacent numbers in the stack?



*/

public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        if (temperatures.Length == 0 || temperatures.Length == 1)
        {
            return new int[1]{0};
        }

        var left = 0;
        var right = 1;

        while (left < temperatures.Length)
        {
            if (right >= temperatures.Length - 1)
            {
                // If the right pointer reaches the end, but we still can't find a warmer day,
                // then there is no warmer day in this array ahead of left.
                if (temperatures[left] >= temperatures[temperatures.Length - 1])
                {
                    temperatures[left] = 0;
                }
                else
                {
                    temperatures[left] = right - left;
                }

                // Onto the next day
                left++;
                right = left+1;
            }
            else if (temperatures[left] >= temperatures[right])
            {
                // If the left's temp is greater than or equal to right's temp,
                // we should keep looking for a warmer day.
                right++;
            }
            else
            {
                // We found a warmer day!
                temperatures[left] = right - left;

                // Onto the next day.
                left++;
                right = left+1;
            }
        }

        return temperatures;
    }
}