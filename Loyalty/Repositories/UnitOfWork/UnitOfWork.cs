using Loyalty.Entities;
using Loyalty.Interfaces.Master;

namespace Loyalty.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Groups = new GroupRepository(_context);
            GroupMenus = new GroupMenuRepository(_context);
            GroupUsers = new GroupUserRepository(_context);
            Menus = new MenuRepository(_context);
            Roles = new RoleRepository(_context);
            Users = new UserRepository(_context);

            Koordinators = new KoordinatorRepository(_context);
            Links = new LinkRepository(_context);
            LinkCounters = new LinkCounterRepository(_context);
            Members = new MemberRepository(_context);
            Projects = new ProjectRepository(_context);
            RatePerHits = new RatePerHitRepository(_context);

        }
        public IGroupRepository Groups { get; private set; }
        public IGroupMenuRepository GroupMenus { get; private set; }
        public IGroupUserRepository GroupUsers { get; private set; }
        public IMenuRepository Menus { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IUserRepository Users { get; private set; }

        public IKoordinatorRepository Koordinators { get; private set; }
        public ILinkRepository Links { get; private set; }
        public ILinkCounterRepository LinkCounters { get; private set; }
        public IMemberRepository Members { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public IRatePerHitRepository RatePerHits { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
