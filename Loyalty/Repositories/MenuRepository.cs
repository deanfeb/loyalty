using Loyalty.Entities.Master;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<Menu> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.Menus
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
