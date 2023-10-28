using System;

namespace Project3.Scripts.Objects.Apophises
{
    [Serializable]
    internal struct ApophisData
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public int Cost { get; private set; }

        public ApophisData(string name, int health, int damage, int cost)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Cost = cost;
        }
    }
}
