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
           // if(_controls.LeftAxes
        }
    }
}