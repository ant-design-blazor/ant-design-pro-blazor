using AntDesign.ProLayout;
using AntDesign.Pro.Template.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AntDesign.Pro.Template.Auth;
using Microsoft.AspNetCore.Components.Authorization;


var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddClientServices();

builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

await builder.Build().RunAsync();


