using System;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(MaxOperations(new int[] { 1, 2, 3, 4 }, 5));     
        Console.WriteLine(MaxOperations(new int[] { 3, 1, 3, 4, 3 }, 6));

    }

    public static int MaxOperations(int[] nums, int k)
    {
        Array.Sort(nums);
        int left = 0,
            right = nums.Length - 1,
            count = 0;
        while (left < right)
        {
            int sum = nums[left] + nums[right];
            if (sum == k)
            {
                count++;
                left++;
                right--;
            }
            else if (sum > k)
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return count;
    }


}
