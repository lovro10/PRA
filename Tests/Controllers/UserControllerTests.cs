using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class UserControllerTests
{
    private readonly Mock<PraFichteContext> _mockContext;
    private readonly UserController _controller;
    private readonly Mock<DbSet<User>> _mockUserSet;

    public UserControllerTests()
    {
        _mockContext = new Mock<PraFichteContext>();
        _mockUserSet = new Mock<DbSet<User>>();
        _mockContext.Setup(c => c.Users).Returns(_mockUserSet.Object);
        _controller = new UserController(_mockContext.Object);
    }

    [Fact]
    public void Register_UserAlreadyExists_ReturnsBadRequest()
    {
        var userDto = new UserRegisterDto { Username = "existingUser", Password = "pass123" };
        var json = JsonSerializer.Serialize(userDto);

        _mockUserSet.Setup(x => x.Any(It.IsAny<Func<User, bool>>())).Returns(true);

        var result = _controller.Register(json) as BadRequestObjectResult;

        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void Login_UserNotFound_ReturnsUnauthorized()
    {
        var loginDto = new UserLoginDto { Email = "nonexistent@user.com", Password = "wrongpass" };
        var json = JsonSerializer.Serialize(loginDto);

        _mockUserSet.Setup(x => x.FirstOrDefault(It.IsAny<Func<User, bool>>())).Returns((User)null);

        var result = _controller.Login(json) as UnauthorizedObjectResult;

        Assert.NotNull(result);
        Assert.Equal(401, result.StatusCode);
    }

    [Fact]
    public void GetUserByUsername_UserExists_ReturnsUser()
    {
        var user = new User { Id = 1, Username = "testuser", Email = "test@example.com" };
        _mockUserSet.Setup(x => x.FirstOrDefault(It.IsAny<Func<User, bool>>())).Returns(user);

        var result = _controller.GetUserByUsername("testuser") as OkObjectResult;

        Assert.NotNull(result);
        var userDto = result.Value as UserDto;
        Assert.NotNull(userDto);
        Assert.Equal(user.Id, userDto.Id);
        Assert.Equal(user.Username, userDto.Username);
    }

    [Fact]
    public void ConfirmAccount_UserExists_UpdatesEmailConfirmed()
    {
        var user = new User { Id = 1, EmailConfirmed = false };
        _mockUserSet.Setup(x => x.FirstOrDefault(It.IsAny<Func<User, bool>>())).Returns(user);

        var result = _controller.ConfirmAccount(1) as RedirectResult;

        Assert.NotNull(result);
        Assert.Equal("http://localhost:5233/AccountConfirmation.html", result.Url);
        Assert.True(user.EmailConfirmed);
    }
}
