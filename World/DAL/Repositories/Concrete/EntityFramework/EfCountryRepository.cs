using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using World.DAL.Repositories.Abstact;
using World.Entities;

namespace World.DAL.Repositories.Concrete.EntityFramework
{
    public class EfCountryRepository : ICountryRepository
    {
        private readonly WorldDbContext _context;

        public EfCountryRepository(WorldDbContext context)
        {
            _context = context;
        }

        public async Task CreateCountryAsync(Country country)
        {
           await _context.Countries.AddAsync(country);
        }

        public void DeleteCountryAsync(Country country)
        {
            _context.Countries.Remove(country);
        }

        public async Task<List<Country>> GetCountriesAsync(Expression<Func<Country, bool>> filter = null)
        {
            return filter == null
                ? await _context.Countries.ToListAsync()
                : await _context.Countries.Where(filter).ToListAsync();

        }

        public async Task<Country> GetCountryAsync(Expression<Func<Country, bool>> filter)
        {
            return await _context.Countries.FirstOrDefaultAsync(filter);

        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void UpdateCountryAsync(Country country)
        {
            _context.Countries.Update(country);
        }
    }
}
