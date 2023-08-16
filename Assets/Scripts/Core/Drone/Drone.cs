using UnityEngine;

namespace Core.Drone
{
    public class Drone
    {
        public Propeller[] Propellers { get; }
        public Battery Battery { get; }

        public Drone(Propeller[] propellers, Battery battery)
        {
            Propellers = propellers;
            Battery = battery;
        }

        public void Power(float powerRange, float turnRange)
        {
            foreach (var propeller in Propellers)
            {
                propeller.PowerRange = Mathf.Clamp01(powerRange + Mathf.Abs(turnRange));
                propeller.TurnRange = turnRange;
            }
        }

        public void Tilt(Vector2 tiltRange)
        {
            for (var i = 0; i < Propellers.Length; i++)
            {
                var angle = i * Mathf.PI * 2.0f / (float)(Propellers.Length);
                Propellers[i].TiltRange = 
                    tiltRange.x * Mathf.Cos(angle) +
                    tiltRange.y * Mathf.Sin(angle);
            }
        }

        public void Update()
        {
            foreach (var propeller in Propellers)
            {
                propeller.Update();
            }
        }
    }
}
