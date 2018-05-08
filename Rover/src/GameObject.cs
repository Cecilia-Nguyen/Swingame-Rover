using System;
namespace Rover
{
    public abstract class GameObject
    {

        private int _x, _y, _size;
        private string _name;

        public GameObject(int x, int y, int size, string name)
        {
            _x = x;
            _y = y;
            _size = size;
            _name = name;
        }

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

        public int Size
        {
            get { return _size; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
