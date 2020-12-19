using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    public class _144 : BaseClass
    {
        public override void Run()
        {
            PreorderTraversal(TreeNode.BuildTree(new int?[] { 3, 1, 2 }));
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            stack.Push(root);

            var ans = new List<int>();
            while (stack.Count > 0)
            {
                var cur = stack.Pop();
                if (cur == null)
                    continue;
                ans.Add(cur.val);
                stack.Push(cur.left);
                stack.Push(cur.right);
            }
            return ans;
        }
    }
}
