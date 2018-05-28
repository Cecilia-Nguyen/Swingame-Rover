using System;
namespace Rover
{
    public abstract class Device
    {
        private bool _attached;
        private string _name;
        private int _usesCharge;
        private Battery _battery;
        private Rover _rover;
		private bool _selected;

		public Device(string name, int usesCharge, Rover rover)
        {
			_rover = rover;
            _attached = false;
            _name = name;
            _usesCharge = usesCharge;
            _battery = null;
			_selected = false;
        }

        public virtual void Use()
        {
            if (Attached)
            {
				if (_battery != null && Battery.Charge > 0)
                {
                    Console.WriteLine (this.Name + ": Successful Use");
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

        public int UsesCharge
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
			get { return Rover.Env; }
        }

        public bool Selected
		{
			get { return _selected; }
			set { _selected = value; }
		}
    }
}
