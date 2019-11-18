using System;
using System.Collections.Generic;
using System.Text;

namespace VnVEntities
{
    public interface IEntity
    {
        int MaxHealth { get; }
        int CurrentHealth { get; }
    }
}
