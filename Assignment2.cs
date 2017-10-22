using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class GenericList<T> : IGenericList<T>
    {
        private T[] _internalStorage;
        private int _count;
        public GenericList()
        {
            _internalStorage = new T[4];
            _count = 0;
        }

        public GenericList(int initalSize)
        {
            if (initalSize <= 0)  //napravit cu kao da nije nista stavljeno u ovom slucaju
            {
                _internalStorage = new T[4];
                _count = 0;
            }
            else
            {
                _internalStorage = new T[initalSize];
                _count = 0;
            }
        }

        public void Add(T item)
        {
            if (_internalStorage.Length == _count)
            {
                T[] replacement = new T[2 * _internalStorage.Length];
                for (int i = 0; i < _count; ++i)
                {
                    replacement[i] = _internalStorage[i];
                }
                replacement[_count] = item;
                ++_count;
                _internalStorage = replacement;

            }
            else
            {
                _internalStorage[_count] = item;
                ++_count;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                return RemoveAt(index);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAt(int index)
        {
            if (index < _count && index >= 0)
            {
                for (int i = index; i < _count; ++i)
                {
                    _internalStorage[i] = _internalStorage[i + 1];
                }
                --_count;
                return true;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public T GetElement(int index)
        {
            if (index >= 0 && index < _count)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; ++i)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Clear()
        {
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
