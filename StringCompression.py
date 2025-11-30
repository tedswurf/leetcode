class Solution:
    def flush(self, charCounter, last, newchars: List[str]):
        newchars.append(str(last))
        # If the last character count is greater than 1, we have to append the count.
        if charCounter > 1:
            # If the counter is two or more digits, we split the number into individual digits (convert to string, then iterate)
            if charCounter > 9:
                digits = [digit for digit in str(charCounter)]
                for digit in digits:
                    newchars.append(str(digit))
            # Otherwise simply append the single counter digit.
            else:
                newchars.append(str(charCounter))



    def compress(self, chars: List[str]) -> int:
        newchars = []

        if len(chars) == 0:
            return 0
        print(f"{0} [{newchars}]")

        if len(chars) == 1:
            newchars.append(chars[0])
            return 1

        last = chars[0]
        charCounter = 1

        for i in range(1, len(chars)):
            if chars[i] == last:
                charCounter += 1

            if chars[i] != last:
                # If this character is different than the last, then we flush the stats of the last character to the newchars array
                # A character count of 1 is simply the character itself
                self.flush(charCounter, last, newchars)

                # Set the new incumbent going forward
                last = chars[i]
                # reset counter since it is a new letter
                charCounter = 1

            # If this is the last character, we will not have another loop, so run the loop one more time and flush
            if i == len(chars) - 1:
                self.flush(charCounter, last, newchars)

            print(f"{i} [{newchars}]")

        chars[:] = newchars

        return len(chars)
