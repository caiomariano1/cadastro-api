using cadastro_api.Domain.Account;
using cadastro_api.DTOs;
using cadastro_api.Entities;
using cadastro_api.Models;
using cadastro_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO)
        {
            if(usuarioDTO == null) 
            {
                return BadRequest("Dados inválidos.");
            }

            var emailExiste = await _authenticateService.UserExists(usuarioDTO.Email);

            if(emailExiste) 
            {
                return BadRequest("Este E-mail já está cadastrado.");
            }

            var usuario = await _usuarioService.Incluir(usuarioDTO);
            if (usuario == null) 
            {
                return BadRequest("Ocorreu um erro ao cadastrar.");
            }

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);
            return new UserToken
            {
                Token = token
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Selecionar(LoginModel loginModel) 
        {
            var existe = await _authenticateService.UserExists(loginModel.Email);
            if(!existe)
            {
                return Unauthorized("Usuário não Existe.");
            }

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result) 
            {
                return Unauthorized("Usuário ou senha inválido.");
            }

            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }
    }
}
