using GerenciadorCondominios.DAL.Interfaces;
using GerenciadorCondominios.DAL.Repositorios;

namespace GerenciadorCondominios.UI.Extensions;

/// <summary>
/// Classe de extensão para configurar os repositórios.
/// </summary>
public static class ConfiguracaoRepositoriosExtension
{
    /// <summary>
    /// Configura e registra os repositórios na aplicação.
    /// </summary>
    public static void ConfigurarRepositorios(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        services.AddScoped<IFuncaoRepositorio, FuncaoRepositorio>();
    }
}
