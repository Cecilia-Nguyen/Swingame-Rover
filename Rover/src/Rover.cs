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
			if (device.Attached) 
			{
				Console.WriteLine (device.Name + " already attached");
				return; 
			}
            //Check which battery has highest charge
			Battery batteryToAttach = DetermineBattery(device);
            //Check if battery is in use
            
			if (batteryToAttach != null) {
				device.Attached = true;
				device.Rover = this;
				device.Battery = batteryToAttach;
				batteryToAttach.InUse = true;
				Console.WriteLine (device.Name + " Attached");
			}else 
			{
				Console.WriteLine ("All available batteries in use - Remove a device to free a battery"); 
			}



		}

		public void Remove(Device device)
        {
            device.Attached = false;
			if(device.Battery != null)
			{
				device.Battery.InUse = false;
                device.Battery = null;
			}


        }

        public Battery DetermineBattery(Device device)
        {
			if(Batteries[0].InUse)
			{
				foreach(Battery b in Batteries)
				{
					if(!b.InUse)
					{
						return b;
					}
				}
				return null;
			}
			return Batteries [0];

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
