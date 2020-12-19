using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    class _381 : BaseClass
    {
        public override void Run()
        {
            var r = new RandomizedCollection();
            var f = r.Insert(1);
            f = r.Insert(1);
            f = r.Insert(2);
            var v = r.GetRandom();
            f = r.Remove(1);
            v = r.GetRandom();

            r = new RandomizedCollection();
            r.Insert(1);
            r.Remove(1);
            r.Insert(1);

            r = new RandomizedCollection();
            r.Insert(4);
            r.Insert(3);
            r.Insert(4);
            r.Insert(2);
            r.Insert(4);
            r.Remove(4);
            r.Remove(3);
            r.Remove(4);
            r.Remove(4);

            r = new RandomizedCollection();
            r.Insert(0);
            r.Remove(0);
            r.Insert(-1);
            r.Remove(0);
        }


    }

    public class RandomizedCollection
    {
        List<int> _Values;
        private readonly Dictionary<int, HashSet<int>> _Dict;//value-indexes
        private readonly Random _Random;
        /** Initialize your data structure here. */
        public RandomizedCollection()
        {
            _Values = new List<int>();
            _Dict = new Dictionary<int, HashSet<int>>();
            _Random = new Random();
        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            _Values.Add(val);
            if (_Dict.TryGetValue(val, out HashSet<int> indexes))
            {
                indexes.Add(_Values.Count - 1);
                return indexes.Count == 1;
            }
            _Dict.Add(val, new HashSet<int> { _Values.Count - 1 });
            return true;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (!_Dict.TryGetValue(val, out HashSet<int> indexes) || indexes.Count == 0)
                return false;
            var idx = indexes.First();
            indexes.Remove(idx);
            var set = _Dict[_Values.Last()];
            set.Remove(_Values.Count - 1);
            if (_Values.Count != idx + 1)
            {
                set.Add(idx);
                _Values[idx] = _Values.Last();
            }
            _Values.RemoveAt(_Values.Count - 1);
            return true;
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            int r = _Random.Next(0, _Values.Count);
            return _Values[r];
        }
    }
}
