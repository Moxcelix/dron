using UnityEngine;

namespace Core.Dron
{
    public class DronBody : MonoBehaviour
    {
        public Dron Dron { get; private set; }

        [SerializeField] private PropellerBody[] _propellers;

        public void Apply(Dron dron)
        {
            Dron = dron;

            for(int i = 0; i < _propellers.Length; i++)
            {
                _propellers[i].Apply(Dron.Propellers[i]);
            }
        }

        private void Update()
        {
            Dron.Update();
        }
    }
}