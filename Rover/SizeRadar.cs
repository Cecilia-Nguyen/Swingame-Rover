using System;
namespace Rover
{
    public class SizeRadar : Radar
    {
        public SizeRadar(string name, Environment env) : base(name, env)
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
                        Console.WriteLine(s.Size);
                    }
                }
                base.Use();
            }
		}
	}
}
