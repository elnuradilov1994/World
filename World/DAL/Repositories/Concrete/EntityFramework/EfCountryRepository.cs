using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using World.Core.DAL.Repositories.Concrete.EntityFramework;
using World.DAL.Repositories.Abstact;
using World.Entities;

namespace World.DAL.Repositories.Concrete.EntityFramework
{
    public class EfCountryRepository : EfBaseRepository<Country, WorldDbContext>, ICountryRepository
    {
        public EfCountryRepository(WorldDbContext context) : base(context)
        {
        }
    }
}
