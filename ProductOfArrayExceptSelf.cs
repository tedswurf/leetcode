public class Solution {

    // <index, productOfNumbersLeftOfIndex>
    private Dictionary<int, int> leftProductMap = new Dictionary<int, int>();
    // <index, productOfNumbersRightOfIndex>
    private Dictionary<int, int> rightProductMap = new Dictionary<int, int>();

    public int[] ProductExceptSelf(int[] nums) {
        // Product of array except self can be split into
        // product of left array x product of right array.

        var output = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            //Console.WriteLine($"index: {i}");
            var product = FindLeftProduct(nums, i) * FindRightProduct(nums, i);

            output[i] = product;
        }

        return output;
    }


    private int FindLeftProduct(int[] nums, int i)
    {
        //Console.WriteLine($"FindLeftProduct of {i}");
        // base case: if the index goes too far left, return product 1;
        if (i < 0)
        {
            return 1;
        }

        if (leftProductMap.ContainsKey(i))
        {
            return leftProductMap[i];
        }
        else
        {
            var leftOfi = i-1;
            //Console.WriteLine($"leftOfi {leftOfi}");

            if (leftOfi < 0)
            {
                return 1;
            }

            var productToLeftOfi = nums[leftOfi] * FindLeftProduct(nums, leftOfi);

            leftProductMap.Add(i, productToLeftOfi);

            return productToLeftOfi;
        }
    }


    private int FindRightProduct(int[] nums, int i)
    {
        if (i > nums.Length-1)
        {
            return 1;
        }

        if (rightProductMap.ContainsKey(i))
        {
            return rightProductMap[i];
        }
        else
        {
            var rightOfi = i+1;

            if (rightOfi > nums.Length - 1)
            {
                return 1;
            }

            var productToRightOfi = nums[rightOfi] * FindRightProduct(nums, rightOfi);

            rightProductMap.Add(i, productToRightOfi);

            return productToRightOfi;
        }
    }
}