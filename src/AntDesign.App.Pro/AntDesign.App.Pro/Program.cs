using AntDesign.App.Pro.Components;
using AntDesign.App.Pro.Components.Account;
using AntDesign.App.Pro.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
builder.Services.AddTransient(sp =>
{
    var httpContext=sp.GetService<IHttpContextAccessor>()?.HttpContext;
    if (httpContext != null)
    {
        // 构建当前运行时的URL
        var request = httpContext.Request;
        var host = request.Host.ToUriComponent();
        var scheme = request.Scheme;
        var baseAddress = $"{scheme}://{host}";
        return new HttpClient(){ BaseAddress = new Uri(baseAddress) };
    }
    else
    {
        // 如果无法获取HTTP上下文，可以设置一个默认值
        return new HttpClient() { BaseAddress = new Uri("http://localhost:5000") };
    }
});


builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddClientServices(builder.Configuration.GetSection("ProSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
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

app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/dashboard"), second =>
{
    second.UseStaticFiles();
    second.UseRouting();
    second.UseAntiforgery();
    second.UseEndpoints(endpoints =>
    {
        endpoints.MapRazorComponents<AntDesign.Pro.Template.Components.App>()
        .AddInteractiveServerRenderMode()
        .AddInteractiveWebAssemblyRenderMode();
    });
});

app.MapRazorComponents<App>()
       //.AddAdditionalAssemblies(typeof(AntDesign.Pro.Template.Components._Imports).Assembly)
       .AddInteractiveServerRenderMode()
       .AddInteractiveWebAssemblyRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
