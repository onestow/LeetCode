using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _763 : BaseClass
    {
        public override void Run()
        {
            var t = PartitionLabels("ababcbacadefegdehijhklij");
            Assert(t, new int[] { 9, 7, 8 });
        }

        public IList<int> PartitionLabels(string S)
        {
            int si = 0, li;
            var ans = new List<int>();
            var lis = new int[26];
            for (int i = 0; i < S.Length; ++i)
                lis[S[i] - 'a'] = i;
            while (si < S.Length)
            {
                char ch = S[si];
                li = lis[ch - 'a'];
                for (int i = si + 1; i <= li; ++i)
                    li = Math.Max(li, lis[S[i] - 'a']);
                ans.Add(li - si + 1);
                si = li + 1;
            }
            return ans;
        }
    }
}
