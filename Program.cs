using LibrairieDTICRosemont.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using LibrairieDTICRosemont;


var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

var configuration = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json")
.Build();
builder.Services.AddIdentity<Client, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false; // Disable email confirmation requirement
                                                  // Other Identity options configuration
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddSingleton<IEmailSender, DummyEmailSender>();



var connectionString = configuration.GetConnectionString("LocalSqlServerConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddRazorPages();


builder.Services.AddSignalR();

// pour base des donn�es mysql
/*
var connectionString = configuration.GetConnectionString("LocalDbConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
*/

// Ajoutez la gestion des sessions
builder.Services.AddDistributedMemoryCache(); // Utilisation de la m�moire pour stocker les sessions
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // D�finir la dur�e de la session
    options.Cookie.Name = ".AspNetCore.Session"; // Nom du cookie de session
});
// Ajoutez la configuration du service IHttpContextAccessor
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();



// Configurez la base de donn�es et ajoutez des donn�es de test
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Appliquer les migrations si n�cessaire
    dbContext.SeedData(); // Ajouter des donn�es de test
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Activez la gestion des sessions
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapHub<ChatHub>("/chatHub");
app.MapRazorPages();

app.Run();
