using Loyalty.Interfaces.Master;

namespace Loyalty.Entities
{
    public interface IUnitOfWork : IDisposable
    {
        IGroupRepository Groups { get; }
        IGroupMenuRepository GroupMenus { get; }
        IGroupUserRepository GroupUsers { get; }
        IMenuRepository Menus { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }

        IKoordinatorRepository Koordinators { get; }
        ILinkRepository Links { get; }
        ILinkCounterRepository LinkCounters { get; }
        IMemberRepository Members { get; }
        IProjectRepository Projects { get; }
        IRatePerHitRepository RatePerHits { get; }

        int Complete();
    }
}
