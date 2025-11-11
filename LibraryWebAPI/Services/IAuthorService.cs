using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;

namespace LibraryWebAPI.Services;

public interface IAuthorService
{
    Task<List<Author>> GetAllAuthorsAsync();
    Task<Response<Author>> GetAuthorByIdAsync(int id);
    Task<Response<string>> AddAuthorAsync(Author author);
    Task<Response<string>> UpdateAuthorAsync(Author author);
    Task<Response<string>> DeleteAuthorAsync(int id);
    
}