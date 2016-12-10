using Lauderdale.Application.Service;
using Lauderdale.Domain.Entities;
using Lauderdale.Domain.Interfaces.Repository;
using Lauderdale.Domain.Operator;
using Moq;
using Xunit;

namespace Lauderdale.Application.Tests.Services
{
    public class CityServiceTest
    {
        private readonly CityService _service;
        private readonly Mock<ICityRepository> _repository;
        private readonly City city;

        public CityServiceTest()
        {
            _repository = new Mock<ICityRepository>();
            _service = new CityService(_repository.Object);
            city = new City() { Name = "test", Population = 1000, Id = "a" };
        }

        [Fact]
        public void SaveCity_WithoutName_Exception()
        {
            city.Name = null;
            Assert.Throws<OperationResultException>(() => _service.SaveCity(city));
        }

        [Fact]
        public void SaveCity_WithoutPopulation_Exception()
        {
            city.Population = 0;
            Assert.Throws<OperationResultException>(() => _service.SaveCity(city));
        }
    }
}
