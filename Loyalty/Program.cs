using Loyalty;
using Loyalty.Entities;
using Loyalty.Interfaces.Master;
using Loyalty.Interfaces.Services;
using Loyalty.Repositories;
using Loyalty.Repositories.UnitOfWork;
using Loyalty.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(option => option.EnableEndpointRouting = true).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

#region Repositories
var services = builder.Services;
services.AddTransient<IUnitOfWork, UnitOfWork>();
services.AddTransient<IUnitOfWork, UnitOfWork>();
services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddTransient<IGroupRepository, GroupRepository>();
services.AddTransient<IGroupMenuRepository, GroupMenuRepository>();
services.AddTransient<IGroupUserRepository, GroupUserRepository>();
services.AddTransient<IMenuRepository, MenuRepository>();
services.AddTransient<IRoleRepository, RoleRepository>();
services.AddTransient<IUserRepository, UserRepository>();

services.AddTransient<IKoordinatorRepository, KoordinatorRepository>();
services.AddTransient<ILinkRepository, LinkRepository>();
services.AddTransient<ILinkCounterRepository, LinkCounterRepository>();
services.AddTransient<IMemberRepository, MemberRepository>();
services.AddTransient<IProjectRepository, ProjectRepository>();
services.AddTransient<IRatePerHitRepository, RatePerHitRepository>();
#endregion

#region Services
services.AddTransient<IGroupService, GroupService>();
services.AddTransient<IGroupMenuService, GroupMenuService>();
services.AddTransient<IGroupUserService, GroupUserService>();
services.AddTransient<IMenuService, MenuService>();
services.AddTransient<IRoleService, RoleService>();
services.AddTransient<IUserService, UserService>();


services.AddTransient<IKoordinatorService, KoordinatorService>();
services.AddTransient<ILinkService, LinkService>();
services.AddTransient<ILinkCounterService, LinkCounterService>();
services.AddTransient<IMemberService, MemberService>();
services.AddTransient<IProjectService, ProjectService>();
services.AddTransient<IRatePerHitService, RatePerHitService>();
#endregion

services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(
  builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthentication("Bearer")
//                .AddJwtBearer("Bearer", options =>
//                {
//                    options.Authority = "http://host.docker.internal:49154";//"https://localhost:44352"; //
//                    options.RequireHttpsMetadata = false;
//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateAudience = false
//                    };
//                });

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ApiScope", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim("scope", "api1");
//    });
//});

builder.Host.ConfigureLogging(l => l.AddConsole());
builder.WebHost.ConfigureLogging(l => l.AddConsole());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
