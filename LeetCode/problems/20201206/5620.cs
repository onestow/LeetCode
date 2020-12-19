using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems._20201206
{
    class _5620 : BaseClass
    {
        public override void Run()
        {
            int k;
            k = ConcatenatedBinary(1);
            Assert(k, 1);
            k = ConcatenatedBinary(2);
            Assert(k, 6);
            k = ConcatenatedBinary(3);
            Assert(k, 27);
            k=ConcatenatedBinary(4);
            Assert(k, 220);
            k=ConcatenatedBinary(5);
            Assert(k, 1765);
            k=ConcatenatedBinary(6);
            Assert(k, 14126);
            k=ConcatenatedBinary(12);
            Assert(k, 505379714);
        }

        public int ConcatenatedBinary(int n)
        {
            long ans = 0;
            int mod = 10, len = 1;
            for (int i = 1; i <= n; ++i)
            {
                if (i == 1 << len)
                    len += 1;
                ans = ((ans << len) + i) % mod;
            }
            return (int)ans;
        }
    }
}
