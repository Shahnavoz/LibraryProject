using System.Net;
using Dapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Entities;
using LibraryWebAPI.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Services;

public class UserService(ApplicationDbContext context):IUserService
{
    public async Task<List<User>> GetUsersAsync()
    {
        using var conn = context.GetConnection();
        conn.Open();
        string query = "select * from Users";
        var users=await conn.QueryAsync<User>(query);
        return users.ToList();
        

    }

    public async Task<Response<User>> GetUserAsync(int id)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query = "select * from Users where Id=@id";
            var user = await conn.QueryFirstOrDefaultAsync<User>(query, new { id });
            return user==null ? new Response<User>(HttpStatusCode.InternalServerError,"Internal Server Error!")
                : new Response<User>(HttpStatusCode.OK,"User found",user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<User>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> AddUserAsync(User user)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query="insert into users (FullName,Email,RegisteredAt) values (@FullName,@Email,@RegisteredAt)";
            var result = await conn.ExecuteAsync(query,user);
            return result > 0 ? new Response<string>(HttpStatusCode.OK,"User added")
                : new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> UpdateUserAsync(User user)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query="update users set Fullname=@FullName,Email=@Email,RegisteredAt=@RegisteredAt where Id=@Id";
            var result = await conn.ExecuteAsync(query,user);
            return result > 0 ? new Response<string>(HttpStatusCode.OK,"User updated")
                : new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }

    public async Task<Response<string>> DeleteUserAsync(int id)
    {
        try
        {
            await using var conn = context.GetConnection();
            conn.Open();
            string query = "delete from users where Id=@Id";
            var result = await conn.ExecuteAsync(query, new { id });
            return result > 0 ? new Response<string>(HttpStatusCode.OK,"User deleted")
                : new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error!");
        }
    }
}