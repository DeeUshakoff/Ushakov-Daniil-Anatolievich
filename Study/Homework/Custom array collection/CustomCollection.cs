using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Homework
{
    public interface ICustomCollection<T>
    {
        /// <summary>
        /// Collection size
        /// </summary>
        int Size();

        /// <summary>
        /// Is collection empty
        /// </summary>
        bool isEmpty();

        /// <summary>
        /// Determines whether an element is in the System.Collections.Generic.List`1.
        /// </summary>
        /// <param name="item">Object, that we are finding of</param>
        bool Contains(T item);

        /// <summary>
        /// Adds an object to the end of the collection
        /// </summary>
        void Add(T item);

        /// <summary>
        /// Adds the elements of the specified collection to the end of the collection
        /// </summary>
        /// <param name="items"></param>
        void AddRange(T[] items);

        /// <summary>
        /// Removes the first occurrence of a specific object from the collection
        /// </summary>
        void Remove(T item);

        /// <summary>
        /// Removes all occurrence of a specific object from the 
        /// </summary>
        void RemoveAll(T item);

        /// <summary>
        /// Removes the element at the specified index of the collection
        /// </summary>
        void RemoveAt(int index);

        /// <summary>
        /// Removes all element from the collection
        /// </summary>
        void Clear();

        /// <summary>
        /// Reverses the collection
        /// </summary>
        void Reverse();

        /// <summary>
        /// Inserting of an item at the selected position
        /// </summary>
        void Insert(int index, T item);

        /// <summary>
        /// Return the first index of item
        /// </summary>
        int IndexOf(T item);
    }
}
