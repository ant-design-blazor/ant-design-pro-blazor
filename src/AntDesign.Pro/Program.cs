using AntDesign.ProLayout;
using AntDesign.Pro.Template.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AntDesign.Pro.Template.Auth;
using Microsoft.AspNetCore.Components.Authorization;

namespace AntDesign.Pro.Template
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            //builder.RootComponents.Add<App>("#app");

        
            AddClientServices(builder.Services);

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

            await builder.Build().RunAsync();
        }

        public static void AddClientServices(IServiceCollection services)
        {
            services.AddAntDesign();

            services.AddScoped<IChartService, ChartService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}