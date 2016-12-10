using Lauderdale.Domain.Entities;
using System.Linq;

namespace Lauderdale.Domain.Interfaces.Repository
{
    public interface ICityRepository
    {
        IQueryable<City> GetAll();
        City GetById(string id);
        bool Exists(City city);
        void AddCity(City city);
        void EditCity(City city);
        void Delete(string id);
    }
}
