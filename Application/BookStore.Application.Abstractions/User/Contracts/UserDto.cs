using System;
namespace BookStore.Application.Abstractions.User.Contracts
{
    public record UserDto(string UserName, DateTime? Birthday);
}