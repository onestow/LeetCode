using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _1024 : BaseClass
    {
        public override void Run()
        {
            var ans = VideoStitching(Build2DArray(new int[] { 0, 4, 2, 8 }, 2), 5);
            Assert(ans, 2);
            ans = VideoStitching(Build2DArray(new int[] { 0, 1, 6, 8, 0, 2, 5, 6, 0, 4, 0, 3, 6, 7, 1, 3, 4, 7, 1, 4, 2, 5, 2, 6, 3, 4, 4, 5, 5, 7, 6, 9 }, 2), 9);
            Assert(ans, 3);
        }

        public int VideoStitching(int[][] clips, int T)
        {
            clips = clips.OrderBy(r => r[0]).ThenByDescending(r => r[1]).ToArray();
            if (clips[0][0] != 0)
                return -1;
            int ans = 1, j = 1, t;
            int right = clips[0][1];
            while (right < T)
            {
                for (t = right; j < clips.Length && clips[j][0] <= right; ++j)
                    if (clips[j][1] > t)
                        t = clips[j][1];
                if (t == right)
                    break;
                right = t;
                ans += 1;
            }
            return right >= T ? ans : -1;
        }
    }
}
