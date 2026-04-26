using Lims.Components;
using Lims.Components.Data;
using LIMS.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();

builder.Services.AddSyncfusionBlazor();
// Bind AppSettings section
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddScoped<ApiData>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthStateProvider>());

// Notification service used by the shared toast component. Registered as singleton so any component/page can call it.
builder.Services.AddSingleton<NotificationService>();

builder.Services.AddAuthorizationCore(); // Required for [Authorize]

// If you do not have the NuGet package installed, install:
// Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage

// If the method is still not found, you may need to manually register the services for ProtectedBrowserStorage.
// Replace the problematic line with the following:
builder.Services.AddScoped<ExecutionClass>();

builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddScoped<ProtectedSessionStorage>();

var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ix0oFS8QJAw9HSQvXkVhQlBad1hJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxWdkxhXH5acHBQQGJdUEB9XEM=");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JFaF5cXGRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXZcdXVRRmJeV0xxW0dWYEg=");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();



app.Run();
