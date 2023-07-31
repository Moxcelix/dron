using UnityEngine;

namespace Core.Dron
{
    public class DronFabric
    {
        public Dron CreateDron(float power)
        {
            var propellers = new Propeller[]
            {
                new Propeller(power, Vector3.up, new Vector3(-1.0f, 0.0f, 1.0f)),
                new Propeller(power, Vector3.up, new Vector3(-1.0f, 0.0f, -1.0f)),
                new Propeller(power, Vector3.up, new Vector3(1.0f, 0.0f, -1.0f)),
                new Propeller(power, Vector3.up, new Vector3(1.0f, 0.0f, 1.0f)),
            };
            var dron = new Dron(propellers);

            return dron;
        }

        public void ApplyDronBody(Dron dron, DronBody body)
        {
            body.Apply(dron);
        }
    }
}