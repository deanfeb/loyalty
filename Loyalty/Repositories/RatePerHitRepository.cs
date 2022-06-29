using Loyalty.Entities.Transaction;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class RatePerHitRepository : GenericRepository<RatePerHit>, IRatePerHitRepository
    {
        public RatePerHitRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<RatePerHit> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.RatePerHits
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
