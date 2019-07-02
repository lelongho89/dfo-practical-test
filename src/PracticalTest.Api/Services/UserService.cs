using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PracticalTestApi.Exceptions;
using PracticalTestApi.Models;
using PracticalTestApi.Services.Dtos;

namespace PracticalTestApi.Services
{
    public class UserService : IUserService
    {
        // Create in-memory data.
        private List<User> _users = new List<User>
        {
            new User(1, "Doe John", 35, "123 Main Street"),
            new User(2, "Eden Hazard", 28, "345 Main Street"),
            new User(3, "Steven E Fontenot", 51, "3199  Kenwood Place"),
            new User(4, "Charles J Hawkins", 23, "1022  Tator Patch Road"),
            new User(5, "George H Folsom", 38, "2908  Progress Way"),
            new User(6, "Jackie E Rutledge", 45, "4791  Roane Avenue"),
            new User(7, "Charles A Holmes", 27, "2441  Hannah Street"),
            new User(8, "Dale L Lauver", 32, "1437  Stoney Lonesome Road"),
            new User(9, "David E Hickey", 25, "252  Brannon Street"),
            new User(10, "Jack J Call", 19, "4748  Findley Avenue"),
        };
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public UserDto CreateUser(CreateUserDto input)
        {
            var createdUser = _mapper.Map<User>(input);
            createdUser.Id = _users.Max(x => x.Id) + 1;
            _users.Add(createdUser);

            return _mapper.Map<User, UserDto>(createdUser);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _mapper.Map<List<User>, List<UserDto>>(_users).AsEnumerable();
        }

        public UserDto GetUser(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new DomainNotFoundException(id.ToString(), typeof(User));
            }

            return _mapper.Map<User, UserDto>(user);
        }

        public UserDto UpdateUser(UpdateUserDto input)
        {
            var index = FindIndexById(input.Id);
            if (index < 0)
            {
                throw new DomainNotFoundException(input.Id.ToString(), typeof(User));
            }

            var updatedUser = _users[index];
            updatedUser = _mapper.Map(input, updatedUser);
            _users[index] = updatedUser;

            return _mapper.Map<User, UserDto>(updatedUser);
        }

        public void DeleteUser(int id)
        {
            var index = FindIndexById(id);
            if (index < 0)
            {
                throw new DomainNotFoundException(id.ToString(), typeof(User));
            }

            _users.RemoveAt(index);
        }

        private int FindIndexById(int id)
        {
            return _users.FindIndex(x => x.Id == id);
        }
    }
}
