using UnityEngine;

namespace Core.Transmitter
{
    public class TransmitterBody : MonoBehaviour
    {
        private Transmitter _transmitter;

        public void Apply(Transmitter transmitter)
        {
            _transmitter = transmitter;
        }
    }
}