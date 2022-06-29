using Loyalty.Entities.Transaction;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class LinkCounterRepository : GenericRepository<LinkCounter>, ILinkCounterRepository
    {
        public LinkCounterRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<LinkCounter> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.LinkCounters
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
