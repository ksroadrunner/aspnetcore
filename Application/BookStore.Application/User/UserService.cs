using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Application.Abstractions.User;
using BookStore.Application.Abstractions.User.Contracts;
using BookStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.User
{
    public class UserService : IUserService
    {
        private readonly DataContext context;
        public UserService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Domain.User>> GetAllUsers()
        {
            return await this.context.Set<Domain.User>()
                                     .AsQueryable()
                                     .ToListAsync();
        }

        public async Task<UserDto> Login(string userName, string password)
        {
            var entity = await this.context.Set<Domain.User>()
                                            .AsQueryable()
                                            .FirstOrDefaultAsync(a => a.UserName == userName
                                                                      && a.Password == password);
            if (entity == null)
                return null;

            return new UserDto(entity.UserName, entity.Birthday);
        }
    }
}