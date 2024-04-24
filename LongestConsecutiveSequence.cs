/*
This solution involves a few concepts:

1. Converting the array into a hashset allows us to identify the existence of a number in O(1) time. It also removes duplicates
2. Each item in a hashset could potentially be the start of its own subsequence. We can identify this by checking if the item-1 exists in the hashset.
3. If the item is the start of a subsequence, we can then check for consecutive suffixes by incrementing the item by 1 until we find a number that 
    doesn't exist in the hashset.
4. We can then compare the length of the current sequence with the incumbent sequence to determine the longest sequence.

This is all O(n) time complexity because, although we go over the dataset at least once, the subsequent checks are O(1) time complexity.
*/



public class Solution {
    public int LongestConsecutive(int[] nums) {
        var longestSeq = 0;

        var workingSet = new HashSet<int>();

        // Convert array to hashset. Note that we can't use ToHashSet conversion because the dataset has duplicates.
        for (int i = 0; i < nums.Length; i++)
        {
            var number = nums[i];

            if (workingSet.Contains(nums[i]))
            {
                continue;
            }
            
            workingSet.Add(number);
        }

        foreach (var item in workingSet)
        {
            if (workingSet.Contains(item-1))
            {
                continue;
            }

            // The item is the start of its subsequence. Search for consecutive suffixes
            var consecutive = 1;
            while (true)
            {
                var next = item + consecutive;
                if (workingSet.Contains(next))
                {
                    consecutive += 1;
                }
                else
                {
                    break;
                }
            }

            // Take the longer of the current sequence, or the incumbent sequence.
            longestSeq = consecutive > longestSeq ? consecutive : longestSeq;
        }

        return longestSeq;
    }
}