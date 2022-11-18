namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }


        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Grow();

            this.items[Count] = item;
            Count++;

        }

        private void Grow()
        {

            if (this.Count == this.items.Length)
            {

                var copyArr = new T[this.Count * 2];
                Array.Copy(items, copyArr, Count);
                this.items = copyArr;

            }

        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (items[this.Count - 1 - i].Equals(item))
                {
                    return i;
                }

            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            index = this.Count  - index;
            
            this.Grow();

            for (int i = Count; i >index; i--)
            {
                items[i ] = items[i-1];
            }

            items[index] = item;
           
            Count++;


        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            index = this.Count - 1 - index;

            for (int i = index; i < Count; i++)
            {

                this.items[i] = items[i + 1];
            }

            items[this.Count - 1] = default;
            this.Count--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void ValidateIndex(int index)
        {

            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
        }
    }
}