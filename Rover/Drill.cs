using System;
namespace Rover
{
    public class Drill : Device
    {

        private bool _usable;
        private double _wear;
        private const double USES_CHARGE = 0;

        public Drill(string name) : base(name, USES_CHARGE)
        {
        }

        public override void Use()
        {
            
        }

        public double CalcWear()
        {
            return 1;
        }

        public bool Usable
        {
            get { return _usable; }
        }

        public double Wear
        {
            get { return _wear; }
        }
    }
}
