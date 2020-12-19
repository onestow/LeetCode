using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _973 : BaseClass
    {
        public override void Run()
        {
            KClosest(new int[][] 
            { 
                new int[] { 2, 2 },
                new int[] { 5, 5 },
                new int[] { 3, 3 },
                new int[] { 6, 6 },
                new int[] { 1, 1 },
                new int[] { 7, 7 },
                new int[] { 4, 4 },
            }, 2);
        }

        public int[][] KClosest(int[][] points, int K)
        {
            return points.OrderBy(p => p[0] * p[0] + p[1] * p[1]).Take(K).ToArray();
            var pts = points.Select(p => new int[] { p[0], p[1], p[0] * p[0] + p[1] * p[1] }).ToArray();
            QuickSort(pts, K, 0, points.Length);
            return pts.Take(K).Select(p => new int[] { p[0], p[1] }).ToArray();
        }

        private void QuickSort(int[][] points, int k, int l, int r)
        {
            if (r - l < 2)
                return;
            var cd = points[l][2];
            int li = l, ri = r - 1, ci = l;
            int[] t = points[ci];
            while (li < ri)
            {
                while (li < ri && points[ri][2] >= cd)
                    ri -= 1;
                if (li == ri)
                    break;
                points[ci] = points[ri];
                ci = ri;
                while (li < ri && points[li][2] <= cd)
                    li += 1;
                points[ci] = points[li];
                ci = li;
            }
            points[li] = t;

            if (li == k - 1)
                return;
            if (li > k)
                QuickSort(points, k, l, li);
            else
                QuickSort(points, k, li + 1, r);
        }
    }
}
