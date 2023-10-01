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
        }

        private void ApplyPropellersForce(float deltaTime)
        {
            for (int i = 0; i < _propellers.Length; i++)
            {
                _rigidbody.AddForceAtPosition(
                    transform.rotation * _propellers[i].Propeller.Force * deltaTime,
                    _propellers[i].gameObject.transform.position, ForceMode.Force);
            }
        }
    }
}