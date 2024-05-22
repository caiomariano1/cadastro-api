using AutoMapper;
using cadastro_api.DTOs;
using cadastro_api.Entities;
using cadastro_api.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace cadastro_api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepositorio repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Alterar(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var usuarioAlterado = await _repository.Alterar(usuario);
            return _mapper.Map<UsuarioDTO>(usuarioAlterado);
        }

        public async Task<UsuarioDTO> Excluir(int id)
        {
            var usuario = await _repository.Excluir(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            if(usuarioDTO.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioDTO.Password));
                byte[] passwordSalt = hmac.Key;

                usuario.AlterarSenha(passwordHash, passwordSalt);
            }

            var usuarioIncluido = await _repository.Incluir(usuario);
            return _mapper.Map<UsuarioDTO>(usuarioIncluido);
        }

        public async Task<UsuarioDTO> SelecionarAsync(int id)
        {
            var usuario = await _repository.SelecionarAsync(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<List<UsuarioDTO>> SelecionarTodosAsync()
        {
            var usuarios = await _repository.SelecionarTodosAsync();
            return _mapper.Map<List<UsuarioDTO>>(usuarios);
        }
    }
}
