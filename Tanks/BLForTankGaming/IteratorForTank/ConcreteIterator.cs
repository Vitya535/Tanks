using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    class ConcreteIterator : Iterator
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
            object ret = null;
            Current++;
            if (Current < _aggregate.Count)
                ret = _aggregate[Current];
            return ret;
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
