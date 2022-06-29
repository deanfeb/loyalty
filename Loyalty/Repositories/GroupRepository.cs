using Loyalty.Entities.Master;
using Loyalty.Entities.Transaction;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<Group> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.Groups
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
