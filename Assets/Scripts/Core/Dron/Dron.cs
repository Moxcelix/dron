namespace Core.Dron
{
    public class Dron
    {
        public Propeller[] Propellers { get; }

        public Dron(Propeller[] propellers)
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
