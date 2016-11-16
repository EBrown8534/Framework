using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Collections
{
    [HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]
    public class ConcurrentStack<T> : IProducerConsumerCollection<T>, IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>
    {
        private T[] _items = new T[1];
        private int _currentIndex = 0;

        public void Push(T item)
        {
            lock (_items)
            {
                if (_items.Length == _currentIndex)
                {
                    var oldItems = _items;
                    _items = new T[_currentIndex * 2];

                    for (var i = 0; i < _currentIndex; i++)
                    {
                        _items[i] = oldItems[i];
                    }
                }

                _items[_currentIndex++] = item;
            }
        }

        public T Pop()
        {
            lock (_items)
            {
                var item = _items[--_currentIndex];
                _items[_currentIndex] = default(T);
                return item;
            }
        }

        public T Peek()
        {
            lock (_items)
            {
                return _items[_currentIndex];
            }
        }

        public void CopyTo(T[] array, int index)
        {
            T[] sourceArray = ToArray();
            sourceArray.CopyTo(array, index);
        }

        public bool TryAdd(T item)
        {
            Push(item);
            return true;
        }

        public bool TryTake(out T item) => TryPop(out item);

        private bool TryPop(out T item)
        {
            lock (_items)
            {
                if (_currentIndex == 0)
                {
                    item = default(T);
                    return false;
                }
            }

            item = Pop();
            return true;
        }

        public T[] ToArray()
        {
            lock (_items)
            {
                var sourceArray = new T[_currentIndex];

                for (int i = _currentIndex - 1; i >= 0; i--)
                {
                    sourceArray[_currentIndex - 1 - i] = _items[i];
                }

                return sourceArray;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (_items)
            {
                return new StackEnumerator<T>(_items, _currentIndex - 1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void CopyTo(Array array, int index)
        {
            T[] sourceArray = ToArray();
            sourceArray.CopyTo(array, index);
        }

        public int Count => _items.Length;

        public bool IsEmpty => _currentIndex == 0;

        public object SyncRoot { get { throw new NotSupportedException(); } }

        public bool IsSynchronized { get; } = false;
    }
}
