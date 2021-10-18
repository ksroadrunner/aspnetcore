using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Application.Abstractions.User
{
    public interface IUserService
    {
        Task<Contracts.UserDto> Login(string userName, string password);
        Task<List<Domain.User>> GetAllUsers();
    }
}