using UnityEngine;

namespace Core.Drone
{
    public class DroneBody : MonoBehaviour
    {
        public Drone Drone { get; private set; }

        [SerializeField] private PropellerBody[] _propellers;

        public void Apply(Drone drone)
        {
            Drone = drone;

            for(int i = 0; i < _propellers.Length; i++)
            {
                _propellers[i].Apply(Drone.Propellers[i]);
            }
        }

        private void Update()
        {
            Drone.Update();
        }
    }
}