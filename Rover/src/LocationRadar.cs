using System;
namespace Rover
{
    public class LocationRadar : Radar
    {
		public LocationRadar(string name, Environment env, Rover rover) : base(name, env, rover)
        {
        }

        public override void Use()
        {
            if (Attached)
            {
				Console.WriteLine (Name + " used.");
                foreach (Specimen s in Env.Specimens)
                {
                    if (s.IsIn(Rover, RADAR_RANGE))
                    {
						s.IsVisable = true;
                    }
                }
                base.Use();
            }
        }
    }
}
