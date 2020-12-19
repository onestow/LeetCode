using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems._20201129
{
    class _5614 : BaseClass
    {
        public override void Run()
        {
            var ans = MostCompetitive(new int[] { 2, 4, 3, 3, 5, 4, 9, 6 }, 4);
            ans = MostCompetitive(new int[] { 3, 5, 2, 6 }, 2);
        }

        public int[] MostCompetitive(int[] nums, int k)
        {
            int target = nums.Length - k;
            if (target == 0)
                return nums;

            var stack = new Stack<int>();
            int index = nums.Length, popCnt = 0;
            for (int i = 0; i < nums.Length && popCnt < target; ++i)
            {
                if (stack.Count == 0)
                {
                    stack.Push(nums[i]);
                    continue;
                }

                while (stack.Count > 0 && stack.Peek() > nums[i])
                {
                    stack.Pop();
                    if (++popCnt == target)
                    {
                        index = i;
                        break;
                    }
                }
                stack.Push(nums[i]);
            }

            var arr = new int[nums.Length];
            int ni = stack.Count;
            for (int i = stack.Count - 1; i >= 0; --i)
                arr[i] = stack.Pop();

            for (index += 1; index < nums.Length; ++index, ++ni)
                arr[ni] = nums[index];
            return arr.Take(k).ToArray();
        }
    }
}
