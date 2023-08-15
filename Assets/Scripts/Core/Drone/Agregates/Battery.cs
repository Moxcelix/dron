namespace Core.Drone
{
    public class Battery
    {
        private readonly float _maxBatteryLevel;
        private readonly float _batterySpeed;

        private float _batteryLevel;

        public float BatteryLevel => _batteryLevel < 0 ? 0 : _batteryLevel;

        public Battery (float maxBatteryLevel, float batterySpeed)
        {
            _maxBatteryLevel = maxBatteryLevel;
            _batterySpeed = batterySpeed;
        }

        public bool GetPower(float load)
        {
            _batteryLevel -= load * _batterySpeed;

            return _batteryLevel > 0;
        }
    }
}