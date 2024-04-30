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

Max = largest window + largest k replacements


*/

public class Solution {
    public int CharacterReplacement(string s, int k) {
        var left = 0;

        var max = 0;

        // Keeps track of the number of characters in the window.
        var map = new Dictionary<char, int>();

        for (int right = 0; right < s.Length; right++)
        {
            // Add the character to the map, and increment the count of an existing character.
            if (!map.ContainsKey(s[right]))
            {
                map[s[right]] = 0;
            }
            map[s[right]] += 1;

            // The largest window [right - left + 1] will contain up to max k replacements.
            // largest window = [most frequent characters + up to k replacements for least frequent characters]
            // We will want to replace the character that occurs the least, rather than the most frequent characters 
            // To find the least frequent character, we take window size - max frequency [map.Max(x => x.Value)].
            // Once the number of characters we need to replace equals or falls below k, we will then have a valid window once more.
            while (right - left + 1 - map.Max(x => x.Value) > k)
            {
                // We shift the left point to the right until the window is valid again.
                map[s[left]] -= 1;
                left += 1;
            }

            max = Math.Max(max, right - left + 1);
        }

        return max;
    }
}


/*
Bonus:
We don't need to actually decrement the count of the character in the map. we can maintain the largest maxf. Here's the reason:

// For a substring to be valid, we need window_length - maxf <= k.
// Here, maxf is the frequency of the most common character in the current window.
// The difference window_length - maxf tells us how many characters we'd need to change to make the whole window the same character.

// The biggest valid substring we can get is of size maxf + k.
// So, the larger maxf is, the better. If maxf doesn't change or goes down, our potential best answer doesn't change.
// We don't need to update maxf in this case.

// On the other hand, if maxf goes up, it means we've found a character in the current window that appears more often than in previous windows.
// This means we might be able to get a longer valid substring, so we update maxf.



*/