using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _118 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public IList<IList<int>> Generate(int numRows)
        {
            if (numRows < 1)
                return new List<IList<int>>();
            var listNums = new IList<int>[numRows];
            for (int i = 0; i < numRows; ++i)
            {
                listNums[i] = new int[i + 1];
                listNums[i][0] = listNums[i][i] = 1;
                for (int j = 1; j < i; ++j)
                    listNums[i][j] = listNums[i - 1][j] + listNums[i - 1][j - 1];
            }
            return listNums;
        }
    }
}
