using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _860 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public bool LemonadeChange(int[] bills)
        {
            int c5 = 0, c10 = 0;
            for (int i = 0; i < bills.Length; ++i)
            {
                switch(bills[i])
                {
                    case 5:
                        c5 += 1;
                        break;
                    case 10:
                        if (c5 == 0)
                            return false;
                        c5 -= 1;
                        c10 += 1;
                        break;
                    case 20:
                        if (c10 > 0 && c5 > 0)
                        {
                            c10 -= 1;
                            c5 -= 1;
                        }
                        else if (c5 > 2)
                            c5 -= 3;
                        else
                            return false;
                        break;
                }
            }
            return true;
        }
    }
}
