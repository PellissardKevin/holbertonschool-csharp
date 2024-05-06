using System;

namespace Enemies
{
    /// <summary>Zombie class</summary>
    class Zombie
    {
        private int health;
        private string name = "(No name)";
        public Zombie()
        {
            health = 0;
        }
        public Zombie(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Health must be greater than or equal to 0");
            }

            health = value;
        }
        public int GetHealth()
        {
            return health;
        }
        public string Name
        {
            set {
                name = value;
            }
            get {
                return name;
            }
        }
    }
}
