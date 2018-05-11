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

        public Rover(int x, int y, int size, string name, Environment env) : base (x, y, size, name, env)
        {
            _devices = new List<Device>();
            _extracted = new List<Specimen>();
            _batteries = new List<Battery>();
            _batteries.Add(new Battery("Battery 1"));
            _batteries.Add(new Battery("Battery 2"));

			Drill drill = new Drill ("Drill", this);
			Motor downMotor = new Motor ("Downward Motor", EDirection.Down, this);
			Motor upMotor = new Motor ("Upward Motor", EDirection.Up, this);
			Motor leftMotor = new Motor ("Leftward Motor", EDirection.Left, this);
			Motor rightMotor = new Motor ("Rightward Motor", EDirection.Right, this);
			LocationRadar locationRadar = new LocationRadar ("Location Radar", env, this);
			SizeRadar sizeRadar = new SizeRadar ("Size Radar", env, this);
			NameRadar nameRader = new NameRadar ("Name Radar", env, this);
			Solar solar = new Solar ("Solar Panel", this);

			_devices.Add (drill);
			_devices.Add (downMotor);
			_devices.Add (upMotor);
			_devices.Add (leftMotor);
			_devices.Add (rightMotor);
			_devices.Add (locationRadar);
			_devices.Add (sizeRadar);
			_devices.Add (nameRader);
			_devices.Add (solar);


            _selected = false;
            
        }

        public override void Draw()
        {
			SwinGame.FillRectangle (Color.Red, DrawX-Size/2, DrawY-Size/2, Size, Size);

			if(Selected)
			{
				SwinGame.DrawRectangle (Color.Black, DrawX - (Size / 2 + 1), DrawY - (Size / 2 + 1), Size + 2, Size + 2);
			}
        }

        public void Update()
        {
            foreach(Device d in _devices)
            {
                d.Update();
            }
			_selected = false;
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
			set { _selected = value; }
        }
    }
}
