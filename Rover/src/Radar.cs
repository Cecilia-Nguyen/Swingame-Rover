using System;
namespace Rover
{
    public abstract class Radar : Device
    {
        private const int USES_CHARGE = 4;
        protected const int RADAR_RANGE = 5;


        public Radar(string name, Environment env, Rover rover) : base (name, USES_CHARGE, rover)
        {
        }

		public override void Use()
		{
            base.Use();

		}
	}
}
