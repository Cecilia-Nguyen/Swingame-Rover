using System;
namespace Rover
{
    public class Solar : Device
    {

        private const int USES_CHARGE = -1;
       
        public Solar(string name, Rover rover) : base (name, USES_CHARGE, rover)
        {
        }


    }
}
