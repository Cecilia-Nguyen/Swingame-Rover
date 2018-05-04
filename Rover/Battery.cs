using System;
namespace Rover
{
    public class Battery
    {

        private bool _inUse;
        private string _name;
        private double _charge;

        public Battery(string name)
        {
            _name = name;
            _charge = 1;
            _inUse = false;
        }

        public void Discharge(double amount)
        {
            _charge += amount;
            if (_charge <= 0 )
            {
                _charge = 0;
            }
        }

        public string Name
        {
            get { return _name; }
        }

        public double Charge
        {
            get { return _charge; }
            set { _charge = value; }
        }

        public bool InUse
        {
            get { return _inUse; }
            set { _inUse = value; }
        }
    }
}
