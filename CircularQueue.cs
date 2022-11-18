namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] items;
        private int startIndex;
        private int endIndex;


        public CircularQueue(int capacity)
        {
            this.items = new T[capacity];

        }

        public CircularQueue()
        {
            this.items = new T[4];
        }
        public int Count { get; set; }

        public T Dequeue()
        {

            if (Count == 0)
            {
                throw new InvalidOperationException("Its empty you fool!");
            }

            var resultEl = items[startIndex];

            this.startIndex = (startIndex + 1) % items.Length;
            
            this.Count--;
            return resultEl;
        }

        public void Enqueue(T item)
        {

            if (Count >= this.items.Length)
            {
                this.Grow();
            }

            this.items[endIndex] = item;
            this.endIndex = (endIndex + 1) % items.Length;
            this.Count++;
        }



        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Its empty you fool!");
            }
            return items[startIndex];
        }

        public T[] ToArray()
        {
            return this.CopyItems(new T[this.Count]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[(startIndex + i) % items.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Grow()
        {
            this.items = this.CopyItems(new T[items.Length*2]);
            this.startIndex = 0;
            this.endIndex = Count;

        }

        public T[] CopyItems(T[] resultArr)
        {
            
            for (int i = 0; i < this.Count; i++)
            {

                resultArr[i] = items[(startIndex + i)%this.items.Length];
            }
            return resultArr;
        }


    }

}


