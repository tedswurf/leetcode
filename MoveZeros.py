class Solution:
    def moveZeroes(self, nums: List[int]) -> None:
        """
        Do not return anything, modify nums in-place instead.
        """
        length = len(nums)

        if (length == 0 or length == 1):
            return

        temp = []
        numzeros = 0

        for element in nums:
            if (element == 0):
                numzeros += 1
            else:
                temp.append(element)

        for i in range(numzeros):
            temp.append(0)

        nums[:] = temp
