class Solution:
    def findMaxAverage(self, nums: List[int], k: int) -> float:
        maxSum = -10^4
        sum, l = 0, 0

        for i in range(k):
            sum += nums[i]
            maxSum = sum


        #print(f"l={l} r={l+k-1} maxAverage={maxAverage}")
        
        l += 1

        while (l + k - 1) < len(nums):
            sum = sum - nums[l-1] + nums[l+k-1]

            if sum > maxSum:
                maxSum = sum

            print(f"l={l} r={l+k-1} maxSum={maxSum}")

            l += 1

        return maxSum/k