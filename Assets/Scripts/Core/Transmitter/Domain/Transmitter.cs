using Core.Ether;
using Core.Utilities;
using UnityEngine;

namespace Core.Transmitter
{
    public class Transmitter
    {
        private readonly Ether<Command> _ether;

        private int _channel;

        public Joystick[] Joysticks { get; }

        public Transmitter(
            Ether<Command> ether,
            int channel,
            Joystick[] joysticks)
        {
            _ether = ether;
            _channel = channel;
            Joysticks = joysticks;
        }

        public void SendCommand(Command command)
        {
            _ether.SendSignal(_channel, command);
        }

        public void Update()
        {
            var data = new string[]
            {
                JsonUtility.ToJson(Joysticks[0].Position),
                JsonUtility.ToJson(Joysticks[1].Position),
            };

            SendCommand(new(JsonUtility.ToJson(new ArrayWrapper<string>(data))));
        }
    }
}