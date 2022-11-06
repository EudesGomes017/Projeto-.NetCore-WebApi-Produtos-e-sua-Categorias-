using Flunt.Notifications;
using IwantApp.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace IwantApp.Infra.Data;

public class ApplicationDbContext : DbContext
{
    //nome das tabelas  
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options) { }
    
    /*modelando com fluenteApi*/
    protected override void OnModelCreating(ModelBuilder builder)
    {

        //ignorando a classe da notfication
        builder.Ignore<Notification>();

        builder.Entity<Product>()
            .Property(p => p.Name).IsRequired();

        builder.Entity<Product>()
            .Property(p => p.Description).HasMaxLength(255);

        builder.Entity<Category>()
            .Property(c => c.Name).IsRequired();

      


    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        /*criando uma convensão*/
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
     



}
