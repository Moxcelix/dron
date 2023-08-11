using Core.Ether;

namespace Core.Transmitter
{
    public class Transmitter
    {
        private readonly Ether<Command> _ether;

        public Joystick[] Joysticks { get; }

        public Transmitter(Ether<Command> ether, Joystick[] joysticks)
        {
            _ether = ether;
            Joysticks = joysticks;
        }

        public void SendCommand(int channel, Command command)
        {
            _ether.SendSignal(channel, command);
        }
    }
}