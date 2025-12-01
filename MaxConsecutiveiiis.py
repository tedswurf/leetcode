class Solution:
    def longestOnes(self, nums: List[int], k: int) -> int:
        l, r, longest, tempLongest = 0, 0, 0, 0

        # available bits to flip
        flips = 0

        while r < len(nums):
            #print(f"l[{l:<2}]={nums[l]:<2}   r[{r:<2}]={nums[r]:<2}  flips={flips}")
            if nums[r] == 1:
                tempLongest += 1
            else:
                tempLongest += 1
                flips += 1

            while flips > k:
                #print(f"shifting l")
                if nums[l] == 0:
                    l += 1
                    flips -= 1
                else:
                    l += 1
                tempLongest -= 1

            if tempLongest > longest:
                longest = tempLongest
            #print(f"---------------------- tempLongest={tempLongest:<2}   longest={longest}")

            r += 1

        return longest           
