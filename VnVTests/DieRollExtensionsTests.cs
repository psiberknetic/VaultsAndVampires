using VnV.Utilities;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiceTests
{
    [TestClass]
    public class DieRollExtensionsTests
    {
        [TestMethod]
        public void MinimumValue_FourDefaultDice_Is4()
        {
            var dice = Enumerable.Range(1, 4).Select(_ => new Die());

            dice.MinimumValue().Should().Be(4);
        }

        [TestMethod]
        public void MinimumValue_FourDefaultDiceWithModifier_IsCorrect()
        {
            var dice = Enumerable.Range(1, 4).Select(_ => new Die());

            dice.MinimumValue(-3).Should().Be(1);
        }

        [TestMethod]
        public void MaximumValue_FourDefaultDice_Is24()
        {
            var dice = Enumerable.Range(1, 4).Select(_ => new Die());

            dice.MaximumValue().Should().Be(24);
        }

        [TestMethod]
        public void MaximumValue_FourDefaultDiceWithModifier_IsCorrect()
        {
            var dice = Enumerable.Range(1, 4).Select(_ => new Die());

            dice.MaximumValue(7).Should().Be(31);
        }

        [TestMethod]
        public void Total_CollectionWithModifier_IsCorrect()
        {
            var dice = new[]{
                CreateMockDie(6, 3),
                CreateMockDie(6, 2),
                CreateMockDie(6, 5),
                CreateMockDie(6, 1),
            };

            dice.Total(5).Should().Be(16);
        }

        private IDie CreateMockDie(int sides, int value)
        {
            var mockDie = new Mock<IDie>();
            mockDie.SetupGet(d => d.Value).Returns(value);
            mockDie.SetupGet(d => d.Sides).Returns(sides);

            return mockDie.Object;
        }
    }
}
