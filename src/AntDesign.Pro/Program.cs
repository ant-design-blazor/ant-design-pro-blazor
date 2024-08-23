using System;
using System.Net.Http;
using System.Threading.Tasks;
using AntDesign.ProLayout;
//#if (full)
using AntDesign.Pro.Template.Services;
//#endif
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AntDesign.Pro.Template
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
//#if (host == 'wasm')
            builder.RootComponents.Add<App>("#app");
//#endif

            builder.Services.AddScoped<HttpDelegatingHandler>();

            builder.Services.AddHttpClient()
                .ConfigureHttpClientDefaults(c => c.AddHttpMessageHandler<HttpDelegatingHandler>( )
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)));

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient());

            AddClientServices(builder.Services);

            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

            await builder.Build().RunAsync();
        }

        public static void AddClientServices(IServiceCollection services)
        {
            services.AddAntDesign();
            //#if (full)
            services.AddInteractiveStringLocalizer();
            services.AddLocalization();

            services.AddScoped<IChartService, ChartService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
            //#endif
        }
    }
}