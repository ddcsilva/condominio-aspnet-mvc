using GerenciadorCondominios.BLL.Models;

namespace GerenciadorCondominios.DAL.Interfaces;

public interface IApartamentoRepositorio : IRepositorioGenerico<Apartamento>
{
    new Task<IEnumerable<Apartamento>> PegarTodos();

    Task<IEnumerable<Apartamento>> PegarApartamentoPeloUsuario(string usuarioId);
}
