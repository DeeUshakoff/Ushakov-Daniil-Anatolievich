using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Homework
{
    public class CustomArrayCollecton<T> : ICustomCollection<T>
    {
        private T[] array = Array.Empty<T>();

        public void Add(T item) => array = array.Append(item).ToArray();

        public void AddRange(params T[] items) => array = array.Concat(items).ToArray();

        public void Clear() => array = Array.Empty<T>();

        public bool Contains(T item) => array.Contains(item);

        public int IndexOf(T item) => Array.IndexOf(array, item);

        public void Insert(int index, T item) => array = array.Take(index).Append(item).Concat(array.TakeLast(Size() - index)).ToArray();

        public bool isEmpty() => Size() == 0 && array == null;

        public void Remove(T item) => array = array.Where((val, idx) => idx != IndexOf(item)).ToArray();

        public void RemoveAll(T item) => array = array.Where(x => !x.Equals(item)).ToArray();

        public void RemoveAt(int index) => array = array.Where((val, idx) => idx != index).ToArray();

        public void Reverse() => Array.Reverse(array);

        public int Size() => array.Length;
        public override string ToString() => String.Join(" ", array);
    }
}
