using Core.Ether;

namespace Core.Transmitter
{
    public class Transmitter
    {
        private readonly Ether<Command> _ether;

        public Transmitter(Ether<Command> ether)
        {
            _ether = ether;
        }

        public void SendCommand(Command command)
        {
            _ether.SendSignal(command);
        }
    }
}