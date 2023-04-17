using GerenciadorCondominios.BLL.Models.Enums;
using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interfaces;
using GerenciadorCondominios.UI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorCondominios.UI.Controllers;

public class UsuariosController : Controller
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IFuncaoRepositorio _funcaoRepositorio;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IFuncaoRepositorio funcaoRepositorio, IWebHostEnvironment webHostEnvironment)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _funcaoRepositorio = funcaoRepositorio;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Registro()
    {
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Registro(RegistroViewModel model, IFormFile foto)
    {
        if (ModelState.IsValid)
        {
            // Salva a foto e obtém a URL
            string fotoUrl = await SalvarFoto(foto);

            // Define as variáveis de acesso e status com base na existência de registros
            bool primeiroAcesso;
            StatusConta status;

            if (_usuarioRepositorio.VerificarSeExisteRegistro() == 0)
            {
                primeiroAcesso = false;
                status = StatusConta.Aprovado;
            }
            else
            {
                primeiroAcesso = true;
                status = StatusConta.Analisando;
            }

            // Cria o usuário e obtém o resultado
            IdentityResult usuarioCriado = await CriarUsuario(model, fotoUrl, primeiroAcesso, status);

            if (usuarioCriado.Succeeded)
            {
                // Obtém o usuário recém-criado pelo e-mail
                Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloEmail(model.Email);

                // Verifica se o usuário é o primeiro a ser registrado e, em caso afirmativo, atribui a função de administrador e efetua login
                if (!primeiroAcesso)
                {
                    await _usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, "Administrador");
                    await _usuarioRepositorio.LogarUsuario(usuario, false);
                    // Redireciona para a página de índice dos usuários
                    return RedirectToAction("Index", "Usuarios");
                }
                else
                {
                    // Exibe a página de análise para usuários que não sejam o primeiro a se registrar
                    return View("Analise", usuario.UserName);
                }
            }
            else
            {
                // Adiciona erros de validação ao ModelState e retorna à visualização original
                foreach (IdentityError erro in usuarioCriado.Errors)
                {
                    ModelState.AddModelError("", erro.Description);
                }
                return View(model);
            }
        }
        // Retorna à visualização original se o ModelState não for válido
        return View(model);
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Analise(string nome)
    {
        return View(nome);
    }

    private async Task<string> SalvarFoto(IFormFile foto)
    {
        string nomeFoto = null;
        if (foto != null)
        {
            // Define o diretório e o nome da foto
            string diretorioPasta = Path.Combine(_webHostEnvironment.WebRootPath, "imagens");
            nomeFoto = Guid.NewGuid().ToString() + foto.FileName;

            // Salva a foto no diretório especificado
            using (FileStream fileStream = new FileStream(Path.Combine(diretorioPasta, nomeFoto), FileMode.Create))
            {
                await foto.CopyToAsync(fileStream);
            }
        }
        return "~/imagens/" + nomeFoto;
    }

    private async Task<IdentityResult> CriarUsuario(RegistroViewModel model, string fotoUrl, bool primeiroAcesso, StatusConta status)
    {
        // Cria um novo usuário com os dados do modelo
        Usuario usuario = new Usuario
        {
            UserName = model.Nome,
            CPF = model.CPF,
            Email = model.Email,
            PhoneNumber = model.Telefone,
            Foto = fotoUrl,
            PrimeiroAcesso = primeiroAcesso,
            Status = status
        };

        // Cria o usuário e retorna o resultado 
        IdentityResult usuarioCriado = await _usuarioRepositorio.CriarUsuario(usuario, model.Senha);
        return usuarioCriado;
    }
}
