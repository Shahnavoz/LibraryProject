using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;
using LibraryWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class BookLoanController(IBookLoanService bookLoanService):ControllerBase
{
    [HttpGet("All Loans")]
    public async Task<List<BookLoan>> GetAllLoansAsync()
    {
        return await bookLoanService.GetAllBookLoansAsync();
    }

    [HttpGet]
    public async Task<Response<BookLoan>> GetBookLoanByIdAsync(int id)
    {
        return await bookLoanService.GetBookLoanByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> AddBookLoanAsync(BookLoan bookLoan)
    {
        return await bookLoanService.AddBookLoanAsync(bookLoan);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateBookLoanAsync(BookLoan bookLoan)
    {
        return await bookLoanService.UpdateBookLoanAsync(bookLoan);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteBookLoanAsync(int id)
    {
        return await bookLoanService.DeleteBookLoanAsync(id);
    }
    
}