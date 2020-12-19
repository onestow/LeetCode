using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems._20201206
{
    class _5619 : BaseClass
    {
        public override void Run()
        {
            var sum = MinimumIncompatibility(new int[] { 1, 2, 3, 3 }, 2);
            Assert(sum, 3);
            sum = MinimumIncompatibility(new int[] { 1, 2, 1, 4 }, 2);
            Assert(sum, 4);
            sum = MinimumIncompatibility(new int[] { 6, 3, 8, 1, 3, 1, 2, 2 }, 4);
            Assert(sum, 6);
            sum = MinimumIncompatibility(new int[] { 5, 3, 3, 6, 3, 3 }, 3);
            Assert(sum, -1);
        }

        int ans, curSum;
        HashSet<int> set;
        Dictionary<int, int> dict;
        public int MinimumIncompatibility(int[] nums, int k)
        {
            set = new HashSet<int>();
            dict = nums.GroupBy(v => v).ToDictionary(g => g.Key, g => g.Count());
            int len = nums.Length / k;
            curSum = 0;
            ans = int.MaxValue;
            dfs(nums, k, len, 0);
            return ans;
        }

        void dfs(int[] nums, int k, int len, int curIdx)
        {
            if (set.Count > 0 && curIdx % len == 0)
            {
                curSum += set.Max() - set.Min();
                if (curSum >= ans)
                    return;
                set.Clear();
            }
            if (curIdx == nums.Length)
            {
                if (ans > curSum) ans = curSum;
                return;
            }
            foreach(var key in dict.Keys.ToArray())
            {
                if (dict[key] < 1)
                    continue;
                if (!set.Add(key))
                    continue;
                int value = dict[key];
                dict[key] = value - 1;
                dfs(nums, k, len, curIdx + 1);
                dict[key] = value;
            }
        }

        public int MinimumIncompatibility2(int[] nums, int k)
        {
            var dict = nums.GroupBy(v => v).ToDictionary(g => g.Key, g => g.Count());
            int len = nums.Length / k, ans = 0;
            for (int i = 0; i < k; ++i)
            {
                var values = dict.OrderByDescending(kv => kv.Value).Take(len).Select(kv => kv.Key).ToArray();
                if (values.Length < len)
                    return -1;
                foreach(var value in values)
                {
                    if (dict[value] == 1) dict.Remove(value);
                    else dict[value] -= 1;
                }
                ans += values.Max() - values.Min();
            }
            return ans;
        }
    }
}
