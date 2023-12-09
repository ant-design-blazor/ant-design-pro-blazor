using AntDesign.Pro.Template.Services;
using AntDesign.ProLayout;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
       public static void AddClientServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddAntDesign();

            services.AddScoped<IChartService, ChartService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();

            services.Configure<ProSettings>(configuration);
        }
    }
}
