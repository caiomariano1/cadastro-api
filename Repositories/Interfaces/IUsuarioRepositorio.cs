using cadastro_api.Entities;
using cadastro_api.Models;

namespace cadastro_api.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> Incluir(Usuario usuario);
        Task<Usuario> Alterar(Usuario usuario);
        Task<Usuario> Excluir(int id);
        Task<Usuario> SelecionarAsync(int id);
        Task<List<Usuario>> SelecionarTodosAsync();
    }
}
