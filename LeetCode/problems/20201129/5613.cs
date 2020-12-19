using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems._20201129
{
    class _5613 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public int MaximumWealth(int[][] accounts)
        {
            return accounts.Select(row => row.Sum()).Max();
        }
    }
}
