﻿namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {

            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Value { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }


        }
        private Node head;
        private Node tail;


        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node newNode = new Node(item);

            if (this.Count == 0)
            {
                this.head = newNode;
                this.tail = newNode;

            }
            else
            {
                this.head.Previous = newNode;
                newNode.Next = this.head;
                this.head = newNode;

            }
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node newNode = new Node(item);

            if (this.head == null)
            {
                this.head = this.tail = newNode;

            }
            else
            {

                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = newNode;

            }
            this.Count++;

        }

        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("But its empty!!");
            }
            return this.head.Value;
        }

        public T GetLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("But its empty!!");
            }

            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("But its empty!!");
            }

            var resulNode = this.head;

            if (this.head.Next == null)
            {
                this.head = this.tail = null;
            }

            else
            {
                this.head = this.head.Next;
                this.head.Previous = null;

            }

            this.Count--;
            return resulNode.Value;
        }

        public T RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("But its empty!!");
            }

            var resultNode = this.tail;
            if (this.Count == 1)
            {
                this.tail = this.head = null;
            }
            else
            {
                this.tail = this.tail.Previous;
                this.tail.Next = null;


            }
            this.Count--;
            return resultNode.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }


        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}