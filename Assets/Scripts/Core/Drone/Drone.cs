using UnityEngine;

namespace Core.Drone
{
    public class Drone
    {
        public Propeller[] Propellers { get; }

        public Drone(Propeller[] propellers)
        {
            Propellers = propellers;
        }

        public void Power(float powerRange, float turnRange)
        {
            foreach(var propeller in Propellers)
            {
                propeller.PowerRange = Mathf.Clamp01(powerRange + Mathf.Abs(turnRange));
                propeller.TurnRange = turnRange;
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
