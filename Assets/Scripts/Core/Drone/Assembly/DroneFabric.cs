using UnityEngine;

namespace Core.Drone
{
    public class DroneFabric
    {
        public Drone CreateDrone(float power)
        {
            var turnForce = 0.001f;
            var maxAngle = Mathf.PI / 12.0f;
            var maxTilt = 0.05f;
            var battery = new Battery(1, 1);
            var propellers = new Propeller[]
            {
                new (power, Vector3.up, new (-turnForce, 0.0f, turnForce),maxAngle, maxTilt),
                new (power, Vector3.up, new (-turnForce, 0.0f, -turnForce), maxAngle, maxTilt),
                new (power, Vector3.up, new (turnForce, 0.0f, -turnForce), maxAngle, maxTilt),
                new (power, Vector3.up, new (turnForce, 0.0f, turnForce), maxAngle, maxTilt),
            };
            var drone = new Drone(propellers, battery);

            return drone;
        }
    }
}