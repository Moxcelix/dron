using Core.Ether;

namespace Core.Transmitter
{
    public class Command : ISignal
    {
        public string Data { get; }

        public Command(string data)
        {
            Data = data;
        }
    }
}