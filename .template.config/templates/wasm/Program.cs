using System;
using System.Net.Http;
using System.Threading.Tasks;
using {pro-layout};
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
//#if (full)
using AntDesign.Pro.Services;
//#endif

namespace AntDesign.Pro
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
//#if (full)
            builder.Services.AddScoped<ChartService>();
            builder.Services.AddScoped<ProjectService>();
//#endif

            await builder.Build().RunAsync();
        }
    }
}