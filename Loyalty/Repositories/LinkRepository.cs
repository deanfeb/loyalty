using Loyalty.Entities.Transaction;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class LinkRepository : GenericRepository<Link>, ILinkRepository
    {
        public LinkRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<Link> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.Links
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
