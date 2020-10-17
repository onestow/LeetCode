using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _530 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        int val, min;
        public int GetMinimumDifference(TreeNode root)
        {
            val = -1;
            min = 0xffffff;
            dfs(root);
            return min;
        }

        void dfs(TreeNode node)
        {
            if (node == null)
                return;

            dfs(node.left);
            if (val >= 0)
                min = Math.Min(min, Math.Abs(val - node.val));
            val = node.val;
            dfs(node.right);
        }
    }
}
