using UnityEngine;

namespace Core.Dron
{
    public class DronBody : MonoBehaviour
    {
        private Dron _dron;

        public void Initialize(Dron dron)
        {
            _dron = dron;
        }
    }
}