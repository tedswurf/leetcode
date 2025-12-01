class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        l, r, longest, positionOfLastZero = 0, 0, 0, 0

        deleted = False

        while r < len(nums):
            if nums[r] == 0:
                if not deleted:
                    deleted = True
                    positionOfLastZero = r
                else:
                    l = positionOfLastZero + 1
                    positionOfLastZero = r

            tempLongest = r - l + 1

            if deleted:
                tempLongest -= 1

            longest = max(longest, tempLongest)
            #print(f"l[{l:<2}]={nums[l]:<2}   r[{r:<2}]={nums[r]:<2}  deleted={deleted}  positionOfLastZero={positionOfLastZero} longest={longest}")
            r += 1

        if not deleted:
            longest -= 1

        return longest