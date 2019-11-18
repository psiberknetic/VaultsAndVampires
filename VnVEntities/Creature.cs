using System;
using System.Collections.Generic;
using System.Text;

namespace VnVEntities
{
    public class Creature : ICreature
    {
        private readonly string _name;
        private readonly string _description;
        private readonly int _maxHealth;
        private int _currentHealth;

        public Creature(string name, string description, Range healthRange)
        {
            var rng = new Random();

            _name = name;
            _description = description;
            _maxHealth = rng.Next(healthRange.Start.Value, healthRange.End.Value);
            _currentHealth = _maxHealth;
        }

        public string Name => _name;

        public string Description => _description;

        public int MaxHealth => _maxHealth;

        public int CurrentHealth => _currentHealth;
    }
}
