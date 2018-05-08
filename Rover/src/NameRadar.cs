using System;
namespace Rover
{
    public class NameRadar : Radar
    {
        public NameRadar(string name, Environment env) : base (name, env)
        {
        }

		public override void Use()
		{
            if (Attached)
            {
                foreach (Specimen s in Env.Specimens)
                {
                    if (s.IsIn(Rover, RADAR_RANGE))
                    {
                        Console.WriteLine(s.Name); //TODO Make Display to screen
                    }
                }
                base.Use();
            }
		}
	}
}
