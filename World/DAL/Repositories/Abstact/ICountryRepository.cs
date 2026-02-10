using System.Linq.Expressions;
using World.Entities;

namespace World.DAL.Repositories.Abstact
{
    public interface ICountryRepository
    {
        public Task<Country> GetCountryAsync(Expression<Func<Country, bool>> filter);
        public Task<List<Country>> GetCountriesAsync(Expression<Func<Country, bool>> filter =null);
        public Task CreateCountryAsync (Country country);
        public void DeleteCountryAsync (Country country);
        public void UpdateCountryAsync (Country country);
        public Task SaveAsync();

    }
}
