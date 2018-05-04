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
