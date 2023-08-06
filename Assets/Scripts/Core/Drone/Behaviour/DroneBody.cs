using UnityEngine;

namespace Core.Drone
{
    [RequireComponent(typeof(Rigidbody))]
    public class DroneBody : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private PropellerBody[] _propellers;

        private Rigidbody _rigidbody;

        public Drone Drone { get; private set; }

        public Camera Camera => _camera;

        public void Apply(Drone drone)
        {
            Drone = drone;

            for(int i = 0; i < _propellers.Length; i++)
            {
                _propellers[i].Apply(Drone.Propellers[i]);
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Drone.Update();
        }

        private void FixedUpdate()
        {
            ApplyPropellersForce(Time.fixedDeltaTime);
            ApplyGravityForce(Time.fixedDeltaTime);
        }

        private void ApplyPropellersForce(float deltaTime)
        {
            for (int i = 0; i < _propellers.Length; i++)
            {
                _rigidbody.AddForceAtPosition(
                    _propellers[i].Propeller.Force * deltaTime,
                    _propellers[i].gameObject.transform.localPosition);
            }
        }

        private void ApplyGravityForce(float deltaTime)
        {
            for (int i = 0; i < _propellers.Length; i++)
            {
                _rigidbody.AddForceAtPosition(
                    _rigidbody.mass * deltaTime * Physics.gravity,
                    _propellers[i].gameObject.transform.localPosition);
            }
        }
    }
}