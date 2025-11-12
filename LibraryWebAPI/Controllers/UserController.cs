using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;
using LibraryWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService):ControllerBase
{
    [HttpGet("AllUsers")]
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await userService.GetUsersAsync();
    } 
    [HttpGet]
    public async Task<Response<User>> GetUserByIdAsync(int id)
    {
        return await userService.GetUserAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> AddUserAsync(User user)
    {
        return await userService.AddUserAsync(user);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateUserAsync(User user)
    {
        return await userService.UpdateUserAsync(user);
    }
    [HttpDelete]
    public async  Task<Response<string>> DeleteUserAsync(int id)
    {
        return await userService.DeleteUserAsync(id);
    }
}