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
    }
}