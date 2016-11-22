using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Collections
{
    public class Queue<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>, ICollection<T>
    {
        private T[] _items = new T[1];
        private int _nextAssignment = 0;
        private int _nextRead = 0;

        public Queue()
        {
            SyncRoot = this;
        }

        public Queue(int capacity)
            : base()
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            var itemCount = _items.Length;

            if (itemCount == _nextAssignment && _nextRead > 8)
            {
                _nextAssignment -= _nextRead;
                for (int i = 0; i < _nextAssignment; i++)
                {
                    _items[i] = _items[i + _nextRead];
                }

                _nextRead = 0;
            }

            if (itemCount == _nextAssignment)
            {
                var oldItems = _items;
                _items = new T[itemCount * 2];

                for (var i = 0; i < oldItems.Length; i++)
                {
                    _items[i] = oldItems[i];
                }
            }

            _items[_nextAssignment] = item;

            _nextAssignment++;
        }

        public T Pop()
        {
            var item = _items[_nextRead];
            _items[_nextRead++] = default(T);
            return item;
        }
        
        public T Peek() => _items[_nextRead];

        public IEnumerator<T> GetEnumerator() => new QueueEnumerator<T>(_items, _nextRead, _nextAssignment);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void CopyTo(Array array, int index)
        {
            var sourceArray = new T[_nextAssignment - _nextRead];

            for (int i = _nextRead; i < _nextAssignment; i++)
            {
                sourceArray[i - _nextRead] = _items[i];
            }

            sourceArray.CopyTo(array, index);
        }

        public void Add(T item) => Push(item);

        public void Clear()
        {
            for (int i = _nextRead; i < _nextAssignment; i++)
            {
                _items[i] = default(T);
            }

            _nextRead = 0;
            _nextAssignment = 0;
        }

        public bool Contains(T item) => _items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => CopyTo((Array)array, arrayIndex);

        public bool Remove(T item)
        {
            if (item.Equals(_items[_nextRead]))
            {
                Pop();
                return true;
            }

            throw new ArgumentOutOfRangeException(nameof(item), $"The value provided for the argument '{nameof(item)}' must be the first item in the {nameof(Queue<T>)}.");
        }
        
        public int Count => _nextAssignment - _nextRead;

        public int BufferSize => _items.Length;

        public object SyncRoot { get; }

        public bool IsSynchronized { get; } = false;

        public bool IsReadOnly { get; } = false;
    }
}
