using GerenciadorCondominios.BLL.Models;

namespace GerenciadorCondominios.DAL.Interfaces;

public interface IAluguelRepositorio : IRepositorioGenerico<Aluguel>
{
    bool AluguelJaExiste(int mesId, int ano);

    new Task<IEnumerable<Aluguel>> PegarTodos();

    Task<IEnumerable<int>> PegarTodosAnos();
}
