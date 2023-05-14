using TrifoyProject.Entity;
using TrifoyProject.Repository;

namespace TrifoyProject.API.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExtension(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //username default unique dir
                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = string.Empty;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(4);
                options.Lockout.MaxFailedAccessAttempts = 7;

            }).AddEntityFrameworkStores<AppIdentityDbContext>();
        }
    }
}
