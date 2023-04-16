using GerenciadorCondominios.BLL.Models.Enums;

namespace GerenciadorCondominios.BLL.Models;

public class Servico
{
    public int ServicoId { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }

    public StatusServico Status { get; set; }

    public string UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }

    public ICollection<ServicoPredio> ServicoPredios { get; set; } = new List<ServicoPredio>();
}
