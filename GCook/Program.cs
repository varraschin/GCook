using GCook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GCook.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Serviço de conexão com o banco de dados
string conexao = builder.Configuration.GetConnectionString("GCookDb");
var versao = ServerVersion.AutoDetect(conexao);
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(conexao, versao)
);

// Servoço de identificação de usuário
builder.Services.AddIdentity<Usuario, IdentityRole>(
    options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.User.RequireUniqueEmail = true;
    }
)
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


var app = builder.Build();

// Garantir que o banco exista ao executar o projeto
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
