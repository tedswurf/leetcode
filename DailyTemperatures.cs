/*
Firstly, I think this problem can probably be better solved with a sliding window algorithm.
we keep the left pointer on the temp of the ith day, then shift the right pointer until we find a higher number.
Once found, we update the ith result with the length of the window.
After that, the left pointer increments, while the right pointer resets to the immediate right.

**** ACTUALLY SLIDING WINDOW IS NOT THE BEST SOLUTION ****
The sliding window solution breaks when presented with a bogus testcase of 100x99, followed by oneX100.

So the Sliding Window solution passes 47/48 test cases, with the last one failing!!


Find the Stack Solution below this Sliding Window one.
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



/*
This is a type of stack problem called "Monotonic Decreasing Stack".

A monotonic decreasing problem refers to a problem where a certain property or value decreases monotonically
(i.e., it either remains constant or decreases) as you progress through the problem.

In the context of the stack problem mentioned in the code, a "Monotonic Decreasing Stack" is a stack that maintains
its elements in a monotonically decreasing order. This means that each element pushed onto the stack is less than or equal to the element below it.

This type of stack is useful in problems where you need to find the next greater or smaller element in an array,
such as in the "Daily Temperatures" problem. Here, you're using the stack to keep track of indices of the temperatures,
and while iterating through the temperature array, you check if the temperature of the current day is greater than the
temperature of the day at the top of the stack. If it is, you pop the stack and update the result.
This way, the stack always maintains a decreasing order of temperatures.
*/

public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var result = new int[temperatures.Length];

        var stack = new Stack<int>();

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                result[stack.Peek()] = i - stack.Peek();
                stack?.Pop();
            }

            stack.Push(i);
        }

        return result;
    }
}