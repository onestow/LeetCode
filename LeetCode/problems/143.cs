using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _143 : BaseClass
    {
        public override void Run()
        {
            var h = ListNode.BuildList(new int[] { 1});
            ReorderList(h);
        }

        public void ReorderList(ListNode head)
        {
            Stack<ListNode> s = new Stack<ListNode>();
            var cur = head;
            while (cur != null)
            {
                s.Push(cur);
                cur = cur.next;
            }
            int cnt = s.Count;
            int n = cnt >> 1;
            cur = new ListNode();
            ListNode ln = head;
            for (int i = 0; i < n; ++i)
            {
                cur.next = ln;
                ln = ln.next;
                var p = s.Pop();
                cur.next.next = p;
                cur = p;
            }
            if (cnt % 2 == 1)
            {
                cur.next = ln;
                ln.next = null;
            }
            else
                cur.next = null;
        }
    }
}
