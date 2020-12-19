using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems._20201206
{
    class _5617 : BaseClass
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public string Interpret(string command)
        {
            return command.Replace("(al)", "al").Replace("()", "o");
        }
    }
}
