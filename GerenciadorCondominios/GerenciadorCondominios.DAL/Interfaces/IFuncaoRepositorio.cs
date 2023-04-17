using GerenciadorCondominios.BLL.Models;

namespace GerenciadorCondominios.DAL.Interfaces;

public interface IFuncaoRepositorio : IRepositorioGenerico<Funcao>
{
    Task AdicionarFuncao(Funcao funcao);

    new Task Atualizar(Funcao funcao);
}
