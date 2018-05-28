using System;
using SwinGameSDK;
namespace Rover
{
	public class Specimen : GameObject
	{

		private string _scientist;
		private bool _isActive;
		private bool _isvisible;

		public Specimen (string scientist, int x, int y, int size, string name, Environment env) : base (x, y, size, name,env)
		{
			_scientist = scientist;
			_isActive = true;
			_isvisible = false;
		}

		public override void Draw ()
		{
			if (_isActive && _isvisible) 
			{
				SwinGame.DrawCircle (Color.Green, DrawX, DrawY, Size);
			} else if (!_isActive)
			{
				_isvisible = false;
			}
		}

		public string Scientist {
			get { return _scientist; }
		}

		public bool IsActive {
			get { return _isActive; }
			set { _isActive = value; }
		}

		public bool Isvisible {
			get { return _isvisible; }
			set { _isvisible = value; }
		}
	}
}
