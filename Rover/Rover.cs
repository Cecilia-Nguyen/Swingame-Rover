using System;
using System.Collections.Generic;

namespace Rover
{
    public class Rover : GameObject
    {

        private List<Device> _devices;
        private List<Specimen> _extracted;
        private List<Battery> _batteries;
        private bool _selected;

        public Rover(int x, int y, int size, string name) : base (x, y, size, name)
        {
            _devices = new List<Device>();
            _extracted = new List<Specimen>();
            _batteries = new List<Battery>();
            _batteries.Add(new Battery("Battery 1"));
            _batteries.Add(new Battery("Battery 2"));

            _selected = false;
        }

        public void Draw()
        {

        }

        public void Update()
        {
            
        }

        public void Use(Device device)
        {
            device.Use();
        }

        public void Attach(Device device)
        {
            //Check which battery has highest charge
            Battery batteryToAttach = CalculateHighestCharge();
            //Check if battery is in use
            if(!batteryToAttach.InUse)
            {
                //Set device Attached = true
                //Set battery=*Battery*
                device.Attached = true;
                device.Battery = batteryToAttach;
            }

        }

        public void Remove(Device device)
        {
            device.Attached = false;
            device.Battery.InUse = false;
        }

        public Battery CalculateHighestCharge()
        {

            int index = 0;
            double max = 0;

            for (int i = 0; i < _batteries.Count; i++)
            {
                if (_batteries[i].Charge > max)
                {
                    max = _batteries[i].Charge;
                    index = i;
                }
            }

            return _batteries[index];
        }

        public List<Device> Devices
        {
            get { return _devices; }
        }

        public List<Specimen> Extracted
        {
            get { return _extracted; }
        }

        public List<Battery> Batteries
        {
            get { return _batteries; }
        }

        public bool Selected
        {
            get { return _selected; }
        }
    }
}
