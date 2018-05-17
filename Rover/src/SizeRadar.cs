using System;
namespace Rover
{
    public class SizeRadar : Radar
    {
        public SizeRadar(string name, Environment env, Rover rover) : base(name, env, rover)
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
						Console.WriteLine("\tSpecimen Size: " + s.Size);
                    }
                }
                base.Use();
            }
		}
	}
}
