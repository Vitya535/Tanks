using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public class ConcreteIterator : Iterator
    {
        private readonly Aggregate _aggregate;
        private int Current;

        public ConcreteIterator(Aggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            return _aggregate[Current++];
        }

        public override object CurrentItem()
        {
            return _aggregate[Current];
        }

        public override bool IsDone()
        {
            return Current >= _aggregate.Count;
        }
    }
}
