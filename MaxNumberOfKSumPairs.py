class Solution:
    def maxOperations(self, nums: List[int], k: int) -> int:
        if len(nums) == 1:
            return 0

        l = 0
        r = len(nums) - 1
        counts = 0

        # sort the numbers in ascending order
        nums.sort()
        print(nums)

        while l < r:
            total = nums[l] + nums[r]
            #print(f"l[{l}]={nums[l]}  r[{r}]={nums[r]}  total:{total:<4}counts:{counts:<3}")

            if total == k:
                counts += 1
                l += 1
                r -= 1

            elif total < k:
                l += 1

            else:
                r -= 1
                


        return counts