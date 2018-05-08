using System;
namespace Rover
{
    public class LocationRadar : Radar
    {
        public LocationRadar(string name, Environment env) : base(name, env)
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
                        Console.WriteLine(string.Format("X:{0} Y:{1}", s.X, s.Y));
                    }
                }
                base.Use();
            }
        }
    }
}
