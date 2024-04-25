/*
A Two Sum problem involves finding the index of two numbers within an array int[] nums that add up to target K.
The solution involves using a Dictionary to store the <num, index> pair visited, and using target k - num[i]
and checking if the remaining pair exists in the dictionary.

For Three Sum

nums[i] + nums[j] + nums[k] = 0

0 - nums[i] = remainder = nums[j] + nums[k]

0 - nums[i] = Two Sum solution!!

Find first remainder.
Check if remainder exists in solved TwoSum dict.
If yes, add all three numbs to a solution list.
If no, subtract all numbs in dict from remainder and check if the result exists in dict.


For each num[i], we need to see if we can find a pair of num[j] and num[k] that add up to 0 - num[i].
In other words, k = 0 - num[i] = nums[j] + nums[k]



*/

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        var solutionList = new List<IList<int>>();
        //Console.WriteLine(string.Join(",", nums));

        // inputs with less than 3 numbers automatically fail.
        if (nums.Length < 3)
        {
            return solutionList;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            var target = 0 - nums[i];
            //Console.WriteLine($"0 - nums[{i}]({nums[i]}) = {target}. Is there a TwoSum solution for target={target} in the remaining array?");

            // Reminder: TwoSum Solution:
            // k = nums[j] + nums[k]
            // 0 - nums[i] = nums[j] + nums[k]
            var localTwoSum = new Dictionary<int, int>();

            for (int j = i+1; j < nums.Length; j++)
            {
                var localRemainder = target - nums[j];

                //Console.WriteLine($"{target} - nums[{j}]({nums[j]}) = {localRemainder}");

                if (localTwoSum.ContainsValue(localRemainder))
                {
                    //Console.WriteLine($"{localRemainder} IS in TwoSum. The 3Sum solution is {nums[i]}, {nums[j]},{localRemainder}");
                    // We've found a solution here.
                    // TODO: But check if we already have a permutation of this set in the solution
                    // if (solutionList.Contains(x => x.Contains()))

                    var set = new List<int>() { nums[i], nums[j], localRemainder };

                    var dupe = false;
                    foreach (var solution in solutionList)
                    {
                        if (solution.Intersect(set).Count() == 3)
                        {
                            dupe = true;
                        }
                    }

                    if (!dupe)
                    {
                        solutionList.Add(set);
                    }
                }
                else
                {
                    //Console.WriteLine($"{localRemainder} is not in TwoSum. Add [{j}, {nums[j]}]");
                    // Add the remainder for future reference
                    localTwoSum.Add(j, nums[j]);
                }
            }
        }

        return solutionList;
    }
}