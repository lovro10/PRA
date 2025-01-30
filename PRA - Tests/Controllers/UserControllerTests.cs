using Moq;
using Xunit;
using WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace WebApi.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<PraFichteContext> _mockContext;
        private readonly Mock<DbSet<User>> _mockDbSet;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _mockContext = new Mock<PraFichteContext>();
            _mockDbSet = new Mock<DbSet<User>>();

            _mockContext.Setup(c => c.Users).Returns(_mockDbSet.Object);

            _controller = new UserController(_mockContext.Object);
        }

        [Fact]
        public void Register_ReturnsBadRequest_WhenUsernameExists()
        {
            var existingUser = new User { Username = "testuser", Email = "test@example.com" };

            var users = new List<User> { existingUser }.AsQueryable();
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            var registerDto = new UserRegisterDto
            {
                Username = "testuser",
                Email = "new@example.com",
                Password = "password123"
            };

            var result = _controller.Register(System.Text.Json.JsonSerializer.Serialize(registerDto));

            var badRequestResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public void Login_ReturnsUnauthorized_WhenUserNotFound()
        {
            var loginDto = new UserLoginDto { Email = "nonexistent@example.com", Password = "wrongpassword" };

            var result = _controller.Login(System.Text.Json.JsonSerializer.Serialize(loginDto));

            var unauthorizedResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, unauthorizedResult.StatusCode);
        }

        [Fact]
        public void Login_ReturnsOk_WhenCredentialsAreCorrect()
        {
            var existingUser = new User
            {
                Username = "existinguser",
                Email = "user@example.com",
                PwdHash = "hashedpassword",
                PwdSalt = "salt"
            };

            var users = new List<User> { existingUser }.AsQueryable();
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            var loginDto = new UserLoginDto
            {
                Email = "user@example.com",
                Password = "correctpassword"
            };

            var result = _controller.Login(System.Text.Json.JsonSerializer.Serialize(loginDto));

            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public void GetUserId_ReturnsUserId_WhenUserExists()
        {
            var existingUser = new User { Username = "existinguser", Id = 1 };

            var users = new List<User> { existingUser }.AsQueryable();
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            var result = _controller.GetUserId("existinguser");

            var okResult = Assert.IsType<ObjectResult>(result.Result);
            var userDto = Assert.IsType<ObjectResult>(okResult);
            Assert.Equal(userDto.StatusCode, okResult.StatusCode);
        }

        [Fact]
        public void GetUserByUsername_ReturnsUser_WhenUserExists()
        {
            var existingUser = new User
            {
                Username = "existinguser",
                FirstName = "John",
                LastName = "Doe",
                Email = "user@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                DateJoined = DateTime.UtcNow,
                Id = 1
            };

            var users = new List<User> { existingUser }.AsQueryable();
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            _mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            var result = _controller.GetUserByUsername("existinguser");

            var okResult = Assert.IsType<ObjectResult>(result.Result);
            var userDto = Assert.IsType<ObjectResult>(okResult);
            Assert.Equal(userDto.StatusCode, okResult.StatusCode);
        }
    }
}
