using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticalTestApi.Controllers;
using PracticalTestApi.Mappings;
using PracticalTestApi.Services;
using PracticalTestApi.Services.Dtos;
using System.Net;
using Xunit;

namespace PracticalTest.Tests
{
    public class UsersControllerTests
    {
        UsersController _controller;
        IUserService _userService;

        public UsersControllerTests()
        {
            // Arrange
            // Because UserService is in-memory service, so use it for testing.
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomMapping());
            });
            _userService = new UserService(config.CreateMapper());
            _controller = new UsersController(_userService);
        }

        [Fact]
        public void Should_Create_User_Successfull()
        {
            // Act
            var result = _controller.CreateUser(new CreateUserDto
            {
                Name = "User1",
                Age = 30,
                Address = "123 Roadway"
            });
            var createdObjectResult = result as ObjectResult;

            // Assert
            Assert.IsType<UserDto>(createdObjectResult.Value);
            Assert.Equal((int)HttpStatusCode.Created, createdObjectResult.StatusCode);
        }

        [Fact]
        public void Should_Update_User_Successfull()
        {
            // Arrange
            var createdResult = _controller.CreateUser(new CreateUserDto
            {
                Name = "User1",
                Age = 30,
                Address = "123 Roadway"
            });

            var createdObjectResult = createdResult as ObjectResult;
            var createdUser = createdObjectResult.Value as UserDto;

            // Act
            var updatedResult = _controller.UpdateUser(createdUser.Id, new UpdateUserDto
            {
                Name = "User updated",
                Age = 30,
                Address = "123 Test"
            });
            var updatedObjectResult = updatedResult as ObjectResult;
            var updatedUser  = updatedObjectResult.Value as UserDto;

            // Assert
            Assert.IsType<UserDto>(updatedObjectResult.Value);
            Assert.Equal((int)HttpStatusCode.Created, updatedObjectResult.StatusCode);
            Assert.Equal("User updated", updatedUser.Name);
        }
    }
}
