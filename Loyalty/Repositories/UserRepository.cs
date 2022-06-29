using Loyalty.Entities.Master;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<User> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.Users
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
