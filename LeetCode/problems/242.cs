using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _242 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            var cs = new int[26];
            foreach (var c in s)
                cs[c - 'a'] += 1;
            foreach (var c in t)
                if (cs[c - 'a'] == 0)
                    return false;
                else
                    cs[c - 'a'] -= 1;
            return true;
        }
    }
}
