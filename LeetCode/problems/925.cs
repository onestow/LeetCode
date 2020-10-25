using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _925 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public bool IsLongPressedName(string name, string typed)
        {
            int ni = 0, ti = 0;
            while (true)
            {
                if (ni == name.Length)
                    break;
                int nn = 0, tn = 0;
                var ch = name[ni];
                while (ni < name.Length && name[ni] == ch)
                {
                    ni += 1;
                    nn += 1;
                }
                while (ti < typed.Length && typed[ti] == ch)
                {
                    ti += 1;
                    tn += 1;
                }
                if (tn < nn)
                    return false;
            }
            return ti == typed.Length;
        }
    }
}
