using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _48 : BaseClass
    {
        public override void Run()
        {
            Enumerable.Range(1, 15).Select
            Rotate(Build2DArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3));
        }

        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;

            int t, t1, t2;
            for (int ci = n / 2 - 1; ci >= 0; --ci)
            {
                t1 = n - ci - 1;
                for (int ri = t1; ri > ci; --ri)
                {
                    t2 = n - ri - 1;
                    t = matrix[ci][ri];
                    matrix[ci][ri] = matrix[t2][ci];
                    matrix[t2][ci] = matrix[t1][t2];
                    matrix[t1][t2] = matrix[ri][t1];
                    matrix[ri][t1] = t;
                }
            }
        }
    }
}
