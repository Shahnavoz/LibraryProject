using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;

namespace LibraryWebAPI.Services;

public interface IUserService
{
    Task<List<User>> GetUsersAsync();
    Task<Response<User>> GetUserAsync(int id);
    Task<Response<string>> AddUserAsync(User user); 
    Task<Response<string>> UpdateUserAsync(User user);
    Task<Response<string>> DeleteUserAsync(int id);
}