class Solution:
    def reverseWords(self, s: str) -> str:
        # Reversal can be arranged via a stack
        # Push each word into the stack, then pop them out LIFO
        # Need to parse string into individual words (split?). Otherwise, build string until whitespace or end of line.

        length = len(s)

        words = s.split()
        stack = []

        for word in words:
            stack.append(word)

        reversed = []

        while len(stack) > 0:
            reversed.append(stack.pop())

        return  ' '.join(reversed)

