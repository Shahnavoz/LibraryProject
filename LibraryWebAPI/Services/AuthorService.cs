using System.Net;
using Dapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;

namespace LibraryWebAPI.Services;

public class AuthorService(ApplicationDbContext  context): IAuthorService

{
    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        await using var conn = context.GetConnection();
        conn.Open();
        string query = "SELECT * FROM Authors";
        var authors=await conn.QueryAsync<Author>(query);
        return authors.ToList();
    }

    public async Task<Response<Author>> GetAuthorByIdAsync(int id)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query = "SELECT * FROM Authors WHERE Id = @Id";
            var author = await conn.QueryFirstOrDefaultAsync<Author>(query, new { Id = id });
            return author == null
                ? new Response<Author>(HttpStatusCode.InternalServerError, "Internal Server Error!", author):
                new Response<Author>(HttpStatusCode.OK,"Author Found!", author);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<Author>(HttpStatusCode.InternalServerError, "Internal Server Error!", null);
        }
    }

    public async Task<Response<string>> AddAuthorAsync(Author author)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query = "INSERT INTO Authors (FullName,BirthDate,Country) VALUES (@FullName,@BirthDate,@Country)";
            var result = await conn.ExecuteAsync(query,author);
            return result==0 ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<string>(HttpStatusCode.OK, "Author Added!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error!");
        }
    }

    public async Task<Response<string>> UpdateAuthorAsync(Author author)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query="Update authors set FullName = @FullName, BirthDate = @BirthDate, Country = @Country where Id = @Id";
            var result = await conn.ExecuteAsync(query,author);
            return result==0 ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<string>(HttpStatusCode.OK, "Author Updated!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error!");
        }
    }

    public async Task<Response<string>> DeleteAuthorAsync(int id)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query = "DELETE FROM Authors WHERE Id = @Id";
            var result = await conn.ExecuteAsync(query, new { Id = id });
            return result==0 ? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<string>(HttpStatusCode.OK,"Author Deleted!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error!");
        }
    }
}