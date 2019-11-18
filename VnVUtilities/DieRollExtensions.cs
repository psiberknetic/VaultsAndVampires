using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VnV.Utilities
{
    public static class DieRollExtensions
    {
        public static IEnumerable<IDie> Roll(this IEnumerable<IDie> dice)
        {
            return dice.Select(die => die.Roll());
        }

        public static int Total(this IEnumerable<IDie> dice)
        {
            return dice.Sum(die => die.Value);
        }

        public static int Total(this IEnumerable<IDie> dice, int modifier)
        {
            return dice.Total() + modifier;
        }

        public static int MinimumValue(this IEnumerable<IDie> dice)
        {
            return dice.Count();
        }

        public static int MinimumValue(this IEnumerable<IDie> dice, int modifier)
        {
            return dice.MinimumValue() + modifier;
        }

        public static int MaximumValue(this IEnumerable<IDie> dice)
        {
            return dice.First().Sides * dice.Count();
        }

        public static int MaximumValue(this IEnumerable<IDie> dice, int modifier)
        {
            return dice.MaximumValue() + modifier;
        }
    }
}
