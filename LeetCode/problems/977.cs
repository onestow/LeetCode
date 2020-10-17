using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _977 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public int[] SortedSquares(int[] A)
        {
            var ans = new int[A.Length];
            int ai = A.Length, l = 0, r = A.Length - 1;
            int lv = A[0] * A[0], rv = A[r] * A[r];
            while (l <= r)
            {
                if (lv > rv)
                {
                    ans[--ai] = lv;
                    if (ai == 0)
                        break;
                    l += 1;
                    lv = A[l] * A[l];
                }
                else
                {
                    ans[--ai] = rv;
                    if (ai == 0)
                        break;
                    r -= 1;
                    rv = A[r] * A[r];
                }
            }
            return ans;
        }
    }
}
