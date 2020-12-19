using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems._20201206
{
    class _5618 : BaseClass
    {
        public override void Run()
        {
            var i = MaxOperations(new int[] { 4,4,1,3,1,3,2,2,5,5,1,5,2,1,2,3,5,4}, 2);
            Assert(i, 2);

            i = MaxOperations(new int[] { 2, 5, 4, 4, 1, 3, 4, 4, 1, 4, 4, 1, 2, 1, 2, 2, 3, 2, 4, 2 }, 3);
            Assert(i, 4);
        }

        public int MaxOperations(int[] nums, int k)
        {
            var dict = nums.GroupBy(v => v).ToDictionary(g => g.Key, g => g.Count());
            int ans = 0;

            foreach(var key in dict.Keys.ToArray())
            {
                var cnt = dict[key];
                if (cnt < 1)
                    continue;
                var target = k - key;
                if (target == key)
                {
                    if (cnt > 1)
                    {
                        ans += cnt / 2;
                        dict[key] = cnt & 1;
                    }
                }
                else
                {
                    if (dict.TryGetValue(target, out int tCnt) && tCnt > 0)
                    {
                        int min = tCnt > cnt ? cnt : tCnt;
                        ans += min;
                        dict[key] -= min;
                        dict[target] -= min;
                    }
                }
            }
            return ans;
        }
    }
}
