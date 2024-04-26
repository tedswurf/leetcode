/*
A Two Sum problem involves finding the index of two numbers within an array int[] nums that add up to target K.
The solution involves using a Dictionary to store the <num, index> pair visited, and using target k - num[i]
and checking if the remaining pair exists in the dictionary.

nums[i] + nums[j] + nums[k] = 0

We can reduce this down to a Two Sum problem by fixing the leftmost number

a + nums[j] + nums[k] = 0

If we then sort the array, we can use a two-pointer approach to find the remaining two numbers.

a + nums[left] + nums[right] = 0

Note that we do not want to produce the same solution multiple times.
We can avoid that by noting that if the left neighbor of a is the same, we can skip a.
*/
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var solutionList = new List<IList<int>>();

        Array.Sort(nums);

        // inputs with less than 3 numbers automatically fail.
        if (nums.Length < 3)
        {
            return solutionList;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            // We should skip if the left neighbor is the same.
            if (i > 0 && nums[i] == nums[i-1])
            {
                continue;
            }
            
            // if value of i is greater than 0, by nature of the sort array, every subsequent value
            // will product a sum greater than 0. We can end here. 
            if (nums[i] > 0)
            {
                continue;
            }

            // two-pointer on a sorted array to find remainder.
            var left = i+1;
            var right = nums.Length-1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];

                if (sum > 0)
                {
                    right-=1;
                }
                else if (sum < 0)
                {
                    left+=1;
                }
                else
                {
                    solutionList.Add(new List<int> { nums[i], nums[left], nums[right]});
                    
                    left += 1;

                    // We can simply keep incrementing left pointer if we see the repeat start-of-sequence
                    // in its left neightbor.
                    while (left < nums.Length - 1 && nums[left] == nums[left-1])
                    {
                        left += 1;
                    }
                }
            }
        }

        return solutionList;
    }
}