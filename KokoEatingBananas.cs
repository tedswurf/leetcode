/*
We need to find a suitable number k such that k is a common denominator that is best suitabled for all piles in the array.
we want k to be as small as possible.

We know that the max k is the max pile in the array. This is because we can eat one full pile per hour at most.
Naturally, the min k is technically Ceiling(SUM(piles)/h). But this causes int overflow, so we will stick to 1.

We can use binary search between minK and maxK to find the optimal k.
At each iteration, we calculate k as the middle of minK and maxK.

To find the hours it takes to eat all piles, we can use the formula:
hours = SUM(CEILING(pile/k))

if hours <= h, technically we have a k speed that is sufficent, so we mark it down. However, we can check to reduce the k to find a better solution.
if hours > h, we eat too slowly, and need to increase the k to find a better solution.

*/
public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int left = 1,
            right = piles.Max();
        int result = right;

        while(left <= right) {
            int k = left + (right - left) / 2;

            // Use double here. An int will cause integer overflow, resulting in a negative number.
            double hours = 0;
            foreach(int pile in piles) {
                hours +=Math.Ceiling((double)pile/k);
            }

            if(hours <= h) {
                result = k;
                right = k - 1;
            } else {
                left = k + 1;
            }
        }

        return result;
    }
}