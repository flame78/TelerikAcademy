//5.Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString(). Check all input parameters to avoid accessing elements at invalid positions.

using System;
using System.Text;

namespace _05_07GenericList
{
    public class GenericList<T>
        where T : IComparable, new()
    {
        private T[] array;
        private int capacity;
        private int length = 0;

        public GenericList() : this(1) { }

        public GenericList(int capacity)
        {
            if (capacity < 1) throw new ArgumentOutOfRangeException();
            this.capacity = capacity;
            this.array = new T[capacity];
        }

        internal int Find(T element, int startPosition = 0)
        {
            for (int i = startPosition; i < this.length; i++)
            {
                if (element.CompareTo(this[i]) == 0) return i;
            }
            return -1;
        }

        //7.Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the  GenericList<T>. You may need to add a generic constraints for the type T.

        internal T Min()
        {
            T result = this[0];
            for (int i = 1; i < this.length; i++)
            {
                if (result.CompareTo(this[i]) == 1) result = this[i];
            }
            return result;
        }

        internal T Max()
        {
            T result = this[0];
            for (int i = 0; i < this.length; i++)
            {
                if (result.CompareTo(this[i]) == -1) result = this[i];
            }
            return result;
        }


        internal void Add(T element)
        {
            CheckCapacity();
            this[length] = element;
            this.length++;
        }

        internal void Clear()
        {
            this.array = new T[capacity];
            length = 0;
        }

        internal void InsertAt(T element, int position)
        {
            CheckIndex(position);
            CheckCapacity();

            for (int i = this.length ; i > position; i--)
            {
                this[i] = this[i - 1];
            }

            this[position] = element;
            this.length++;
        }


        internal void RemoveAt(int position)
        {
            CheckIndex(position);

            T[] result = new T[capacity];

            for (int i = 0; i < position; i++)
            {
                result[i] = this.array[i];
            }

            for (int i = position+1; i < this.length; i++)
            {
                result[i-1] = this.array[i];
            }

            this.array = result;
            length--;
        }

        //6.Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.

        private void CheckCapacity()
        {
            if (this.capacity == this.length)
            {

                T[] result = new T[this.capacity * 2];

                for (int i = 0; i < this.length; i++)
                {
                    result[i] = this.array[i];
                }

                this.capacity *= 2;

                this.array = result;
            }
        }



        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return this.array[index];
            }
            set
            {
                CheckIndex(index);
                this.array[index] = value;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > this.length)
                throw new ArgumentOutOfRangeException("Index out of range");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("GenericList<T>\nCapacity = ");
            result.Append(this.capacity);
            result.Append("\nLength = ");
            result.Append(this.length);
            result.Append("\n");

            for (int i = 0; i < this.length; i++)
            {
                result.Append(this[i]);
                if (i != this.length-1) result.Append(", ");
            }

            return result.ToString();
        }
    }
}
