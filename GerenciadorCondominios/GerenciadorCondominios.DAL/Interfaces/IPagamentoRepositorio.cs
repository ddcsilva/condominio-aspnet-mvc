using GerenciadorCondominios.BLL.Models;

namespace GerenciadorCondominios.DAL.Interfaces;

public interface IPagamentoRepositorio : IRepositorioGenerico<Pagamento>
{
    Task<IEnumerable<Pagamento>> PegarPagamentoPorUsuario(string usuarioId);
}
