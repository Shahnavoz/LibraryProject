using System.Net;
using Dapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;

namespace LibraryWebAPI.Services;

public class BookLoanService(ApplicationDbContext context):IBookLoanService
{
    public async Task<List<BookLoan>> GetAllBookLoansAsync()
    {
        using var conn = context.GetConnection();
        await conn.OpenAsync();
        string query = "select * from bookloan";
        var bookLoans = await conn.QueryAsync<BookLoan>(query);
        return bookLoans.ToList();
    }

    public async Task<Response<BookLoan>> GetBookLoanByIdAsync(int id)
    {
        try
        {
            using var conn = context.GetConnection();
            await conn.OpenAsync();
            string query = "select * from bookloan where id = @id";
            var bookLoan = await conn.QueryFirstOrDefaultAsync<BookLoan>(query, new { id });
            return bookLoan==null ? new Response<BookLoan>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<BookLoan>(HttpStatusCode.OK,"Book Found!",bookLoan);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<BookLoan>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> AddBookLoanAsync(BookLoan bookLoan)
    {
        try
        {
            using var conn = context.GetConnection();
            await conn.OpenAsync();
            string query = "insert into bookloan(BookId,UserId) values (@bookId,@userId)";
            var result= await conn.ExecuteAsync(query,bookLoan);
            return result == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<string>(HttpStatusCode.OK,"Book Added!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> UpdateBookLoanAsync(BookLoan bookLoan)
    {
        try
        {
            using var conn = context.GetConnection();
            await conn.OpenAsync();
            string query ="update bookloan  set userId = @userId,bookId = @bookId where id = @id";
            var result= await conn.ExecuteAsync(query,bookLoan);
            return result == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<string>(HttpStatusCode.OK,"Book Updated!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> DeleteBookLoanAsync(int id)
    {
        try
        {
            using var conn = context.GetConnection();
            await conn.OpenAsync();
            string query = "delete from bookloan where id = @id";
            var result= await conn.ExecuteAsync(query, new { id });
            return result == 0 ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
               : new Response<string>(HttpStatusCode.OK,"Book Deleted!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> LoanBookAsync(int userId, int bookId)
    {
        try
        {
            using var conn = context.GetConnection();
            await conn.OpenAsync();
            string user="select * from bookloan where userId = @userId";
            string book="select * from bookloan where bookId = @bookId";
            var exists=await conn.QueryFirstOrDefaultAsync<BookLoan>(user, book);
            return exists==null ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<string>(HttpStatusCode.OK,"Book Loan Found!");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public Task<Response<string>> ReturnBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }
}