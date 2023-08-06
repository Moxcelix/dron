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

        public void Press()
        {
            if (Value < 1)
            {
                Value += _pressSpeed * Time.deltaTime;
            }
            else if (Value > 1 + _releaseSpeed * Time.deltaTime * 2.0f)
            {
                Value -= _releaseSpeed * Time.deltaTime;
            }
        }

        public void Release()
        {
            if (Value > 0)
            {
                Value -= _releaseSpeed * Time.deltaTime;
            }
            else
            {
                Value = 0;
            }
        }
    }
}