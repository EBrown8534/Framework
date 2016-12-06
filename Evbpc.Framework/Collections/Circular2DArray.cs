using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Collections
{
    [Serializable]
    [ComVisible(true)]
    public class Circular2DArray<T> : IEnumerable<T>, IEnumerable, ICloneable, IList, ICollection, IStructuralComparable, IStructuralEquatable, IList<T>, ICollection<T>
    {
        private T[,] _array;
        private int _sizeLeft;
        private int _sizeRight;

        public Circular2DArray(int sizeLeft, int sizeRight)
        {
            _sizeLeft = sizeLeft;
            _sizeRight = sizeRight;
            _array = new T[_sizeLeft, _sizeRight];
        }

        public T this[int indexLeft, int indexRight]
        {
            get
            {
                return _array[(indexLeft < 0 ? _sizeLeft : 0) + indexLeft % _sizeLeft, (indexRight < 0 ? _sizeRight : 0) + indexRight % _sizeRight];
            }
            set
            {
                _array[(indexLeft < 0 ? _sizeLeft : 0) + indexLeft % _sizeLeft, (indexRight < 0 ? _sizeRight : 0) + indexRight % _sizeRight] = value;
            }
        }

        public int Length => _array.Length;

        public int GetLength(int dimension) => _array.GetLength(dimension);

        public bool IsFixedSize { get; } = true;

        public IEnumerator<T> GetEnumerator() => (IEnumerator<T>)_array.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _array.GetEnumerator();

        public bool IsReadOnly => false;

        int ICollection.Count => Length;

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        int ICollection<T>.Count => Length;

        bool ICollection<T>.IsReadOnly => IsReadOnly;

        T IList<T>.this[int index]
        {
            get
            {
                var tIndex = index % (_sizeLeft * _sizeRight);
                return this[(int)Math.Floor((double)tIndex / _sizeLeft), tIndex % _sizeLeft];
            }
            set
            {
                var tIndex = index % (_sizeLeft * _sizeRight);
                this[(int)Math.Floor((double)tIndex / _sizeLeft), tIndex % _sizeLeft] = value;
            }
        }

        object IList.this[int index] { get { return ((IList<T>)this)[index]; } set { ((IList<T>)this)[index] = (T)value; } }

        public object Clone()
        {
            var result = new T[_sizeLeft, _sizeRight];
            _array.CopyTo(result, 0);
            return result;
        }

        int IList.Add(object value) { throw new NotSupportedException(); }

        bool IList.Contains(object value) => value is T && ((IList)_array).Contains((T)value);

        void IList.Clear() { throw new NotSupportedException(); }

        int IList.IndexOf(object value) => ((IList)_array).IndexOf(value);

        void IList.Insert(int index, object value) { throw new NotSupportedException(); }

        void IList.Remove(object value) { throw new NotSupportedException(); }

        void IList.RemoveAt(int index) { throw new NotSupportedException(); }

        public void CopyTo(Array array, int index) => _array.CopyTo(array, index);

        int IStructuralComparable.CompareTo(object other, IComparer comparer) => ((IStructuralComparable)_array).CompareTo(other, comparer);

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer) => ((IStructuralEquatable)_array).Equals(other, comparer);

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer) => ((IStructuralEquatable)_array).GetHashCode(comparer);

        int IList<T>.IndexOf(T item) => ((IList)this).IndexOf(item);

        void IList<T>.Insert(int index, T item) { throw new NotSupportedException(); }

        void IList<T>.RemoveAt(int index) { throw new NotSupportedException(); }

        void ICollection<T>.Add(T item) { throw new NotSupportedException(); }

        void ICollection<T>.Clear() { throw new NotSupportedException(); }

        bool ICollection<T>.Contains(T item) => ((IList)_array).Contains(item);

        void ICollection<T>.CopyTo(T[] array, int arrayIndex) => CopyTo(array, arrayIndex);

        bool ICollection<T>.Remove(T item) { throw new NotSupportedException(); }
    }
}
