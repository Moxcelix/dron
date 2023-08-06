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
            if (Value < 1)
            {
                Value += _pressSpeed * deltaTime;
            }
            else if (Value > 1 + _releaseSpeed * deltaTime * 2.0f)
            {
                Value -= _releaseSpeed * deltaTime;
            }
        }

        public void Release(float deltaTime)
        {
            if (Value > 0)
            {
                Value -= _releaseSpeed * deltaTime;
            }
            else
            {
                Value = 0;
            }
        }
    }
}