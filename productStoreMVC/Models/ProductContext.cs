using Microsoft.EntityFrameworkCore;


namespace productStoreMVC.models{

public class ProductContext:DbContext{

    public ProductContext(DbContextOptions<ProductContext> options):base(options){}

    public DbSet<Product> Product {get; set;}
    public DbSet<Comment> Comment { get; set; }



    }

}