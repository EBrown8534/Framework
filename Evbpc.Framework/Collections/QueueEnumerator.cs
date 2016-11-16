using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Collections
{
    public class QueueEnumerator<T> : IEnumerator<T>
    {
        private T[] _buffer;
        private int _startIndex;
        private int _currentIndex;
        private int _endIndex;

        public QueueEnumerator(T[] buffer, int startIndex, int endIndex)
        {
            _buffer = buffer;
            _startIndex = startIndex - 1;
            _currentIndex = startIndex - 1;
            _endIndex = endIndex;
            Current = default(T);
        }

        public T Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (++_currentIndex >= _endIndex)
            {
                return false;
            }
            else
            {
                Current = _buffer[_currentIndex];
            }
            return true;
        }

        public void Reset()
        {
            _currentIndex = _startIndex - 1;
        }
    }
}
