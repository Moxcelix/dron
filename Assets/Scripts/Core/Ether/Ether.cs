using System.Collections.Generic;

namespace Core.Ether
{
    public class Ether<T> where T : ISignal
    {
        private readonly Dictionary<int, T> _signals;

        public Ether()
        {
            _signals = new Dictionary<int, T>();
        }

        public T CatchSignal(int channel)
        {
            return _signals[channel];
        }

        public void SendSignal(int channel, T signal)
        {
            _signals[channel] = signal;
        }
    }
}
