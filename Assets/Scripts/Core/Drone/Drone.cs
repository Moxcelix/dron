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
                propeller.PowerRange = Mathf.Clamp(powerRange + Mathf.Abs(turnRange), -1.0f, 1.0f);
                propeller.TurnRange = turnRange;
            }
        }

        public void Tilt(Vector2 tiltRange)
        {
            tiltRange.Normalize();
            tiltRange = -tiltRange;

            for (var i = 0; i < Propellers.Length; i++)
            {
                var angle = (i + 0.5f) * Mathf.PI * 2.0f / (float)(Propellers.Length);
                var propellerX = Mathf.Cos(angle);
                var propellerY = Mathf.Sin(angle);

                Propellers[i].TiltRange = 1.0f - Vector2.Distance(new(propellerX, propellerY), tiltRange);
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
