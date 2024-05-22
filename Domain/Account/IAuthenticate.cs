﻿using cadastro_api.Entities;

namespace cadastro_api.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string senha);
        Task<bool> UserExists(string email);
        public string GenerateToken(int id, string email);
        public Task<Usuario> GetUserByEmail(string email);
    }
}
