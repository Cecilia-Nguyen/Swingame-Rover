using System;
namespace Rover
{
    public class NameRadar : Radar
    {
		public NameRadar(string name, Environment env, Rover rover) : base (name, env, rover)
        {
        }

		public override void Use()
		{
            if (Attached)
            {
				Console.WriteLine (Name + " used: ");
                foreach (Specimen s in Env.Specimens)
                {
                    if (s.IsIn(Rover, RADAR_RANGE))
                    {
						Console.WriteLine("\tSpecimen Name: " + s.Name); //TODO Make Display to screen
                    }
                }
                base.Use();
            }
		}
	}
}
