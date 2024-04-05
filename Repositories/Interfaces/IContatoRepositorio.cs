using cadastro_api.Models;

namespace cadastro_api.Repositories.Interfaces
{
    public interface IContatoRepositorio
    {
        Task<List<Contato>> GetAllContacts();
        Task<Contato> GetById(int id);
        Task<Contato> Add(Contato contato);
        Task<Contato> Update(Contato contato, int id);
        Task<bool> Delete(int id);
    }
}
