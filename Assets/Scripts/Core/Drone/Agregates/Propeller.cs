using UnityEngine;

namespace Core.Drone
{
    public class Propeller
    {
        private readonly float _maxPower;
        private readonly float _maxAngle;
        private readonly Vector3 _liftForce;
        private readonly Vector3 _sideForce;

        public float PowerRange { get; set; }
        public float TurnRange { get; set; }
        public float TiltRange { get; set; }

        public Vector3 Force { get; private set; }

        public Propeller(
            float power,
            Vector3 liftPower,
            Vector3 sidePower,
            float maxAngle)
        {
            _maxPower = power;
            _liftForce = liftPower.normalized;
            _sideForce = sidePower.normalized;
            _maxAngle = maxAngle;
        }

        public void Update()
        {
            var maxRange = Mathf.Sin(_maxAngle);
            var range = Mathf.Clamp(TurnRange, -1.0f, 1.0f) * maxRange;
            var liftForce = Mathf.Abs(Mathf.Sin(Mathf.Acos(range))) * _liftForce;
            var sideForce = _sideForce * range;

            Debug.Log(liftForce);

            Force = (1.0f - TiltRange) * PowerRange * _maxPower * (liftForce + sideForce);
        }
    }
}