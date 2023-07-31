using UnityEngine;

namespace Core.Dron
{
    [System.Serializable]
    public class DronFabric
    {
        [SerializeField] private DronBody _dronBodyPrefab;

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

        public DronBody CreateDron(float power, Vector3 position)
        {
            var dronBody = Object.Instantiate(_dronBodyPrefab, position, Quaternion.identity);
            var dron = CreateDron(power);

            ApplyDronBody(dron, dronBody);

            return dronBody;
        }

        public void ApplyDronBody(Dron dron, DronBody body)
        {
            body.Apply(dron);
        }
    }
}