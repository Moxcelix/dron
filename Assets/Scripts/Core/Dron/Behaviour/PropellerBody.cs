using UnityEngine;

namespace Core.Drone
{
    public class PropellerBody : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private Transform _blades;

        public Propeller Propeller { get; private set; }

        public void Apply(Propeller propeller)
        {
            Propeller = propeller;
        }

        private void FixedUpdate()
        {
            if(Propeller == null)
            {
                return;
            }

            var velocity = Time.fixedDeltaTime * Propeller.Force.magnitude * _speed;

            _blades.localEulerAngles += Vector3.forward * velocity;
        }
    }
}