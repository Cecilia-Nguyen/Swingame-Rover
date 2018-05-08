using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace Rover
{
    public class Rover : GameObject
    {

        private List<Device> _devices;
        private List<Specimen> _extracted;
        private List<Battery> _batteries;
        private bool _selected;
        private Environment _environment;

        public Rover(int x, int y, int size, string name, Environment env) : base (x, y, size, name)
        {
            _environment = env;
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
            foreach(Device d in _devices)
            {
                d.Update();
            }
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
                device.Rover = this;
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

        public Environment Env
        {
            get { return _environment; }
        }
    }
}
