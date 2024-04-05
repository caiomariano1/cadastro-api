using cadastro_api.Data;
using cadastro_api.Models;
using cadastro_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cadastro_api.Repositories
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly SistemaContatosDbContext _dbContext;
        public ContatoRepositorio(SistemaContatosDbContext sistemaContatosDbContext)
        {
            _dbContext = sistemaContatosDbContext;
        }

        public async Task<List<Contato>> GetAllContacts()
        {
            return await _dbContext.Contatos.ToListAsync();
        }

        public async Task<Contato> GetById(int id)
        {
            return await _dbContext.Contatos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Contato> Add(Contato contato)
        {
            await _dbContext.Contatos.AddAsync(contato);
            await _dbContext.SaveChangesAsync();

            return contato;
        }

        public async Task<Contato> Update(Contato contato, int id)
        {
            Contato contactById = await GetById(id);

            if (contactById == null)
            {
                throw new Exception($"Contato Para o ID: {id} não foi encontrado no banco de dados.");
            }

            contactById.Nome = contato.Nome;
            contactById.Tel = contato.Tel;

            _dbContext.Contatos.Update(contactById);
            await _dbContext.SaveChangesAsync();

            return contactById;
        }

        public async Task<bool> Delete(int id)
        {
            Contato contactById = await GetById(id);

            if (contactById == null)
            {
                throw new Exception($"Contato Para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Contatos.Remove(contactById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        
    }
}
