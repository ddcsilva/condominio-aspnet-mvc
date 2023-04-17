using GerenciadorCondominios.BLL.Models;

namespace GerenciadorCondominios.DAL.Interfaces;

public interface IMesRepositorio : IRepositorioGenerico<Mes>
{
    new Task<IEnumerable<Mes>> PegarTodos();
}
