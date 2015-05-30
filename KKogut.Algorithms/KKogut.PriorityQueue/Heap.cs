using System;

namespace KKogut.PriorityQueue
{
    class Heap<T> where T : IComparable
    {
        private T[] array;

        private int count;
        public int Count
        {
            get { return count; }
            private set { count = value; }
        }

        public Heap(int size)
        {
            count = 0;
            array = new T[size + 1];
        }

        internal void Add(T item)
        {
            if (count + 1 > array.Length - 1)
                throw new IndexOutOfRangeException();
            count++;
            array[count] = item;
            ReorderBottomUp();
        }

        private void ReorderBottomUp()
        {
            int i = count;
            while (i > 1)
            {
                if (array[i].CompareTo(array[i / 2]) < 0)
                {
                    Swap(i, i / 2);
                    i /= 2;
                }
                else
                {
                    return;
                }
            }
        }

        private void Swap(int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

        internal T Remove()
        {
            if (count < 1)
                throw new InvalidOperationException();
            var result = array[1];
            array[1] = array[count];
            array[count] = default(T);
            count--;
            ReorderTopDown();
            return result;
        }

        private void ReorderTopDown()
        {
            int i = 1;
            while (i <= count / 2)
            {
                if (array[i].CompareTo(array[2 * i]) > 0 || array[i].CompareTo(array[2 * i + 1]) > 0)
                {
                    i = Swap(i, 2 * i, 2 * i + 1);
                }
                else
                {
                    return;
                }
            }
        }

        private int Swap(int parentIndex, int leftChildIndex, int rightChildIndex)
        {
            if (rightChildIndex > count || array[leftChildIndex].CompareTo(array[rightChildIndex]) <= 0)
            {
                Swap(parentIndex, leftChildIndex);
                return leftChildIndex;
            }
            Swap(parentIndex, rightChildIndex);
            return rightChildIndex;
        }

        internal T Min
        {
            get { return array[1]; }
        }
    }
}
