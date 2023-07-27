namespace Core.Dron
{
    public class Dron
    {
        private Propeller[] _propellers;

        public void Update()
        {
            foreach (var propeller in _propellers) 
            {
                propeller.Update(); 
            }
        }
    }
}
