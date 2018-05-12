using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace Rover
{
    public class Environment
    {

        private List<Rover> _rovers;
        private List<Specimen> _specimens;
        private int _width, _height;
		private Rover _selectedRover;
		private Device _selectedDevice;

		private int _offset; 

        public Environment(int height, int width, int rovers, int specimens)
        {
            _width = width;
            _height = height;
			_offset = _width / 40;
			AddSpecimens (specimens);
			AddRovers(rovers);
        }

        public void Update()
        {
            foreach(Rover r in Rovers)
            {
				r.Update ();
            }

			_selectedRover.Selected = true;

			Draw ();
        }

        public void Draw()
		{
			foreach(Rover r in Rovers)
			{
				r.Draw ();
			}
			foreach(Specimen s in Specimens)
			{
				s.Draw ();
			}

			DrawSideBar ();
		}

        public void DrawSideBar()
		{
			SwinGame.DrawText (SelectedRover.Name, Color.Black, "Arial.ttf", 40, 25 + Width, 50);
			SwinGame.DrawText ("Devices", Color.Black, "Arial.ttf", 35, 25 + Width, 100);
            
			int i = 0;
			foreach (Device d in _selectedRover.Devices)
			{
				i++;

				if (d.Attached && d.Selected) 
				{
					SwinGame.DrawText (String.Format ("({0}): {1} ({2})", i, d.Name, d.Battery.Name), Color.Blue, "Arial.ttf", 20, 25 + Width, 125 + i * 25);
				} else if (d.Attached)
				{
					SwinGame.DrawText (String.Format ("({0}): {1} ({2})", i, d.Name, d.Battery.Name), Color.Green, "Arial.ttf", 20, 25 + Width, 125 + i * 25);
				}
				else if (!d.Attached & d.Selected)
				{
					SwinGame.DrawText (String.Format ("({0}): {1}", i, d.Name), Color.Blue, "Arial.ttf", 20, 25 + Width, 125 + i * 25);
				} else
				{
					SwinGame.DrawText (String.Format ("({0}): {1}", i, d.Name), Color.Red, "Arial.ttf", 20, 25 + Width, 125 + i * 25);
				}
			}

			SwinGame.DrawText ("Batteries", Color.Black, "Arial.ttf", 35, 25 + Width, 400);

			i = 0;
			foreach (Battery b in _selectedRover.Batteries) 
			{
				i++;

				SwinGame.DrawText (b.Name, Color.Black, "Arial.ttf", 10,25 +Width + i * 50, 550);
				SwinGame.DrawRectangle (Color.Black, 25 + Width + i *50, 449, 25, 101);
				SwinGame.FillRectangle (Color.Green, 25 + Width + i * 50 + 1, 450 + (100-b.Charge*10), 23, b.Charge * 10 -1);
			}

		}

        //TODO - Make the parameter matter 
        public void AddRovers(int amount)
        {
			if (amount < 1) { amount = 1; }

            _rovers = new List<Rover>();

			Rover rover1 = new Rover (1, 1, 30, "Rover 1", this);
			Rover rover2 = new Rover (18, 18, 30, "Rover 2", this);

			_rovers.Add (rover1);
			_rovers.Add (rover2);

            foreach( Rover r in _rovers)
			{
				Console.WriteLine (r.Name + " Created");
				foreach (Battery b in r.Batteries)
				{
					Console.WriteLine (r.Name + ": " + b.Name + " Created");
				}
				foreach (Device d in r.Devices)
				{
					Console.WriteLine (r.Name + ": " + d.Name + " Created");
				}
				Console.WriteLine ("");
			}

			_selectedRover = _rovers[0];
			Console.WriteLine (_selectedRover.Name + " Selected");
        }

        public void AddSpecimens(int amount)
        {
			Random rnd = new Random();
			if (amount < 1) { amount = 1; }

            _specimens = new List<Specimen>();

            for (int i = 0; i < amount; i++)
            {
				_specimens.Add (new Specimen ("Scientist " + i, rnd.Next (19), rnd.Next (19), rnd.Next (30), "Specimen " + i, this));
				Console.WriteLine (_specimens [i].Scientist + ": " + _specimens [i].Name + " Created");
            }
			Console.WriteLine ("");
        }

        public void SelectNextRover()
		{
			int index = _rovers.IndexOf (_selectedRover);
			index += 1;
			if (index > _rovers.Count-1)
			{
				index = 0;
			}

			_selectedRover = _rovers [index];
			Console.WriteLine ("\n"+ _selectedRover.Name + " Selected");
		}

		public void SelectDevice(Device device)
		{
			foreach(Device d in device.Rover.Devices)
			{
				d.Selected = false;
			}
			device.Selected = true;
			_selectedDevice = device;
			Console.WriteLine (device.Name + " Selected");

		}

        public List<Rover> Rovers
        {
            get { return _rovers; }

        }

        public List<Specimen> Specimens
        {
            get { return _specimens; }

        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public int Offset 
		{
			get { return _offset; }
		}

		public Rover SelectedRover 
		{
			get { return _selectedRover; }
		}

		public Device SelectedDevice {
			get { return _selectedDevice; }
        }
    }
}
