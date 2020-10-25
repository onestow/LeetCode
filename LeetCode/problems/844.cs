using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _844 : BaseClass
    {
        public override void Run()
        {
            var f = BackspaceCompare("##c", "aaa##c");
            Assert(f, false);
            f = BackspaceCompare("##c", "aa##c");
            Assert(f, true);
            f = BackspaceCompare("##c", "a##c");
            Assert(f, true);
        }

        public bool BackspaceCompare(string S, string T)
        {
            int si = S.Length - 1, ti = T.Length - 1;
            int sn = 0, tn = 0;
            while (si >= 0 || ti >= 0)
            {
                if (si >= 0)
                {
                    if (S[si] == '#')
                    {
                        si -= 1;
                        sn += 1;
                        continue;
                    }
                    if (sn > 0)
                    {
                        sn -= 1;
                        si -= 1;
                        continue;
                    }
                }
                if (ti >= 0)
                {
                    if (T[ti] == '#')
                    {
                        ti -= 1;
                        tn += 1;
                        continue;
                    }
                    if (tn > 0)
                    {
                        tn -= 1;
                        ti -= 1;
                        continue;
                    }
                }
                if (si >= 0 && ti >= 0)
                {
                    if (S[si] != T[ti])
                        return false;
                    si -= 1;
                    ti -= 1;
                }
                else
                    return false;
            }
            return true;
        }
    }
}
