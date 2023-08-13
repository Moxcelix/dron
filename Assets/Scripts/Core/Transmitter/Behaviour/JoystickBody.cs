using UnityEngine;

namespace Core.Transmitter
{
    public class JoystickBody : MonoBehaviour
    {
        [SerializeField] private float _maxAngle = Mathf.PI / 6.0f;
        [SerializeField] private Transform _body;

        private Joystick _joystick;

        private void Update()
        {
            _body.localEulerAngles = new(
                _joystick.Position.y * _maxAngle,
                _joystick.Position.x * _maxAngle);
        }

        public void Apply(Joystick joystick)
        {
            _joystick = joystick;
        }
    }
}