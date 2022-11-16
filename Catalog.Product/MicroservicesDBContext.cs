using Catalog.Product.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Product; 
public class MicroservicesDBContext : DbContext
{
    public DbSet<Order> Orders {get;set;}
    public DbSet<Products> Products {get;set;}
    public DbSet<OrderDetail> OrderDetail {get;set;}
    
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<OrderDetail>(x=>
    {
        x.HasNoKey();
    });
}

    public MicroservicesDBContext(DbContextOptions<MicroservicesDBContext> options):base(options)
    {}
}