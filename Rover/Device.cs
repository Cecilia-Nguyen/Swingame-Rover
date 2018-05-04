using System;
namespace Rover
{
    public abstract class Device
    {
        private bool _attached;
        private string _name;
        private double _usesCharge;
        private Battery _battery;

        public Device(bool attached, string name, double usesCharge, Battery battery)
        {
            _attached = attached;
            _name = name;
            _usesCharge = usesCharge;
            _battery = battery;
        }

        public abstract void Use();

        public virtual void Update()
        {
            if (_battery != null)
            {
                _battery.InUse = true;
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
    }
}
