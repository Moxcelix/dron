using UnityEngine;

namespace Core.Dron
{
    public class Propeller
    {
        private readonly float _power;
        private readonly Vector3 _liftForce;
        private readonly Vector3 _sideForce;

        public float RPM { get; set; }
        public float Range { get; set; }
        public Vector3 Force { get; private set; }

        public Propeller(float power, Vector3 liftPower, Vector3 sidePower)
        {
            _power = power;
            _liftForce = liftPower;
            _sideForce = sidePower;
        }

        public void Update()
        {
            Force = RPM * _power * 
                Vector3.Lerp(_liftForce, _sideForce, Range);
        }
    }
}