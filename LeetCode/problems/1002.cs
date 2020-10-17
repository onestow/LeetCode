using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _1002 : BaseClass
    {
        public override void Run()
        {
            var ans = CommonChars(new string[] { "bella", "label", "roller" });
        }

        public IList<string> CommonChars(string[] A)
        {
            var ans = A[0].GroupBy(ch => ch).ToDictionary(item => item.Key, item => item.Count());
            for (int i = A.Length - 1; i > 0; --i)
            {
                var d = A[i].Where(ch => ans.ContainsKey(ch))
                            .GroupBy(ch => ch)
                            .ToDictionary(item => item.Key, item => item.Count());
                var chs = ans.Keys.ToArray();
                foreach (var ch in chs)
                {
                    if (d.TryGetValue(ch, out int cnt))
                        ans[ch] = Math.Min(cnt, ans[ch]);
                    else
                        ans.Remove(ch);
                }
            }
            var arr = new List<string>();
            foreach(var kv in ans)
            {
                for (int i = 0; i < kv.Value; ++i)
                    arr.Add(kv.Key.ToString());
            }
            return arr;
        }
    }
}
