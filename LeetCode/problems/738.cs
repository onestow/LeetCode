using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _738 : BaseClass
    {
        public override void Run()
        {
            var ans = MonotoneIncreasingDigits(332);
            Assert(ans, 299);

            ans = MonotoneIncreasingDigits(10);
            Assert(ans, 9);

            ans = MonotoneIncreasingDigits(12332);
            Assert(ans, 12299);

            ans = MonotoneIncreasingDigits(1234);
            Assert(ans, 1234);

            ans = MonotoneIncreasingDigits(6655);
            Assert(ans, 5999);

            ans = MonotoneIncreasingDigits(668841);
            Assert(ans, 667999);
        }

        public int MonotoneIncreasingDigits(int N)
        {
            if (N < 10)
                return N;
            var stack = new Stack<int>();
            while (N > 0)
            {
                stack.Push(N % 10);
                N /= 10;
            }

            int ans = stack.Pop();
            int pre = ans, cur;
            while (stack.Count > 0)
            {
                cur = stack.Peek();
                if (cur < pre)
                    break;
                stack.Pop();
                ans = ans * 10 + cur;
                pre = cur;
            }
            if (stack.Count == 0)
                return ans;
            int len = stack.Count;
            while (ans % 10 == ans / 10 % 10)
            {
                ans /= 10;
                len += 1;
            }
            ans -= 1;
            for (int i = 0; i < len; ++i)
                ans = ans * 10 + 9;
            return ans;
        }
    }
}
