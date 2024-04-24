public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // We need to know
        // 1. How many of each int are in nums?
        // 2. Ordinally, How would we find the top k ints by frequency?

        // We could use a Dictionary<int, int> to track the <num, frequencyOfNum>
        // But then we need to order it (priority queue? top-heap?)
        // Use Linq and perform Dictionary.OrderByDescending();

        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(nums[i]))
            {
                map[nums[i]]+=1;
            }
            else
            {
                map.Add(nums[i], 1);
            }
        }

        var output = map.OrderByDescending(x => x.Value).Take(k);

        return output.Select(x => x.Key).ToArray();
    }
}