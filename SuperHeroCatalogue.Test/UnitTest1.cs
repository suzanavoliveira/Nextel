using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SuperHeroCatalogue.Helpers;
using SuperHeroCatalogue.Models;
using SuperHeroCatalogue.Services;
using System.Collections.Generic;

namespace SuperHeroCatalogue.Test
{
    [TestClass]
    public class ServicceSuperPowerTest
    {
        [TestMethod]
        [ExpectedException(typeof(AppException), "Cannot delete a Super Power related to a Super Hero")]
        public void CannotDeleteWithRelatedSuperHero()
        {
            var mockSet = new Mock<DbSet<SuperHero>>();

            var mockContext = new Mock<SuperHeroCatalogueDb>();
            mockContext.Setup(m => m.SuperHeroes).Returns(mockSet.Object);

            var superHeroService = new SuperHeroService(mockContext.Object, null);
            var superPowerService = new SuperHeroService(mockContext.Object, null);

            var superPowers = new List<SuperPower>() {
                new SuperPower() { Name = "breath underwater", Description = "breath underwater" },
                new SuperPower() { Name = "super force", Description = "super force" },
            };

            var superHero = new SuperHero()
            {
                Name = "Spider man",
                Alias = "Spider",
                ProtectionArea = new ProtectionArea() { Name = "Manhatan", Lat = 40.758896F, Long = -73.985130F, Radius = 1000 },
            };

            superPowers.ForEach(sp => superHero.SuperPowers.Add(sp));

            mockContext.Object.SuperHeroes.Attach(superHero);

            mockContext.Object.SaveChanges();

            superPowerService.Delete(1);
        }
    }
}
