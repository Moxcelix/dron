namespace Core.Dron
{
    public class Dron
    {
        private readonly Propeller[] _propellers;

        public Dron(Propeller[] propellers)
        {
            _propellers = propellers;
        }

        public void Power(float range)
        {
            foreach(var propeller in _propellers)
            {
                propeller.PowerRange = range;
            }
        }

        public void Turn(float range)
        {
            foreach (var propeller in _propellers)
            {
                propeller.TurnRange = range;
            }
        }

        public void Update()
        {
            foreach (var propeller in _propellers) 
            {
                propeller.Update(); 
            }
        }
    }
}
