using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _283 : BaseClass
    {
        public override void Run()
        {
            var t = new int[] { 0, 1, 0, 3, 12 };
            MoveZeroes(t);
            t = new int[] { 1, 0, 0, 0 };
            MoveZeroes(t);
        }

        public void MoveZeroes(int[] nums)
        {
            int i1 = 0, i = 0;
            while (i1 < nums.Length)
            {
                if (nums[i1] != 0)
                    nums[i++] = nums[i1];
                i1 += 1;
            }
            while (i1 < nums.Length)
                nums[i1++] = 0;
        }
    }
}
