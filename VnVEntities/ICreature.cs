using System;
using System.Collections.Generic;
using System.Text;

namespace VnVEntities
{
    public interface ICreature : IEntity
    {
        string Name { get; }
        string Description { get; }

    }
}
