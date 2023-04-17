using GerenciadorCondominios.BLL.Models;

namespace GerenciadorCondominios.DAL.Interfaces;

public interface IVeiculoRepositorio : IRepositorioGenerico<Veiculo>
{
    Task<IEnumerable<Veiculo>> PegarVeiculosPorUsuario(string usuarioId);
}
