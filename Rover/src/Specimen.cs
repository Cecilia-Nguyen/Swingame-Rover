using System;
namespace Rover
{
    public class Specimen : GameObject
    {

        private string _scientist;
        private bool _IsActive;

        public Specimen(string scientist, int x, int y, int size, string name) : base(x, y, size, name)
        {
            _scientist = scientist;
            _IsActive = true;
        }

        public string Scientist
        {
            get { return _scientist; }
        }

        public bool Active
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
}
