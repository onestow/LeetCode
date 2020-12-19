using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _140 : BaseClass
    {
        public override void Run()
        {
            var t = WordBreak("catsanddog", new string[] { "cat", "cats", "and", "sand", "dog" });
            t = WordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" });
        }

        List<int[]> ans;
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var root = BuildTree(wordDict);
            ans = new List<int[]>();
            Dfs(s, 0, root, root, new List<int>());
            var strs = new string[ans.Count];
            for (int i = 0; i < ans.Count; i++)
                strs[i] = string.Join(' ', ans[i].Select(idx => wordDict[idx]));
            return strs;
        }

        public DictTree BuildTree(IList<string> wordDict)
        {
            var root = new DictTree(' ');
            for (int i = wordDict.Count - 1; i >= 0; --i)
                BuildTree(root, wordDict[i], 0, i);
            return root;
        }

        public void BuildTree(DictTree node, string word, int wi, int di)
        {
            if (!node.Childs.TryGetValue(word[wi], out DictTree child))
            {
                child = new DictTree(word[wi]);
                node.Childs.Add(word[wi], child);
            }
            if (wi == word.Length - 1)
                child.Idx = di;
            else
                BuildTree(child, word, wi + 1, di);
        }

        public bool Dfs(string s, int si, DictTree root, DictTree node, List<int> listIdx)
        {
            if (si == s.Length)
            {
                if (root == node)
                    ans.Add(listIdx.ToArray());
                return true;
            }
            if (!node.Childs.TryGetValue(s[si], out DictTree child))
                return false;
            Dfs(s, si + 1, root, child, listIdx);
            if (child.Idx != -1)
            {
                listIdx.Add(child.Idx);
                Dfs(s, si + 1, root, root, listIdx);
                listIdx.RemoveAt(listIdx.Count - 1);
            }
            return false;
        }

        public class DictTree
        {
            public char Value { get; }
            public int Idx { get; set; } = -1;
            public Dictionary<char, DictTree> Childs { get; }

            public DictTree(char ch)
            {
                Childs = new Dictionary<char, DictTree>();
                Value = ch;
            }
        }
    }
}
