using System.Net;
using Dapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Services;

public class BookService(ApplicationDbContext context):IBookService
{
    public async Task<List<Book>> GetAllBooksAsync()
    {
        await using var conn = context.GetConnection();
        conn.Open();
        string query = "SELECT * FROM books";
        var books=await conn.QueryAsync<Book>(query);
        return books.ToList();
    }

    public async Task<Response<Book>> GetBookByIdAsync()
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query = "SELECT * FROM authors where id = @id";
            var result = await conn.QueryFirstOrDefaultAsync(query);
            return result==null ? new Response<Book>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<Book>(HttpStatusCode.OK,"Book Found Successfully!",result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<Book>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> AddBookAsync(Book book)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query="insert into books(Title,PublishedYear,Genre,AuthorId) values(@Title,@PublishedYear,@Genre,@AuthorId)";
            var result = await conn.QueryFirstOrDefaultAsync(query,book);
            
            return result==null? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<string>(HttpStatusCode.OK,"Book Added Successfully!",result);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> UpdateBookAsync(Book book)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query="update books set Title=@Title,PublishedYear=@PublishedYear where id = @id";
            var result = await conn.QueryFirstOrDefaultAsync(query,book);
            return result==null? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                :  new Response<string>(HttpStatusCode.OK,"Book Updated Successfully!",result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> DeleteBookAsync(int id)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query = "delete from books where id = @id";
            var result = await conn.QueryFirstOrDefaultAsync(query,id);
            return result==null? new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<string>(HttpStatusCode.OK,"Book Deleted Successfully!",result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }
}