using PracticalTestApi.Models;
using PracticalTestApi.Services.Dtos;
using System.Collections.Generic;

namespace PracticalTestApi.Services
{
    public interface IUserService
    {
        UserDto GetUser(int id);
        IEnumerable<UserDto> GetAllUsers();
        UserDto CreateUser(CreateUserDto input);
        UserDto UpdateUser(UpdateUserDto input);
        void DeleteUser(int id);
    }
}