namespace Core.Dron
{
    public class Propeller
    {
        public readonly float _power;

        public float RPM { get; set; }
        public float Force { get; private set; }

        public Propeller(float power)
        {
            _power = power;
        }

        public void Update()
        {
            Force = RPM * _power;
        }
    }
}