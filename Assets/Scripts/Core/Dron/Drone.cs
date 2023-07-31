namespace Core.Drone
{
    public class Drone
    {
        public Propeller[] Propellers { get; }

        public Drone(Propeller[] propellers)
        {
            Propellers = propellers;
        }

        public void Power(float range)
        {
            foreach(var propeller in Propellers)
            {
                propeller.PowerRange = range;
            }
        }

        public void Turn(float range)
        {
            foreach (var propeller in Propellers)
            {
                propeller.TurnRange = range;
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
