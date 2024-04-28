using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<string> stack = new MyStack<string>();

            stack.Push("Ali");
            stack.Push("Nicat");
            stack.Push("Jale");
            stack.Push("Aziz ");
            stack.Push("Taleh");
            stack.Push("Vusal");


            
            stack.Pop();

            Console.WriteLine("Sirada olani goster :"+stack.Peek());

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine("Count" + stack.Count);
            //Console.WriteLine("Capacity" + stack.Capacity);
        }
    }


    class MyStack<T> : IEnumerable
    {
        private T[] _arr;

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public MyStack()
        {
            Capacity = 4;
            _arr = new T[Capacity];
        }

        public MyStack(int capacity)
        {
            Capacity = capacity;
            _arr = new T[Capacity];
        }

        public MyStack(ICollection<T> a)
        {
            Capacity = a.Count;
            _arr = new T[a.Count];
        }

        public void Push(T value)
        {
            if (Count == Capacity)
            {
                Capacity *= 2;
                Array.Resize(ref _arr, Capacity);
            }
            _arr[Count] = value;
            Count++;

        }


        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("stack is empty");
            }

            var item = _arr[0];

            for (int i = 0; i < Count - 1; i++)
            {
                _arr[i] = _arr[i + 1];

            }
            Count--;
            return item;

        }

        public T Peek()
        {
            return _arr[0];
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _arr[i];
            }
        }
    }
}
