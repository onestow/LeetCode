using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _52 : BaseClass
    {
        public override void Run()
        {
            var n = TotalNQueens(4);
        }

        public int TotalNQueens(int n)
        {
            return dfs(0, 0, 0, 0, n);
        }

        int dfs(int r, long c, long rx, long lx, int n)
        {
            if (r == n)
                return 1;

            int ans = 0;
            for (int i = 0; i < n; ++i)
            {
                if ((1L << i & c) != 0
                    || (1L << r + i & rx) != 0
                    || (1L << r - i + n & lx) != 0)
                    continue;
                ans += dfs(r + 1, 1L << i | c, 1L << r + i | rx, 1L << r - i + n | lx, n);
            }
            return ans;
        }
    }
}
