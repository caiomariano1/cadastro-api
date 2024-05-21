using cadastro_api.Data;
using cadastro_api.Entities;
using cadastro_api.Models;
using cadastro_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cadastro_api.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaContatosDbContext _dbContext;
        public UsuarioRepositorio(SistemaContatosDbContext sistemaContatosDbContext)
        {
            _dbContext = sistemaContatosDbContext;
        }

        public async Task<Usuario> Alterar(Usuario usuario)
        {
            _dbContext.Usuario.Update(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Excluir(int id)
        {
            var usuario = await _dbContext.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _dbContext.Usuario.Remove(usuario);
                await _dbContext.SaveChangesAsync();

                return usuario;
            }

            return null;
        }

        public async Task<Usuario> Incluir(Usuario usuario)
        {
            _dbContext.Usuario.Add(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> SelecionarAsync(int id)
        {
            return await _dbContext.Usuario.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> SelecionarTodosAsync()
        {
            return await _dbContext.Usuario.ToListAsync();
        }


    }
}

