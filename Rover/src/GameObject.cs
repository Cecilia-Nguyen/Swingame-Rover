using System;
namespace Rover
{
    public abstract class GameObject
    {

        private int _x, _y, _size;
        private string _name;
		private Environment _environment;

		public GameObject(int x, int y, int size, string name, Environment env)
        {
            _x = x;
            _y = y;
            _size = size;
			_name = name;
			_environment = env;
        }

		public abstract void Draw ();

        public bool IsIn(GameObject hostObj, int radius)
        {
            if ((this.X < (hostObj.X + radius)) && (this.X > (hostObj.X - radius)))
            {
                if((this.Y < (hostObj.Y + radius))&& (this.Y > (hostObj.Y - radius)))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsIn(int x1, int y1, int x2, int y2)
        {
            if ((this.X < x2) && (this.X > x1))
            {
                if ((this.Y < y2) && (this.Y > y1))
                {
                    return true;
                }
            }

            return false;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int DrawX
		{
			get { return _x*Env.Width/20 + Env.Offset; }
		}

		public int DrawY {
			get { return _y*Env.Width/20 + Env.Offset; }
        }

        public int Size
        {
            get { return _size; }
        }

        public string Name
        {
            get { return _name; }
        }

		public Environment Env 
		{
            get { return _environment; }
        }
    }
}
