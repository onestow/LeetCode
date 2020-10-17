using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _117 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public Node Connect(Node root)
        {
            var q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int cnt = q.Count;
                var node = q.Dequeue();
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
                for (int i = cnt - 1; i > 0; --i)
                {
                    node.next = q.Dequeue();
                    node = node.next;
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
            }
            return root;
        }
    }

}
