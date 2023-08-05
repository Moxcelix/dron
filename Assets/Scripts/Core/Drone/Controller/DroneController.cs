namespace Core.Drone
{
    public class DroneController
    {
        private readonly IControls _controls;
        private readonly Drone _drone;

        public DroneController(IControls controls, Drone drone)
        {
            _controls = controls;
            _drone = drone;
        }
    }
}