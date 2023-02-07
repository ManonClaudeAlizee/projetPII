using Microsoft.EntityFrameworkCore;
using projetPII.Models;

namespace projetPII.Data;

public class projetPIIContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public string DbPath { get; private set; }

    public projetPIIContext()
    {
        // Path to SQLite database file
        DbPath = "projetPII.db";
    }

    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }

}