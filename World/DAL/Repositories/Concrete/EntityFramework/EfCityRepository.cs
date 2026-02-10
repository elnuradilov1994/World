using World.Core.DAL.Repositories.Concrete.EntityFramework;
using World.DAL.Repositories.Abstact;
using World.Entities;

namespace World.DAL.Repositories.Concrete.EntityFramework
{
    public class EfCityRepository : EfBaseRepository<CapitalCity, WorldDbContext>, ICityRepository
    {
        public EfCityRepository(WorldDbContext context) : base(context)
        {
        }
    }
}
