using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _1365 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var arr = Enumerable.Range(0, nums.Length).Select(idx => new int[] { nums[idx], idx, 0 }).OrderBy(item => item[0]).ToArray();
            for (int i = 1; i < nums.Length; ++i)
            {
                if (arr[i][0] > arr[i - 1][0])
                    arr[i][2] = i;
                else
                    arr[i][2] = arr[i - 1][2];
            }
            return arr.OrderBy(item => item[1]).Select(item => item[2]).ToArray();
        }
    }
}
