using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _842 : BaseClass
    {
        public override void Run()
        {
            var f = SplitIntoFibonacci("11235813");
            Assert(f, new int[] { 1, 1, 2, 3, 5, 8, 13 });
            f = SplitIntoFibonacci("112358130");
            Assert(f, new int[0]);
            f = SplitIntoFibonacci("0123");
            Assert(f, new int[0]);
            f = SplitIntoFibonacci("1101111");
            Assert(f, new int[] { 11, 0, 11, 11 });
            f = SplitIntoFibonacci("0000");
            Assert(f, new int[] { 0, 0, 0, 0 });
        }

        public IList<int> SplitIntoFibonacci(string S)
        {
            int half = S.Length >> 1;
            int first = 0, second;
            for (int i = 0; i < half; ++i)
            {
                if (i > 0 && S[0] == '0')
                    return new int[0];
                first = first * 10 + (S[i] & 0x0f);
                second = 0;
                for (int j = i + 1; j < S.Length; j++)
                {
                    if (j - i > 1 && S[i + 1] == '0')
                        break;
                    second = second * 10 + (S[j] & 0x0f);
                    if (Math.Max(i + 1, j - i) > S.Length - j - 1)
                        continue;

                    int t1 = first, t2 = second, t3 = t1 + t2, k = j + 1, ans = 0;
                    while (k < S.Length)
                    {
                        var len = StartWith(S, k, t3);
                        if (len == -1)
                            break;
                        ans += 1;
                        k += len;
                        t1 = t2;
                        t2 = t3;
                        t3 = t1 + t2;
                    }
                    if (k == S.Length)
                    {
                        int[] arr = new int[2 + ans];
                        arr[0] = first;
                        arr[1] = second;
                        for (int ai = 0; ai < ans; ++ai)
                            arr[ai + 2] = arr[ai] + arr[ai + 1];
                        return arr;
                    }
                }
            }
            return new int[0];
        }

        private int StartWith(string S, int si, int num)
        {
            var str = num.ToString();
            if (S.Length - si < str.Length)
                return -1;
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] != S[si + i])
                    return -1;
            }
            return str.Length;
        }
    }
}
