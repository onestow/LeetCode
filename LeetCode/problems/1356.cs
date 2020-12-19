using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _1356 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public int[] SortByBits(int[] arr)
        {
            var dict = new Dictionary<int, List<int>>();
            foreach (var item in arr)
            {
                int bc = 0;
                int val = item;
                while (val > 0)
                {
                    bc += val & 1;
                    val >>= 1;
                }
                if (dict.TryGetValue(bc, out List<int> list))
                    list.Add(item);
                else
                    dict.Add(bc, new List<int> { item });
            }
            var ans = new List<int>();
            foreach (var key in dict.Keys.OrderBy(item => item))
                ans.AddRange(dict[key].OrderBy(item => item));
            return ans.ToArray();
        }
    }
}
