using System.Collections.Generic;
using UnityEngine;
using Core.Utilities;

namespace Core.Transmitter
{
    public class TransmitterController
    {
        private readonly IControls _controls;
        private readonly Transmitter _transmitter;
        private readonly int _channel;

        public TransmitterController(IControls controls, Transmitter transmitter, int channel)
        {
            _controls = controls;
            _transmitter = transmitter;
            _channel = channel;
        }

        public void Update()
        {
            var data = new string[]
            {
                JsonUtility.ToJson(_controls.LeftAxes),
                JsonUtility.ToJson(_controls.RightAxes),
                JsonUtility.ToJson(_controls.IsActive)
            };

            _transmitter.SendCommand(_channel,
                new(JsonUtility.ToJson(new ArrayWrapper<string>(data))));
        }
    }
}