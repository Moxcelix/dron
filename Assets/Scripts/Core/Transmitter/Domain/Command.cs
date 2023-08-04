using Core.Ether;

namespace Core.Transmitter
{
    public class Command : ISignal
    {
        public float Frequency { get; }

        public Command (float frequency)
        {
            Frequency = frequency;
        }
    }
}