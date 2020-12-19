using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems._20201129
{
    class _5615 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public int MinMoves(int[] nums, int limit)
        {
            int hlen = nums.Length >> 1;
            var dictSum = new Dictionary<int, int>();
            int sum;
            for (int i = 0; i < hlen; ++i)
            {
                sum = nums[i] + nums[nums.Length - i - 1];
                if (dictSum.TryGetValue(sum, out int cnt))
                    dictSum[sum] = cnt + 1;
                else
                    dictSum.Add(sum, 1);
            }
            
            var f = dictSum.OrderByDescending(kv => kv.Value).First().Key;
            return 0;
        }
    }
}
