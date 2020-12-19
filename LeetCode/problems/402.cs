using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _402 : BaseClass
    {
        public override void Run()
        {
            var f = RemoveKdigits("1432219", 3);
            Assert(f, "1219");
            f = RemoveKdigits("10200", 1);
            Assert(f, "200");
            f = RemoveKdigits("112", 1);
            Assert(f, "11");
            f = RemoveKdigits("43214321", 4);
            Assert(f, "21");
        }

        public string RemoveKdigits(string num, int k)
        {
            if (num.Length == k)
                return "0";
            if (k == 0)
                return num;
            var removeSet = new HashSet<int>(num.Length);
            int ci = 0, ni = 1;
            while (ni < num.Length && k > 0)
            {
                if (num[ci] <= num[ni])
                {
                    do { ci += 1; } while (removeSet.Contains(ci));
                    ni = ci + 1;
                    continue;
                }
                removeSet.Add(ci);
                k -= 1;
                if (ci == 0)
                {
                    do { ci += 1; } while (removeSet.Contains(ci));
                    ni = ci + 1;
                }
                else
                {
                    do { ci -= 1; } while (removeSet.Contains(ci));
                    if (ci == -1)
                    {
                        ci = ni;
                        ni += 1;
                    }
                }
            }
            for (int i = num.Length - 1; k > 0 && i >= 0; --i)
            {
                if (removeSet.Contains(i))
                    continue;
                removeSet.Add(i);
                k -= 1;
            }
            var sb = new StringBuilder();
            for (int i = 0; i < num.Length; ++i)
            {
                if (removeSet.Contains(i))
                    continue;
                sb.Append(num[i]);
            }
            var ans = sb.ToString().TrimStart('0');
            return ans.Length == 0 ? "0" : ans;
        }
    }
}
