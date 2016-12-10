using Lauderdale.Domain.Entities;
using Lauderdale.Domain.Interfaces.Repository;
using Lauderdale.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Lauderdale.Infra.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly EntitiesContext _context;

        public CityRepository(EntitiesContext context)
        {
            this._context = context;
        }

        public IQueryable<City> GetAll()
        {
            return _context.Cities;
        }

        public City GetById(string id)
        {
            return _context.Cities.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public bool Exists(City city)
        {
            var name = city.Name?.ToLower() ?? String.Empty;
            var Id = city.Id?.ToLower() ?? String.Empty;

            return _context.Cities.Any(c => c.Name.ToLower().Equals(name) &&
                                            c.Id.ToLower() != Id);
        }

        public void AddCity(City city)
        {
            city.Id = Guid.NewGuid().ToString();
            _context.Cities.Add(city);
        }

        public void EditCity(City city)
        {
            _context.Cities.Attach(city);
            _context.Entry(city).State = EntityState.Modified;
        }

        public void Delete(string id)
        {
            var book = GetById(id);
            _context.Cities.Remove(book);
        }
    }
}
