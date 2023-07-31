using UnityEngine;

namespace Core.Dron
{
    public class DronBody : MonoBehaviour
    {
        private Dron _dron;

        public void Apply(Dron dron)
        {
            _dron = dron;
        }
    }
}