using VnV.Utilities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiceTests
{
    [TestClass]
    public class DieTests
    {
        [TestMethod]
        public void Ctor_SidesLessThanZero_ConstructorFailsWIthException()
        {
            Action constructor = () => new Die(-2);

            constructor.Should().Throw<ArgumentException>(because: "Die sides must be a positive nmber");
        }

        [TestMethod]
        public void Ctor_SidesEqualsZero_ConstructorFailsWithException()
        {
            Action constructor = () => new Die(0);

            constructor.Should().Throw<ArgumentException>(because: "Die sides must be a positive nmber");
        }

        [TestMethod]
        public void Ctor_SidesGreaterThanZero_ConstructorShouldNotThrow()
        {
            Action constructor = () => new Die(6);

            constructor.Should().NotThrow();
        }
    }
}
