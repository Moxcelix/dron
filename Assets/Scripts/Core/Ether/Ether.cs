using System.Collections.Generic;

namespace Core.Ether
{
    public class Ether<T> where T : ISignal
    {
        private readonly Stack<T> _signals;

        public Ether()
        {
            _signals = new Stack<T>();
        }

        public T CatchSignal()
        {
            return _signals.Pop();
        }

        public void SendSignal(T signal)
        {
            _signals.Push(signal);
        }
    }
}
