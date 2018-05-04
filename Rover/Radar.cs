using System;
namespace Rover
{
    public abstract class Radar : Device
    {
        private const double USES_CHARGE = .4;

        public Radar(string name) : base (false, name, USES_CHARGE, null)
        {
            
        }
    }
}
