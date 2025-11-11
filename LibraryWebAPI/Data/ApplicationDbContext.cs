using Npgsql;

namespace LibraryWebAPI.Data;

public class ApplicationDbContext
{
    private readonly string _connectionString="Host=localhost;Port=5432;Database=library_db;Username=postgres;Password=shamina1234";
    
    public NpgsqlConnection GetConnection()=> new NpgsqlConnection(_connectionString);
}