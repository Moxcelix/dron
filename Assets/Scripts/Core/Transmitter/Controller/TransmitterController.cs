namespace Core.Transmitter
{
    public class TransmitterController
    {
        private readonly IControls _controls;
        private readonly Transmitter _transmitter;

        public TransmitterController(IControls controls, Transmitter transmitter)
        {
            _controls = controls;
            _transmitter = transmitter;
        }

        public void Update()
        {
            _transmitter.Joysticks[0].Position = _controls.LeftAxes;
            _transmitter.Joysticks[1].Position = _controls.RightAxes;
        }
    }
}