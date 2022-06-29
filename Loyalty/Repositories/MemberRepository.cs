using Loyalty.Entities.Transaction;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<Member> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.Members
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
