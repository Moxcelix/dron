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

        public Transmitter(Ether<Command> ether, Joystick[] joysticks)
        {
            _ether = ether;
            Joysticks = joysticks;
        }

        public void SendCommand(int channel, Command command)
        {
            _ether.SendSignal(channel, command);
        }

        public void Update()
        {
            var data = new string[]
            {
                JsonUtility.ToJson(Joysticks[0].Position),
                JsonUtility.ToJson(Joysticks[1].Position),
            };

            SendCommand(_channel,
                new(JsonUtility.ToJson(new ArrayWrapper<string>(data))));
        }
    }
}