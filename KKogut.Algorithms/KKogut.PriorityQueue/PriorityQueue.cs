using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKogut.PriorityQueue
{
    public class PriorityQueue<T> where T : IComparable
    {
        private Heap<T> heap;

        public object Count { get { return heap.Count; } }

        public PriorityQueue(int size)
        {
            heap = new Heap<T>(size);
        }

        public void Enqueue(T item)
        {
            try
            {
                heap.Add(item);
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Cannot enqueue more elements than queue size.");
            }
        }

        public T Dequeue()
        {
            try
            {
                return heap.Remove();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("No elements in queue.");
            }
        }

        public T Min
        {
            get { return heap.Min; }
        }
    }
}
