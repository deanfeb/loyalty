using Loyalty.Entities.Transaction;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {
        }
        public IQueryable<Project> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param)
        {

            var query = from a in _context.Projects
                        select a;
            //query = query.Take(param.length).Skip(param.length * param.start);

            return query;
        }
    }
}
