using Microsoft.AspNetCore.Identity;

namespace GerenciadorCondominios.UI.Extensions;

/// <summary>
/// Classe de extensão para configurar as opções de nome de usuário do Identity.
/// </summary>
public static class ConfiguracaoIdentityExtension
{
    /// <summary>
    /// Configura as opções de nome de usuário do Identity.
    /// </summary>
    /// <param name="services">O IServiceCollection para adicionar as configurações.</param>
    public static void ConfigurarNomeUsuario(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(opcoes =>
        {
            opcoes.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            opcoes.User.RequireUniqueEmail = true;
        });
    }

    /// <summary>
    /// Configura as opções de nome de senha do Identity.
    /// </summary>
    /// <param name="services">O IServiceCollection para adicionar as configurações.</param>
    public static void ConfigurarSenhaUsuario(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(opcoes =>
        {
            opcoes.Password.RequireDigit = true;
            opcoes.Password.RequireLowercase = true;
            opcoes.Password.RequiredLength = 8;
            opcoes.Password.RequireNonAlphanumeric = true;
            opcoes.Password.RequireUppercase = true;
            opcoes.Password.RequiredUniqueChars = 0;
        });
    }
}
