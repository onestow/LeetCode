using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.problems
{
    class _649 : BaseClass
    {
        public override void Run()
        {
            var f = PredictPartyVictory("RRDDD");
            Assert(f, "Radiant");
            f = PredictPartyVictory("RRDDDD");
            Assert(f, "Dire");
            f = PredictPartyVictory("RRDD");
            Assert(f, "Radiant");
            f = PredictPartyVictory("RRRDDDDDR");
            Assert(f, "Radiant");
        }

        public string PredictPartyVictory(string senate)
        {
            var len = senate.Length;
            var qd = new Queue<int>();
            var qr = new Queue<int>();
            for (int i = 0; i < len; ++i)
                if (senate[i] == 'R')
                    qr.Enqueue(i);
                else
                    qd.Enqueue(i);

            while (qd.Count > 0 && qr.Count > 0)
            {
                var di = qd.Dequeue();
                var ri = qr.Dequeue();

                if (di > ri)
                    qr.Enqueue(ri + len);
                else
                    qd.Enqueue(di + len);
            }
            if (qd.Count > 0)
                return "Dire";
            else 
                return "Radiant";
        }
    }
}
