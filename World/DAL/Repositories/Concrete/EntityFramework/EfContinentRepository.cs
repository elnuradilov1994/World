using World.Core.DAL.Repositories.Concrete.EntityFramework;
using World.DAL.Repositories.Abstact;
using World.Entities;

namespace World.DAL.Repositories.Concrete.EntityFramework
{
    public class EfContinentRepository : EfBaseRepository<Continent, WorldDbContext>, IContinentRepository
    {
        public EfContinentRepository(WorldDbContext context) : base(context)
        {
        }
    }
}
