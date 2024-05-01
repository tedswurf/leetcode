/*
We can use a fixed window in this problem. We know this because the constraint requires s1 to be a contiguous substring of s2.
In other words, if s1 is length 2, then the substring in s2 must also be length 2.

For the easier solution, we can sort the s1, and then additionally sort the window in s2. If the two sorted arrays are equal, then we have a permutation.
This is O(nlogn) time complexity, but it is a valid solution.

For something that should be fast, but mroe complex, we need to build a frequency map for s1, and also for characters for a given window in s2.
We know that the characters in the window can be a permutation of s1 if the frequency map of characters in s2 matches.
Matching the two frequency maps takes O(1) time, because we are only comparing 26 characters.

We can keep shifting the window to the right, and updating the frequency map of the window.

*/

public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length)
        {
            return false;
        }

        var s1Map = new Dictionary<char, int>();
        var windowMap = new Dictionary<char, int>();

        for (int i = 0; i < s1.Length; i++)
        {
            if (!s1Map.ContainsKey(s1[i]))
            {
                s1Map.Add(s1[i], 0);
            }

            s1Map[s1[i]] += 1;
        }

        var left = 0;
        var right = s1.Length - 1;

        for (int i = 0; i < s1.Length; i++)
        {
            if (!windowMap.ContainsKey(s2[i]))
            {
                windowMap.Add(s2[i], 0);
            }

            windowMap[s2[i]] += 1;
        }

        //Console.WriteLine($"s1Map: [{string.Join(',', s1Map.Select(x => $"{x.Key}:{x.Value}"))}]");

        var first = true;

        while (right < s2.Length)
        {
            if (!first)
            {
                if (!windowMap.ContainsKey(s2[right]))
                {
                    windowMap.Add(s2[right], 0);
                }

                windowMap[s2[right]] += 1;

                windowMap[s2[left-1]] -= 1;
            }

            //Console.WriteLine($"{string.Join(',', s2.Skip(left).Take(right-left+1))}  windowMap: [{string.Join(',', windowMap.Select(x => $"{x.Key}:{x.Value}"))}]");

            if (FreqMapsMatch(s1Map, windowMap))
            {
                return true;
            }

            left += 1;
            right += 1;
            first = false;
        }

        return false;
    }

    private bool FreqMapsMatch(Dictionary<char, int> map1, Dictionary<char, int> map2)
    {
        var match = true;

        foreach (var item1 in map1)
        {
            match &= map2.ContainsKey(item1.Key) && map2[item1.Key] == item1.Value;
        }

        return match;
    }
}


/*
There is a more optimal solution to this problem.

Instead of keeping two frequency maps for s1 and window, we can add another variable "match".
It is an <int> that contains a value 0 to 26 representing the number of matches between the two maps.

When we continue to maintain this map, we will increment "match" if the window introduces a character that matches in s1,
or if the window moves out and removes a character that didn't match in s1.

In addition, decrement "match" if the window introduces character not in s1, or if the window moves out and removes a character that matched in s1. 

If match ever hits 26, we know that at some point, the window map matched the s1 map
*/