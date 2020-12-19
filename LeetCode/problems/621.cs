using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeetCode.problems
{
    class _621 : BaseClass
    {
        public override void Run()
        {
            int t;
            t = LeastInterval(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 2);
            Assert(t, 8);
            t = LeastInterval(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 0);
            Assert(t, 6);
            t = LeastInterval(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 1);
            Assert(t, 6);
            t = LeastInterval(new char[] {'A','A','A','A','A','A','B','C','D','E','F','G'}, 2);
            Assert(t, 16);
        }

        public int LeastInterval(char[] tasks, int n)
        {
            if (n == 0) return tasks.Length;
            int[] times = new int[26];
            int maxTime = 0, cnt = 0;
            foreach (char ch in tasks)
                maxTime = Math.Max(maxTime, ++times[ch - 'A']);
            foreach (int time in times)
                if (time == maxTime)
                    cnt += 1;
            var ans = (maxTime - 1) * (n + 1) + cnt;
            return ans > tasks.Length ? ans : tasks.Length;
        }
    }
}
