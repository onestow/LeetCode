using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _493 : BaseClass
    {
        public override void Run()
        {
            var t = ReversePairs(new int[] { 1, 3, 2, 3, 1 });
            Assert(t, 2);
            t = ReversePairs(new int[] { 2, 4, 3, 5, 1 });
            Assert(t, 3);
            t = ReversePairs(new int[] { 2147483647, 2147483647, 2147483647, 2147483647, 2147483647, 2147483647 });
            Assert(t, 0);
        }

        public int ReversePairs(int[] nums)
        {
            var distinctNums = nums.Distinct().Select(v => ((long)v) << 1).OrderBy(v => v).ToArray();
            var treeArr = new int[distinctNums.Length];

            int ans = 0;
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                var index = Find(distinctNums, nums[i]);
                if (index > 0)
                    ans += Sum(treeArr, index - 1);
                var ci = Find(distinctNums, ((long)nums[i]) << 1);
                Update(treeArr, ci, 1);
            }
            return ans;
        }

        int Find(long[] arr, long val)
        {
            int l = 0, r = arr.Length;
            while (l < r)
            {
                var m = (l + r) >> 1;
                if (arr[m] == val)
                    return m;
                if (arr[m] > val)
                    r = m;
                else
                    l = m + 1;
            }
            return l;
        }

        void Update(int[] arr, int i, int v)
        {
            while (i < arr.Length)
            {
                arr[i] += v;
                i += (i + 1) & (-i - 1);
            }
        }

        int Sum(int[] arr, int i)
        {
            int ans = 0;
            while (i >= 0)
            {
                ans += arr[i];
                i -= (i + 1) & (-i - 1);
            }
            return ans;
        }

        public int ReversePairs2(int[] nums)
        {
            int ans = 0;
            for (int i = 0; i < nums.Length; ++i)
                for (int j = i + 1; j < nums.Length; ++j)
                    if (nums[i] > 2 * nums[j])
                        ans += 1;
            return ans;
        }
    }
}
