using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20._3
{
    internal class QueueUsingStacks
    {
        private Stack<int> _stackIn;
        private Stack<int> _stackOut;

        public QueueUsingStacks()
        {
            _stackIn = new Stack<int>();
            _stackOut = new Stack<int>();
        }

        public void Enqueue(int item)
        {
            _stackIn.Push(item);
        }

        public int Dequeue()
        {
            if (_stackOut.Count == 0)
            {
                while (_stackIn.Count > 0)
                {
                    _stackOut.Push(_stackIn.Pop());
                }
            }

            if (_stackOut.Count == 0)
            {
                throw new InvalidOperationException("пусто");
            }

            return _stackOut.Pop();
        }

        public bool IsEmpty()
        {
            return _stackIn.Count == 0 && _stackOut.Count == 0;
        }
    }
}
