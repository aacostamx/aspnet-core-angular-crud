using Lauderdale.Domain.Entities;
using System.Collections.Generic;

namespace Lauderdale.Application.Interfaces.Services
{
    public interface ICityService
    {
        List<City> ListAllCities();
        void SaveCity(City city);
        void RemoveCity(string id);
        City GetCityById(string id);
    }
}
