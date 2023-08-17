using UnityEngine;

namespace Core.Drone
{
    public class HeightCeiling : MonoBehaviour
    {
        private readonly float _maxHeight;

        public HeightCeiling(float maxHeight)
        {
            _maxHeight = maxHeight;
        }

        public float GetMultiplier(float currentHeight)
        {
            return Mathf.Clamp01(currentHeight / _maxHeight);
        }
    }
}