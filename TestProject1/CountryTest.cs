using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBooking.Models.DBObjects;
using TravelBooking.Repositories;

namespace TestProject1
{
    internal class CountryTest
    {
        private TestDatabaseContextFactory _testDatabaseContextFactory;

        [SetUp]
        public void SetUp()
        {
            _testDatabaseContextFactory = new TestDatabaseContextFactory();
        }

        [Test]
        public void GetByName_WhenPresent_ReturnsObject()
        {
            var countries = new List<Country>
            {
                new Country {CountryId = Guid.NewGuid(), Name = "Spania"},
                new Country {CountryId = Guid.NewGuid(), Name = "Grecia"},
                new Country {CountryId = Guid.NewGuid(), Name = "Italia"},
            };

            var dbContext = _testDatabaseContextFactory.GetDbContextInstance(countries);
            var countryRepository = new CountryRepository(dbContext);
            var firstName = countries.First().Name;

            Assert.IsNotNull(countryRepository.GetCountryByName(firstName));
        }
    }
}
