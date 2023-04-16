using GerenciadorCondominios.BLL.Models.Enums;

namespace GerenciadorCondominios.BLL.Models;

public class HistoricoRecursos
{
    public int HistoricoRecursosId { get; set; }

    public decimal Valor { get; set; }

    public TipoOperacao Tipo { get; set; }

    public int Dia { get; set; }

    public int MesId { get; set; }
    public virtual Mes Mes { get; set; }

    public int Ano { get; set; }
}
