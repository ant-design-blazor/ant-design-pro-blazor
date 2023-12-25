using AntDesign.Pro.Template.Client.Pages;
using AntDesign.Pro.Template.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient("API").ConfigureHttpClient((sp, client) =>
{
    var httpContext = sp.GetService<IHttpContextAccessor>()?.HttpContext;
    if (httpContext == null)
    {
        client.BaseAddress = new Uri("https://localhost:80/");
        return;
    }

    var request = httpContext.Request;
    var host = request.Host.ToUriComponent();
    var scheme = request.Scheme;
    client.BaseAddress = new Uri($"{scheme}://{host}");
});

builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"));

AntDesign.Pro.Template.Client.Program.AddAntDeisgnPro(builder.Services, builder.Configuration.GetSection("ProSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AntDesign.Pro.Template.Client.Routes).Assembly);

app.Run();
