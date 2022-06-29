using Loyalty.Entities.Master;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class GroupMenuRepository : GenericRepository<GroupMenu>, IGroupMenuRepository
    {
        public GroupMenuRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<GroupMenu> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.GroupMenus
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
