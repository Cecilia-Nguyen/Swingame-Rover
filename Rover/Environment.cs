using System;
using System.Collections.Generic;

namespace Rover
{
    public class Environment
    {

        private List<Rover> _rovers;
        private List<Specimen> _specimens;
        private int _width, _height;

        public Environment(int height, int width, int rovers, int specimens)
        {
            _width = width;
            _height = height;
            AddRovers(rovers);
            AddSpecimens(specimens);
        }

        public void Update()
        {
            
        }

        public void AddRovers(int amount)
        {
            _rovers = new List<Rover>();

            for (int i = 0; i < amount; i++)
            {
                //TODO: ADD ROVERS HERE
            }
        }

        public void AddSpecimens(int amount)
        {
            _specimens = new List<Specimen>();

            for (int i = 0; i < amount; i++)
            {
                //TODO: Randomly generate specimens
            }
        }

        public List<Rover> Rovers
        {
            get { return _rovers; }

        }

        public List<Specimen> Specimens
        {
            get { return _specimens; }

        }
    }
}
