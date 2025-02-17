﻿using Transactly.Data.Models;

namespace Transactly.Core.Interfaces
{
    public interface IUserService : IBaseService
    {
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByPhoneNumber(string phoneNumber);
        Task<User?> GetUserByUserTag(string userTag);
        Task<User?> GetUserByToken(Guid token);
    }
}
