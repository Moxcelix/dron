using UnityEngine;

namespace Core.Transmitter
{
    public interface IControls
    {
        public bool IsActive { get; }

        public Vector2 LeftAxes { get; }
        public Vector2 RightAxes { get; }
    }
}
