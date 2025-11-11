using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;
using LibraryWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService):ControllerBase
{
    [HttpGet("AllAuthors")]
    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        return await authorService.GetAllAuthorsAsync();
    }

    [HttpGet("Author/{id}")]
    public async Task<Response<Author>> GetAuthorByIdAsync(int id)
    {
        return await authorService.GetAuthorByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> AddAuthorAsync(Author author)
    {
        return await authorService.AddAuthorAsync(author);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAuthorAsync(Author author)
    {
        return await authorService.UpdateAuthorAsync(author);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAuthorAsync(int id)
    {
        return await authorService.DeleteAuthorAsync(id);
    }
    
    
}