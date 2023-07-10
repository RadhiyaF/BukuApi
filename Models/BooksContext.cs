using Microsoft.EntityFrameworkCore;

namespace crudbuku.Models;

public class BooksContext : DbContext
{
    public BooksContext()
    {
        
    }
    public BooksContext(DbContextOptions<BooksContext> options)
    : base(options)
    {
        
    }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseMySql(connectionString: @"server=localhost;database=BookStoreDb2;uid=root;password=;", 
        //    new MySqlServerVersion(new Version(10, 4, 17)), 
        //    mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend));
        var connectionString = "server=localhost;database=buku;user=root;password='' ";
        var serverVersion = new MySqlServerVersion(new Version(10, 4, 28));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }   
    
  

    public DbSet<Buku> Buku { get; set; } = null!;
};