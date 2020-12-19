using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _922 : BaseClass
    {
        public override void Run()
        {
            SortArrayByParityII(new int[] { 4, 2, 5, 7 });
        }

        public int[] SortArrayByParityII(int[] A)
        {
            var a1 = A.Where(v => (v & 1) == 1).ToArray();
            var a2 = A.Where(v => (v & 1) == 0).ToArray();
            for (int i = 0; i < a1.Length; ++i)
            {
                A[i << 1] = a2[i];
                A[(i << 1) + 1] = a1[i];
            }
            return A;
        }
    }
}
