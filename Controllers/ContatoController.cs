using cadastro_api.Models;
using cadastro_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contato>>> GetAllContacts()
        {
            List<Contato> contatos = await _contatoRepositorio.GetAllContacts();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetById(int id)
        {
            Contato contato = await _contatoRepositorio.GetById(id);
            return Ok(contato);
        }

        [HttpPost]
        public async Task<ActionResult<Contato>> Post([FromBody] Contato contatoModel)
        {
            Contato contato = await _contatoRepositorio.Add(contatoModel);
            return Ok(contato);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contato>> Put([FromBody] Contato contatoModel, int id)
        {
            contatoModel.Id = id;
            Contato contato = await _contatoRepositorio.Update(contatoModel, id);
            return Ok(contato);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contato>> Delete(int id)
        {
            bool deleted = await _contatoRepositorio.Delete(id);
            return Ok(deleted);
        }
    }
}
