using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;

namespace LibraryWebAPI.Services;

public interface IBookLoanService
{
    Task<List<BookLoan>> GetAllBookLoansAsync();
    Task<Response<BookLoan>> GetBookLoanByIdAsync(int id);
    Task<Response<string>> AddBookLoanAsync(BookLoan bookLoan);
    Task<Response<string>> UpdateBookLoanAsync(BookLoan bookLoan);
    Task<Response<string>> DeleteBookLoanAsync(int id);
    Task<Response<string>> LoanBookAsync(int userId,int bookId);
    Task<Response<string>> ReturnBookAsync(int bookId);
}