using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL;
using GerenciadorCondominios.UI.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoDB"));
});

builder.Services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<Contexto>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.ConfigurarRepositorios();
builder.Services.ConfigurarCookies();
builder.Services.ConfigurarNomeUsuario();
builder.Services.ConfigurarSenhaUsuario();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
