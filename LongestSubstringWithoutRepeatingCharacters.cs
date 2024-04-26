/*
Attempt 1

This first attempt succeeded, but is inefficient. It has a time complexity of O(n^2) because it uses a nested loop to check for repeating characters.
*/

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length == 0)
        {
            return 0;
        }
        else if (s.Length == 1)
        {
            return 1;
        }

        var max = 0;

        var arr = s.ToCharArray();

        HashSet<char> runningSubstring;

        for (int i = 0; i < arr.Length; i++)
        {
            // Reset the running substring set.
            runningSubstring = new HashSet<char>();

            var anchor = i;

            // With i as the start of a runningSubstring sequence,
            // we measure how long this sequence can run by incrementing an anchor to the substring.
            // This anchor continues incrementing until we find a repeating character,
            // or it runs to the end of the string.
            while (anchor < s.Length && !runningSubstring.Contains(arr[anchor]))
            {
                runningSubstring.Add(arr[anchor]);
                anchor += 1;
            }

            max = Math.Max(max, anchor - i);
        }

        return max;
    }
}


/*
This second attempt actually uses the sliding window technique.
It uses the fact that as we move the right pointer, we can check if the character is in the set.
If it is, we can move the left pointer of the window right until we no longer have a repeating character.

[abcabcbb]
[LR]        max=2

[abcabcbb]
[L-R]       max=3

[abcabcbb]          We move L once, and drop repeat character 'a'.
[>L-R]      max=3

[abcabcbb]          We move L once, and drop repeat character 'b'.
[ >L-R]     max=3

[abcabcbb]          We move L once, and drop repeat character 'c'.
[  >L-R]    max=3

[abcabcbb]          We move L to the right twice, until we drop repeat character 'b'
[   >>LR]   max=3

[abcabcbb]          We move L all the way right, in order to drop repeat character 'b'
[       R]   max=3

Loop ends here because right pointer is at the end of the string.
*/

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var max = 0;
        var left = 0;
        var right = 0;

        var set = new HashSet<char>();

        while (right < s.Length)
        {
            if (set.Contains(s[right]))
            {
                set.Remove(s[left]);
                left += 1;
            }
            else
            {
                set.Add(s[right]);
                right += 1;
            }

            max = Math.Max(max, right - left);
        }

        return max;
    }
}