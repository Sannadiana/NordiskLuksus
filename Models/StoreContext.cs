using Microsoft.EntityFrameworkCore;

namespace NordiskLuksusMVC.Models{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options){}
        public DbSet<NordiskLuksusMVC.Models.Product> Product{get; set;}
    }
}