using UnityEngine;

namespace Core.Drone
{
    public class Propeller
    {
        private readonly float _maxPower;
        private readonly Vector3 _liftForce;
        private readonly Vector3 _sideForce;

        public float PowerRange { get; set; }
        public float TurnRange { get; set; }
        public Vector3 Force { get; private set; }

        public Propeller(float power, Vector3 liftPower, Vector3 sidePower)
        {
            _maxPower = power;
            _liftForce = liftPower.normalized;
            _sideForce = sidePower.normalized;
        }

        public void Update()
        {
            var range = Mathf.Clamp(TurnRange, -1.0f, 1.0f);
            var liftForce = _liftForce * Mathf.Sin(Mathf.Acos(range));
            var sideForce = _sideForce * range;

            Force = PowerRange * _maxPower * (liftForce + sideForce);
        }
    }
}