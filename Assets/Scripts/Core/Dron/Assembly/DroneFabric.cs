using UnityEngine;

namespace Core.Drone
{
    public class DroneFabric
    {
        public Drone CreateDron(float power)
        {
            var propellers = new Propeller[]
            {
                new Propeller(power, Vector3.up, new Vector3(-1.0f, 0.0f, 1.0f)),
                new Propeller(power, Vector3.up, new Vector3(-1.0f, 0.0f, -1.0f)),
                new Propeller(power, Vector3.up, new Vector3(1.0f, 0.0f, -1.0f)),
                new Propeller(power, Vector3.up, new Vector3(1.0f, 0.0f, 1.0f)),
            };
            var drone = new Drone(propellers);

            return drone;
        }
    }
}