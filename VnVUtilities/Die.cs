using System;
using System.Collections.Generic;
using System.Text;

namespace VnV.Utilities
{
    public class Die : IDie
    {
        public Die(int sides = 6)
        {
            if (sides <= 0)
            {
                throw new ArgumentException("Sides must be greater than zero", "sides");
            }

            _sides = sides;
            Roll();
        }

        private readonly Random _random = new Random();
        private readonly Guid _id = Guid.NewGuid();
        private readonly int _sides;
        private int _value;

        public Guid Id => _id;

        public int Value => _value;

        public int Sides => _sides;

        public IDie Roll()
        {
            _value = _random.Next(1, _sides);
            return this;
        }
    }
}
