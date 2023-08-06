using Core.Ether;

namespace Core.Transmitter
{
    public class Command : ISignal
    {
        public int Data { get; }

        public Command(int data)
        {
            Data = data;
        }
    }
}