class Solution:
    def maxVowels(self, s: str, k: int) -> int:
        if len(s) < k:
            return 0

        vowels = ['a','e','i','o','u']

        chars = list(s)

        l, r, longest, window = 0, 0, 0, 0

        while r < len(s):
            l = r - k + 1
            if chars[r] in vowels:
                window += 1
                if window > longest and window <= k:
                    longest = window
                
                #print(f"arrving char {chars[r]} is a vowel. longest is {longest}")

            if l >= 0 and chars[l] in vowels:
                window -= 1
                #print(f"leaving char {chars[l]} is not a vowel. longest is {longest}")

            r += 1


        return longest