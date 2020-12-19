using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _376 : BaseClass
    {
        public override void Run()
        {
            int ans;
            ans = WiggleMaxLength(new int[] { 1, 7, 4, 9, 2, 5 });
            Assert(ans, 6);
            ans = WiggleMaxLength(new int[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 });
            Assert(ans, 7);
            ans = WiggleMaxLength(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Assert(ans, 2);
            ans = WiggleMaxLength(new int[] { 1, 1});
            Assert(ans, 2);
        }

        public int WiggleMaxLength(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;
            int dp0 = 1, dp1 = 1;
            for (int i = 1; i < nums.Length; ++i)
            {
                if (nums[i] > nums[i - 1])
                    dp0 = dp0 > dp1 + 1 ? dp0 : dp1 + 1;
                else if (nums[i] < nums[i - 1])
                    dp1 = dp1 > dp0 + 1 ? dp1 : dp0 + 1;
            }
            return dp0 > dp1 ? dp0 : dp1;
        }
    }
}
