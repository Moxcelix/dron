using UnityEngine;

namespace Core.Drone
{
    public class DroneFabric
    {
        public Drone CreateDron(float power)
        {
            var turnForce = 0.1f;
            var maxAngle = Mathf.PI / 6.0f;
            var propellers = new Propeller[]
            {
                new (power, Vector3.up, new (-turnForce, 0.0f, turnForce),maxAngle),
                new (power, Vector3.up, new (-turnForce, 0.0f, -turnForce), maxAngle),
                new (power, Vector3.up, new (turnForce, 0.0f, -turnForce), maxAngle),
                new (power, Vector3.up, new (turnForce, 0.0f, turnForce), maxAngle),
            };
            var drone = new Drone(propellers);

            return drone;
        }
    }
}