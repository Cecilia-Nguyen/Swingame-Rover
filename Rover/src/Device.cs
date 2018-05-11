using System;
namespace Rover
{
    public abstract class Device
    {
        private bool _attached;
        private string _name;
        private double _usesCharge;
        private Battery _battery;
        private Rover _rover;
        private Environment _environment;

		public Device(string name, double usesCharge, Rover rover)
        {
			_rover = rover;
            _attached = false;
            _name = name;
            _usesCharge = usesCharge;
            _battery = null;
            _environment = _rover.Env;
        }

        public virtual void Use()
        {
            if (Attached)
            {
                if (_battery != null)
                {
                    _battery.Discharge(UsesCharge);
                }
            }
        }

        public virtual void Update()
        {
            if (_battery != null)
            {
                _battery.InUse = true;
            }

            if (_battery == null || _battery.Charge <= 0)
            {
                _battery = null;
                Attached = false;
            }

        }

        public  bool Attached
        {
            get { return _attached; }
            set { _attached = value; }
        }

        public  string Name
        {
            get { return _name; }
        }

        public double UsesCharge
        {
            get { return _usesCharge; }
        }

        public Battery Battery
        {
            get { return _battery; }
            set { _battery = value; }
        }

        public Rover Rover
        {
            get { return _rover; }
            set { _rover = value; }
        }

        public Environment Env
        {
            get { return _environment; }
        }
    }
}
