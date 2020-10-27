using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIterator
{
    public class IterationSampleIterator : IEnumerator
    {
        IterationSample parent;
        int position;
        internal IterationSampleIterator(IterationSample parent)
        {
            this.parent = parent;
            this.position = -1;
        }

        public object Current
        {
            get
            {
                if (position == -1 || position == parent.values.Length)
                {
                    throw new InvalidOperationException();
                }
                int index = position + parent.values.Length;
                index = index % parent.values.Length;
                return parent.values[index];
            }
        }

        public bool MoveNext()
        {
            if (position != parent.values.Length)
            {
                position++;
            }
            return position < parent.values.Length;
        }


        public void Reset()
        {
            position = -1;
        }
    }
}
