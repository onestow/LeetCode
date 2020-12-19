using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LeetCode.problems
{
    class _122 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public int MaxProfit(int[] prices)
        {
            int ans = 0, diff;
            for (int i = 1; i < prices.Length; ++i)
            {
                diff = prices[i] - prices[i - 1];
                if (diff > 0)
                    ans += diff;
            }
            return ans;
        }
    }
}
