using System;
using Lauderdale.Application.Service.Interface;
using Lauderdale.Domain.Interfaces.Repository;
using Lauderdale.Domain.Entities;
using Lauderdale.Domain.Operator;

namespace Lauderdale.Application.Service.Validations
{
    public class CityMustBeUniqueValidation : IValidator<City>
    {
        private readonly ICityRepository _cityRepository;

        public CityMustBeUniqueValidation(ICityRepository cityRepository)
        {
            this._cityRepository = cityRepository;
        }

        public void Validate(City city)
        {
            if (_cityRepository.Exists(city))
                throw new OperationResultException(OperationResult.Alert("Error", "This city already exists.", NoteType.warning));
        }

        public static CityMustBeUniqueValidation It(ICityRepository repository) => new CityMustBeUniqueValidation(repository);
    }
}
