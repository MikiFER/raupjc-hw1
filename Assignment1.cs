using System;
using System.Collections.Generic;

namespace Assignment1
{
    class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _count;
        public IntegerList()
        {
            _internalStorage = new int[4];
            _count = 0;
        }

        public IntegerList(int initalSize)
        {
            if (initalSize <= 0)  //napravit cu kao da nije nista stavljeno u ovom slucaju
            {
                _internalStorage = new int[4];
                _count = 0;
            }
            else
            {
                _internalStorage = new int[initalSize];
                _count = 0;
            }
        }

        public void Add(int item)
        {
            if (_internalStorage.Length == _count)
            {
                int[] replacement = new int[2 * _internalStorage.Length];
                for (int i = 0; i < _count; ++i)
                {
                    replacement[i] = _internalStorage[i];
                }
                replacement[_count] = item;
                ++_count;
                _internalStorage = replacement;
                //Ispis(_internalStorage);// ispis

            }
            else
            {
                _internalStorage[_count] = item;
                ++_count;
                //Ispis(_internalStorage);// ispis
            }
        }

        public bool Remove(int item)
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
                //Ispis(_internalStorage);// ispis
                return true;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int GetElement(int index)
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

        public int IndexOf(int item)
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
            //Ispis(_internalStorage);// ispis
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool Contains(int item)
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
