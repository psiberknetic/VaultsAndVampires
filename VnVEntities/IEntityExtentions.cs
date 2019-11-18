using System;
using System.Collections.Generic;
using System.Text;

namespace VnVEntities
{
    public static class IEntityExtentions
    {
        public static string HealthDescription(this IEntity entity)
        {
            switch (entity.HealthPercent())
            {
                case decimal d when (d > 100.0M):
                    return "Is overflowing with energy!";
                case decimal d when (d > 75.0M && d <= 100.0M):
                    return "Looks very healthy";
                case decimal d when (d > 50.0M && d <= 75.0M):
                    return "Has some scrapes and bruises";
                case decimal d when (d > 25.0M && d <= 50.0M):
                    return "Looks a bit hurt";
                case decimal d when (d > 0.0M && d <= 25.0M):
                    return "Is struggling to stand";
                case decimal d when (d == 0.0M):
                    return "Is dead";
            }

            throw new ArgumentOutOfRangeException("Invalid Health Percent");
        }

        public static Decimal HealthPercent(this IEntity entity)
        {
            var healthPercent = ((Decimal)entity.CurrentHealth / (Decimal)entity.MaxHealth) * 100.0M;

            return Math.Max(0, healthPercent);
        }
    }
}
