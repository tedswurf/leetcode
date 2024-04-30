/*
This question probably contains LongestSubstringWithoutRepeatingCharacters strategy, in part or in whole.
In other words, we want to use a sliding window to capture the "longest substring" which in this case is the longest repeating character replacement.
(As a reminder, in LongestSubstringWithoutRepeatingCharacters, we used a sliding window to capture the "longest substring" without repeating characters.)

The second layer to this problem involves the necessity of performing k replacements. How do we know which characters to replace that leaves
the longest substring? In fact, there could be multiple solutions involving the longest substring with different characters replaced.

Let's begin with this stipulation. Given an array of characters, any valid substring here must contain the same character in the front as in the back.
[AAABBA]
[ASRDTA]
In this example, we know for a fact that the longest substring will Start and End with A

This means that, given enough replacements k, we can ignore any characters in between the front and back.
Furthermore, we can assume that the longest substring will be any number of characters that already repeat + k potential replacements.

Once we reach a point where we cannot replace any more characters, if the following character is not the same (or we reach the end),
we check Max(current, max). Following this, given that we know that starting at the same character again to the right will not produce a longer longer substring,
we move the left pointer right until we reach a different character, or the end.

*/

public class Solution {
    public int CharacterReplacement(string s, int k) {
        var left = 0;

        var max = 0;

        var map = new Dictionary<char, int>();

        for (int right = 0; right < s.Length; right++)
        {
            if (!map.ContainsKey(s[right]))
            {
                map[s[right]] = 0;
            }
            map[s[right]] += 1;

            while (right - left + 1 - map.Max(x => x.Value) > k)
            {
                map[s[left]] -= 1;
                left += 1;
            }

            max = Math.Max(max, right - left + 1);
        }

        return max;
    }
}