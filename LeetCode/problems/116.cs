using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _116 : BaseClass
    {
        public override void Run()
        {
            var root = Node.BuildTree(new int?[] { 1, 2, 3, 4, 5, 6, 7 });
            Connect(root);
        }

        public Node Connect(Node root)
        {
            var parentHead = root;
            while(parentHead != null)
            {
                var pc = parentHead;
                bool? isRight = null;
                var cur = FindNext(ref pc, ref isRight);
                var next = FindNext(ref pc, ref isRight);
                var childHead = cur;
                while (next != null)
                {
                    cur.next = next;
                    cur = next;
                    next = FindNext(ref pc, ref isRight);
                }
                parentHead = childHead;
            }
            return root;
        }

        private Node FindNext(ref Node node, ref bool? isRight)
        {
            if (node == null)
                return null;
            if (isRight == false && node.right != null)
            {
                isRight = true;
                return node.right;
            }
            if (isRight == true)
                node = node.next;
            while (node != null)
            {
                if (node.left != null)
                {
                    isRight = false;
                    return node.left;
                }
                if (node.right != null)
                {
                    isRight = true;
                    return node.right;
                }
                node = node.next;
            }
            return null;
        }
    }
}
