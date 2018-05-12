using System;
namespace Rover
{
    public class Battery
    {

        private bool _inUse;
        private string _name;
        private int _charge;

        public Battery(string name)
        {
            _name = name;
            _charge = 10;
            _inUse = false;
        }

        public void Discharge(int amount)
        {
            _charge -= amount;
            if (_charge <= 0 )
            {
                _charge = 0;
            }

            if(_charge >= 10)
			{
				_charge = 10;
			}
		}

        public string Name
        {
            get { return _name; }
        }

        public int Charge
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
