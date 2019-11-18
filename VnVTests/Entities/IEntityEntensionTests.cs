using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using VnVEntities;

namespace VnVTests.Entities
{
    [TestClass]
    public class IEntityEntensionTests
    {
        [TestMethod]
        public void HealthPercent_AtFullHealth_Returns100()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(50);
            entity.SetupGet(e => e.CurrentHealth).Returns(50);

            entity.Object.HealthPercent().Should().Be(100.0M);
        }

        [TestMethod]
        public void HealthPercent_AboveFullHealth()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(50);
            entity.SetupGet(e => e.CurrentHealth).Returns(100);

            entity.Object.HealthPercent().Should().Be(200.0M);
        }

        [TestMethod]
        public void HealthPercent_BelowFullHealth()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(50);
            entity.SetupGet(e => e.CurrentHealth).Returns(25);

            entity.Object.HealthPercent().Should().Be(50.0M);
        }

        [TestMethod]
        public void HealthPercent_HealthBelowZero_ReturnsZero()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(50);
            entity.SetupGet(e => e.CurrentHealth).Returns(-5);

            entity.Object.HealthPercent().Should().Be(0.0M);
        }

        [TestMethod]
        public void HealthDescription_AboveFullHealth()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(50);
            entity.SetupGet(e => e.CurrentHealth).Returns(100);

            entity.Object.HealthDescription().Should().Be("Is overflowing with energy!");
        }

        [TestMethod]
        public void HealthDescription_Between75And100Inclusive()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(100);
            entity.SetupGet(e => e.CurrentHealth).Returns(78);

            entity.Object.HealthDescription().Should().Be("Looks very healthy");
        }

        [TestMethod]
        public void HealthDescription_Between50And75Inclusive()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(100);
            entity.SetupGet(e => e.CurrentHealth).Returns(60);

            entity.Object.HealthDescription().Should().Be("Has some scrapes and bruises");
        }

        [TestMethod]
        public void HealthDescription_Between25And50Inclusive()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(100);
            entity.SetupGet(e => e.CurrentHealth).Returns(35);

            entity.Object.HealthDescription().Should().Be("Looks a bit hurt");
        }

        [TestMethod]
        public void HealthDescription_Between0And25Inclusive()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(100);
            entity.SetupGet(e => e.CurrentHealth).Returns(20);

            entity.Object.HealthDescription().Should().Be("Is struggling to stand");
        }

        [TestMethod]
        public void HealthDescription_IsZero()
        {
            var entity = new Mock<IEntity>();
            entity.SetupGet(e => e.MaxHealth).Returns(100);
            entity.SetupGet(e => e.CurrentHealth).Returns(0);

            entity.Object.HealthDescription().Should().Be("Is dead");
        }
    }
}
