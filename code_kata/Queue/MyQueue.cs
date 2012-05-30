using System;
using System.Collections.Generic;

namespace code_kata.Queue
{
    public class MyQueue<T>
    {
        private readonly List<T> queue = new List<T>();

        public int Count
        {
            get { return queue.Count; }
        }

        public void Enqueue(T item)
        {
            queue.Add(item);
        }

        public T Dequeue()
        {
            if(queue.Count > 0)
            {
                var index = 0;
                var result = queue[index];
                queue.RemoveAt(index);
                return result;
            }
            throw new InvalidOperationException();
        }
    }
}