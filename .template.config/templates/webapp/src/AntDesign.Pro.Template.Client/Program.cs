using System;
using System.Net.Http;
using System.Threading.Tasks;
using AntDesign.ProLayout;
//#if (full)
using AntDesign.Pro.Template.Services;
//#endif
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AntDesign.Pro.Template.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            AddAntDeisgnPro(builder.Services, builder.Configuration.GetSection("ProSettings"));

            await builder.Build().RunAsync();
        }


        public static void AddAntDeisgnPro(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAntDesign();
            services.Configure<ProSettings>(configuration);
            //#if (full)
            services.AddScoped<IChartService, ChartService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
            //#endif
        }
    }
}