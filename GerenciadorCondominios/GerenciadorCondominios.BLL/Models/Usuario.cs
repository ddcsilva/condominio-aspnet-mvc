using GerenciadorCondominios.BLL.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorCondominios.BLL.Models;

public class Usuario : IdentityUser<string>
{
    public string CPF { get; set; }
    public string Foto { get; set; }

    public bool PrimeiroAcesso { get; set; }
    public StatusConta Status { get; set; }

    public virtual ICollection<Apartamento> MoradoresApartamentos { get; set; } = new List<Apartamento>();
    public virtual ICollection<Apartamento> ProprietariosApartamentos { get; set; } = new List<Apartamento>();
    public virtual ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();
    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
