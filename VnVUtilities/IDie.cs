using System;
using System.Collections.Generic;
using System.Text;

namespace VnV.Utilities
{
    public interface IDie
    {
        IDie Roll();

        Guid Id { get; }
        int Value { get; }
        int Sides { get; }
    }
}
