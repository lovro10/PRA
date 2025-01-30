using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class UserControllerTests
{
    private readonly PraFichteContext _context;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        var options = new DbContextOptionsBuilder<PraFichteContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new PraFichteContext(options);
        _controller = new UserController(_context);
    }

    [Fact]
    public void Register_UserAlreadyExists_ReturnsBadRequest()
    {
        var userDto = new UserRegisterDto { Username = "existingUser", Password = "pass123" };
        _context.Users.Add(new User { Username = "existingUser" });
        _context.SaveChanges();

        var json = JsonSerializer.Serialize(userDto);
        var result = _controller.Register(json) as BadRequestObjectResult;

        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void Login_UserNotFound_ReturnsUnauthorized()
    {
        var loginDto = new UserLoginDto { Email = "nonexistent@user.com", Password = "wrongpass" };
        var json = JsonSerializer.Serialize(loginDto);

        var result = _controller.Login(json) as UnauthorizedObjectResult;

        Assert.NotNull(result);
        Assert.Equal(401, result.StatusCode);
    }

    [Fact]
    public void GetUserByUsername_UserExists_ReturnsUser()
    {
        var user = new User { Id = 1, Username = "testuser", Email = "test@example.com" };
        _context.Users.Add(user);
        _context.SaveChanges();

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
        _context.Users.Add(user);
        _context.SaveChanges();

        var result = _controller.ConfirmAccount(1) as RedirectResult;

        Assert.NotNull(result);
        Assert.Equal("http://localhost:5233/AccountConfirmation.html", result.Url);
        Assert.True(_context.Users.First().EmailConfirmed);
    }
}