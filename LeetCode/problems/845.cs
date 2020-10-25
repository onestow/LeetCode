using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _845 : BaseClass
    {
        public override void Run()
        {
            int t;
            t = LongestMountain(new int[] { 875, 884, 239, 731, 723, 685 });
            Assert(t, 4);
            t = LongestMountain(new int[] { 2, 1, 4, 7, 3, 2, 5 });
            Assert(t, 5);
            t = LongestMountain(new int[] { 2, 2, 2 });
            Assert(t, 0);
        }

        public int LongestMountain(int[] A)
        {
            int l = 0, m, r, ans = 0;
            while (l < A.Length)
            {
                for (m = l + 1; m < A.Length && A[m] > A[m - 1]; ++m) ;
                if (m == l + 1)
                {
                    l = m;
                    continue;
                }
                for (r = m; r < A.Length && A[r] < A[r - 1]; ++r) ;
                if (r > m)
                    ans = Math.Max(ans, r - l);
                l = r - 1;
            }
            return ans;
        }
    }
}
