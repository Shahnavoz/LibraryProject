using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;
using LibraryWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService  service): ControllerBase
{

    [HttpGet("GetAllBooks")]
    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await service.GetAllBooksAsync();
    }
    [HttpGet]
    public async Task<Response<Book>> GetBookByIdAsync()
    {
        return await service.GetBookByIdAsync();
    }

    [HttpPost]
    public async Task<Response<string>> AddBookAsync(Book book)
    {
        return await service.AddBookAsync(book);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateBookAsync(Book book)
    {
        return await service.UpdateBookAsync(book);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteBookAsync(int id)
    {
        return await service.DeleteBookAsync(id);
    }
    
}