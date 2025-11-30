class Solution:
    def increasingTriplet(self, nums: List[int]) -> bool:
        if len(nums) < 3:
            return False

        low, mid = nums[0], nums[0]
        midIndex = 0

        for i in range(len(nums)):
            curr = nums[i]
            if curr > mid and i > 1 and midIndex > 0:
                return True
            elif curr > low:
                mid = curr
                midIndex = i
            elif curr < low:
                low = curr
            #print(f"i:{i:<5}curr:{nums[i]:<5}[{low:<3},{mid:<3},{high}]   lowIndex:{lowIndex:<5}midIndex:{midIndex}")

        return False
                