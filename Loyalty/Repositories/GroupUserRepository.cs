using Loyalty.Entities.Master;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class GroupUserRepository : GenericRepository<GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<GroupUser> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.GroupUsers
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
