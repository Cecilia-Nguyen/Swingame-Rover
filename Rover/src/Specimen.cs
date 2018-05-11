using System;
using SwinGameSDK;
namespace Rover
{
	public class Specimen : GameObject
	{

		private string _scientist;
		private bool _isActive;
		private bool _isVisable;

		public Specimen (string scientist, int x, int y, int size, string name, Environment env) : base (x, y, size, name,env)
		{
			_scientist = scientist;
			_isActive = true;
			_isVisable = false;
		}

		public override void Draw ()
		{
			if (_isVisable) {
				SwinGame.DrawCircle (Color.Green, DrawX, DrawY, Size);
			}
		}

		public string Scientist {
			get { return _scientist; }
		}

		public bool IsActive {
			get { return _isActive; }
			set { _isActive = value; }
		}

		public bool IsVisable {
			get { return _isVisable; }
			set { _isVisable = value; }
		}
	}
}
