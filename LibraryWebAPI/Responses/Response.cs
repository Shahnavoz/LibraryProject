using System.Net;

namespace LibraryWebAPI.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string> Description { get; set; }
    public T Data { get; set; }

    public Response(HttpStatusCode statusCode, string message, T data)
    {
        StatusCode = (int)statusCode;
        Description.Add(message);
        Data = data;
    }

    // Конструктор: статус + список сообщений + данные
    public Response(HttpStatusCode statusCode, List<string> messages, T data)
    {
        StatusCode = (int)statusCode;
        Description = messages ?? new List<string>();
        Data = data;
    }

    // Конструктор: статус + одно сообщение (без данных)
    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Description.Add(message);
    }

    // Конструктор: статус + список сообщений (без данных)
    public Response(HttpStatusCode statusCode, List<string> messages)
    {
        StatusCode = (int)statusCode;
        Description = messages ?? new List<string>();
    }
    
    
    
}