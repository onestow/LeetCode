using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _222 : BaseClass
    {
        public override void Run()
        {
            var ans = CountNodes(TreeNode.BuildTree(new int?[] { 1, 2, 3 }));
        }

        public int CountNodes(TreeNode node)
        {
            if (node == null)
                return 0;
            var ld = Depth(node.left);
            var rd = Depth(node.right);
            return CountNodes(ld == rd ? node.right : node.left) + (1 << rd);
        }

        public int Depth(TreeNode node)
        {
            if (node == null)
                return 0;
            return Depth(node.left) + 1;
        }
    }
}
