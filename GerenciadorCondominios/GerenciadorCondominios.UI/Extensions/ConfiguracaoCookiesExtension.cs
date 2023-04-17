namespace GerenciadorCondominios.UI.Extensions;

/// <summary>
/// Classe de extensão para configurar as opções de cookies.
/// </summary>
public static class ConfiguracaoCookiesExtension
{
    /// <summary>
    /// Configura as opções de cookies da aplicação.
    /// </summary>
    /// <param name="service">O IServiceCollection para adicionar as configurações.</param>
    public static void ConfigurarCookies(this IServiceCollection service)
    {
        service.ConfigureApplicationCookie(opcoes =>
        {
            opcoes.Cookie.Name = "IdentityCookie";
            opcoes.Cookie.HttpOnly = true;
            opcoes.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            opcoes.LoginPath = "/Usuarios/Login";
            opcoes.AccessDeniedPath = "/Usuarios/AcessoNegado";
        });
    }
}
