using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PCMount.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllersWithViews();
// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Start of Fluent UI Config
builder.Services.AddFluentUIComponents();
builder.Services.AddHttpClient();
builder.Services.AddFluentUIComponents(options => {
    options.ValidateClassNames = false;
});
// End of Fluent UI Config

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}

//app.UseHttpsRedirection(); // NOTE: If the app is being served over HTTPS, uncomment this line
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();