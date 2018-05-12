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
                foreach(Specimen s in Env.Specimens)
                {
                    if (s.IsIn(Rover, Rover.Size/2)) //if the specimen is inside the range of the rover
                    {
                        if(IsSuccessfulUse())
                        {
                            Rover.Extracted.Add(s);
                            base.Use();
                            return;
                        }

                    }
                }
            }
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
