namespace GerenciadorCondominios.BLL.Models;

public class Mes
{
    public int MesId { get; set; }

    public string Nome { get; set; }

    public virtual ICollection<Aluguel> Alugueis { get; set; } = new List<Aluguel>();
    public virtual ICollection<HistoricoRecursos> HistoricoRecursos { get; set; } = new List<HistoricoRecursos>();
}
