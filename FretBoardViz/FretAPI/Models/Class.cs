using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace FretAPI.Models
{

    class CircularArray<T>
    {
        private T[] array;
        private int size;
        private int head;

        public CircularArray(int capacity)
        {
            array = new T[capacity];
            size = 0;
            head = 0;
        }

        public int Count => size;

        public int Capacity => array.Length;

        public void Add(T item)
        {
            if (size < Capacity)
            {
                array[(head + size) % Capacity] = item;
                size++;
            }
            else
            {
                throw new InvalidOperationException("Circular array is full.");
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[(head + index) % Capacity];
            }
        }
    }
}