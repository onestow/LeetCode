using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _19 : BaseClass
    {
        public override void Run()
        {
            var h = RemoveNthFromEnd(ListNode.BuildList(new int[] { 1, 2, 3, 4, 5, 6 }), 6);
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode p1 = head, p2 = head;
            for (int i = 0; i < n; ++i)
                p1 = p1.next;
            if (p1 == null)
                return head.next;
            while (p1.next != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }
            p2.next = p2.next.next;
            return head;
        }
    }
}
