using UnityEngine;

namespace Core.SmoothInput
{
    public class SmoothPressing
    {
        private readonly float _pressSpeed = 0.1f;
        private readonly float _releaseSpeed = 0.1f;

        public float Value { get; private set; }

        public SmoothPressing(float pressSpeed, float releaseSpeed)
        {
            this._pressSpeed = pressSpeed;
            this._releaseSpeed = releaseSpeed;
        }

        public void Press(float deltaTime)
        {
            Value = Mathf.Lerp(Value, 1, deltaTime * _pressSpeed);
        }

        public void Release(float deltaTime)
        {
            Value = Mathf.Lerp(Value, 0, deltaTime * _releaseSpeed);
        }
    }
}