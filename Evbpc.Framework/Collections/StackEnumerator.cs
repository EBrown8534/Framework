using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Collections
{
    public class StackEnumerator<T> : IEnumerator<T>
    {
        private T[] _buffer;
        private int _startIndex;
        private int _currentIndex;

        public StackEnumerator(T[] buffer, int startIndex)
        {
            _buffer = buffer;
            _startIndex = startIndex + 1;
            _currentIndex = _startIndex;
            Current = default(T);
        }

        public T Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (--_currentIndex < 0)
            {
                return false;
            }

            Current = _buffer[_currentIndex];
            return true;
        }

        public void Reset()
        {
            _currentIndex = _startIndex;
        }
    }
}
