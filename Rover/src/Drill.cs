using System;
namespace Rover
{
    public class Drill : Device
    {
        
        private double _wear;
        private const int USES_CHARGE = 0;

		public Drill(string name, Rover rover) : base(name, USES_CHARGE, rover)
        {
            _wear = 1; //Wear counting down from 1 to 0;
        }

        public override void Use()
        {         
            if (Attached)
            {
				Console.WriteLine (Name + " used: ");
				int count = 0;
                foreach(Specimen s in Env.Specimens)
				{
					if (s.IsIn(Rover, Rover.Size/2) && s.IsActive) //if the specimen is inside the range of the rover
                    {
						count++;
						if (IsSuccessfulUse ()) {
							Rover.Extracted.Add (s);
							Console.WriteLine ("\t" + s.Name + " extracted");
							s.IsActive = false;
							return;
						} else 
						{
							Console.WriteLine ("\tUnsuccessful use");
						}
					}
                }
				if (count == 0){ Console.WriteLine ("\t No specimen to drill"); }
            }
			base.Use ();
        }

		public override void Update()
		{
            base.Update();
            if (_wear < 0)
            {
                _wear = 0;
            }
		}

		public bool IsSuccessfulUse()
        {
            Random rnd = new Random();
			if ( Usable || rnd.NextDouble() < .8)
            {
				_wear -= .05;
                return true;
            }
            return false;

        }

        public bool Usable
        {
            get 
            { 
                return (_wear >= 0); 
            }
        }

        public double Wear
        {
            get { return _wear; }
        }
    }
}
