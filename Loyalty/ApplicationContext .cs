using Loyalty.Entities.Master;
using Loyalty.Entities.Transaction;
using Microsoft.EntityFrameworkCore;

namespace Loyalty
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Unit> Units { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMenu> GroupMenus { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Koordinator> Koordinators { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<LinkCounter> LinkCounters { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RatePerHit> RatePerHits { get; set; }

    }
}