using cadastro_api.DTOs;
using cadastro_api.Entities;

namespace cadastro_api.Repositories.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Alterar(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Excluir(int id);
        Task<UsuarioDTO> SelecionarAsync(int id);
        Task<List<UsuarioDTO>> SelecionarTodosAsync();
    }
}
