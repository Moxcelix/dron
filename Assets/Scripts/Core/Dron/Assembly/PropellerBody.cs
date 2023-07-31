using UnityEngine;

namespace Core.Dron
{
    public class PropellerBody : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f;
        [SerializeField] private Transform _blades;

        private Propeller _propeller;

        public void Apply(Propeller propeller)
        {
            _propeller = propeller;
        }

        private void FixedUpdate()
        {
            var velocity = Time.fixedDeltaTime * _propeller.Force.magnitude * _speed;

            transform.localEulerAngles += Vector3.up * velocity;
        }
    }
}