using Microsoft.EntityFrameworkCore;

namespace CRUDOperationInDotNetCore.Models
{
    public class BrandContext : DbContext
    {

        // This is a constructor for the BrandContext class. It accepts a parameter of type DbContextOptions<BrandContext>.These options are typically used to configure the behavior and connection settings of the database context.
        //Inside the constructor, base(options) is called.This invokes the constructor of the base class (DbContext) with the provided options, initializing the database context with the specified configuration.

        public BrandContext(DbContextOptions<BrandContext> options) : base(options) { }

        // This line defines a property named Brands.The DbSet<T> property is used to specify the entity type (in this case, Brand) that you want to interact with in the database.The DbSet property represents a collection of entities in the database table.
        //By including this property in your context class, you are telling Entity Framework Core that you want to work with the Brand entity in your database.You can use this property to perform database operations like querying, inserting, updating, and deleting records in the Brands table.
        public DbSet<Brand> Brands { get; set; }
    }
}
