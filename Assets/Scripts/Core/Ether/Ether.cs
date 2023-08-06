using Core.Transmitter;
using System.Collections.Generic;
using UnityEngine;

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
            if (!_signals.ContainsKey(channel))
            {
                return default;
            }

            return _signals[channel];
        }

        public void SendSignal(int channel, T signal)
        {
            _signals[channel] = signal;

            
            Debug.Log((signal as Command).Data);
        }
    }
}
