using System;
namespace Rover
{
    public class Motor : Device
    {
        
        private const int USES_CHARGE = 1;
        private EDirection _dir; 

		public Motor(string name, EDirection direction, Rover rover) : base(name, USES_CHARGE, rover)
        {
            _dir = direction;
        }

        public override void Use()
        {
            if (Attached)
            {
                switch (_dir)
                {
                    case (EDirection.Up): Rover.Y -= 1; break;
                    case (EDirection.Down): Rover.Y += 1; break;
                    case (EDirection.Left): Rover.X -= 1; break;
                    case (EDirection.Right): Rover.X += 1; break;
                    default: break;
                }
                base.Use();
            }
        }

	}
}
