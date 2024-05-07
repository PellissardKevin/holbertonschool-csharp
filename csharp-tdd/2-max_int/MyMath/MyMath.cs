using System;
using System.Collections.Generic;

namespace MyMath
{
    public class Operations
    {
        public static int Max(List<int> nums)
        {
            if (nums.Count == 0)
            {
                return 0;
            }
            var maxInt = nums[0];
            foreach (var item in nums)
            {
                if (item > maxInt)
                {
                    maxInt = item;
                }
            }
            return maxInt;
        }
    }
}
