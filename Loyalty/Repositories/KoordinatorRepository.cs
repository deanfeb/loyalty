using Loyalty.Entities.Transaction;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class KoordinatorRepository : GenericRepository<Koordinator>, IKoordinatorRepository
    {
        public KoordinatorRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<Koordinator> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.Koordinators
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
