using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIterator
{
    public class IterationSample:IEnumerable
    {
        public object[] values;
        public int startingPoint;
        public IterationSample(object[] values,int startingPoint)
        {
            this.values = values;
            this.startingPoint = startingPoint;
        }
        public IEnumerator GetEnumerator()
        {
            return new IterationSampleIterator(this);
        }
        //public IEnumerator GetEnumerator()
        //{
        //    for (int index = 0; index < values.Length; index++)
        //    {
        //        yield return values[(index + startingPoint) % values.Length];
        //    }
        //}
    }
}
