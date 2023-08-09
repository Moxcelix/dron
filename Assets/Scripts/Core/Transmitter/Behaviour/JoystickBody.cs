using UnityEngine;

namespace Core.Transmitter
{
    public class JoystickBody : MonoBehaviour
    {
        [SerializeField] private float _maxAngle = Mathf.PI / 6.0f;
        [SerializeField] private Transform _body;

        public void UpdatePosition(Vector2 axes)
        {
            _body.localEulerAngles = new (axes.y * _maxAngle, axes.x * _maxAngle);
        }
    }
}