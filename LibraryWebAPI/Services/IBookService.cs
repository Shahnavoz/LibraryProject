using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;

namespace LibraryWebAPI.Services;

public interface IBookService
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Response<Book>> GetBookByIdAsync();
    Task<Response<string >> AddBookAsync(Book book);
    Task<Response<string>> UpdateBookAsync(Book book);
    Task<Response<string>> DeleteBookAsync(int id);
}