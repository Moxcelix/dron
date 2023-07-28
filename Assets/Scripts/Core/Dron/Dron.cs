namespace Core.Dron
{
    public class Dron
    {
        private readonly Propeller[] _propellers;

        public Dron(Propeller[] propellers)
        {
            _propellers = propellers;
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
