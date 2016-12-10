using Lauderdale.App.Domain.Validator;
using Lauderdale.Application.Interfaces.Services;
using Lauderdale.Application.Service.Validations;
using Lauderdale.Domain.Entities;
using Lauderdale.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Lauderdale.Application.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            this._repository = repository;
        }

        public List<City> ListAllCities()
        {
            return _repository.GetAll().OrderBy(b => b.Name).ToList();
        }

        public void SaveCity(City city)
        {
            var validation = city.Validate();
            Guard.AssertIsSuccess(validation);
            CityMustBeUniqueValidation.It(_repository).Validate(city);

            if (city.IsNew)
                _repository.AddCity(city);
            else
                _repository.EditCity(city);
        }

        public void RemoveCity(string id)
        {
            Guard.AssertIsNotEmpty(id, "The id was not informed");
            _repository.Delete(id);
        }

        public City GetCityById(string id)
        {
            Guard.AssertIsNotEmpty(id, "The id was not informed");
            var city = _repository.GetById(id);
            return city ?? new City();
        }
    }
}
