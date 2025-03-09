using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBooking.Data;
using TravelBooking.Models.DBObjects;

namespace TestProject1
{
    internal class TestDatabaseContextFactory
    {
        public IApplicationDbContext GetDbContextInstance(List<Country> countries)
        {
            var countryTableMock = new Mock<DbSet<Country>>();

            countryTableMock.As<IQueryable<Country>>().Setup(m => 
                m.Provider).Returns(countries.AsQueryable().Provider);
            countryTableMock.As<IQueryable<Country>>().Setup(m =>
                m.Expression).Returns(countries.AsQueryable().Expression);
            countryTableMock.As<IQueryable<Country>>().Setup(m =>
                m.ElementType).Returns(countries.AsQueryable().ElementType);
            countryTableMock.As<IQueryable<Country>>().Setup(m =>
                m.GetEnumerator()).Returns(countries.AsQueryable().GetEnumerator());
            countryTableMock.Setup(x => x.Add(It.IsAny<Country>())).Callback<Country>((s) =>
                countries.Add(s));

            var dbContextMock = new Mock<IApplicationDbContext>();
            dbContextMock.Setup(x => x.Countries).Returns(countryTableMock.Object);
            return dbContextMock.Object;
        }
    }
}
