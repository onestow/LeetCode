using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _861 : BaseClass
    {
        public override void Run()
        {
            MatrixScore(new int[][]
            {
                new int[]{0,0,1,1},
                new int[]{1,0,1,0},
                new int[]{1,1,0,0}
            });
        }

        public int MatrixScore(int[][] A)
        {
            int n = A.Length, m = A[0].Length;
            for (int i = 0; i < n; ++i)
            {
                if (A[i][0] == 1)
                    continue;
                for (int j = 0; j < m; ++j)
                    A[i][j] = (A[i][j] + 1) & 1;
            }

            int half = n >> 1;
            for (int i = 0; i < m; ++i)
            {
                int sum = 0;
                for (int j = 0; j < n; ++j)
                    sum += A[j][i];
                if (sum > half)
                    continue;
                for (int j = 0; j < n; ++j)
                    A[j][i] = (A[j][i] + 1) & 1;
            }

            int ans = 0;
            for (int i = 0; i < n; ++i)
            {
                int sum = 0;
                for (int j = 0; j < m; ++j)
                    sum = (sum << 1) + A[i][j];
                ans += sum;
            }
            return ans;
        }
    }
}
