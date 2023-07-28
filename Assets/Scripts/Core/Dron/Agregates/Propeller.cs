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
            _liftForce = liftPower.normalized;
            _sideForce = sidePower.normalized;
        }

        public void Update()
        {
            var range = Mathf.Clamp(Range, -1.0f, 1.0f);
            var liftForce = _liftForce * Mathf.Sin(Mathf.Acos(range));
            var sideForce = _sideForce * range;

            Force = RPM * _power * (liftForce + sideForce);
        }
    }
}