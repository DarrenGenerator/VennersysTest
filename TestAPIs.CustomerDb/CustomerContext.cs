using Microsoft.EntityFrameworkCore;
using TestAPIs.CustomerDb.Interfaces;
using TestAPIs.Domain;

namespace TestAPIs.CustomerDb
{
    public class CustomerContext : DbContext, ICustomerContext
    {
        private readonly bool inMemory = false;

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (inMemory) return;

            optionsBuilder
                .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = TestAPIs.Customers")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            ;
        }

        public CustomerContext() { }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) 
        {
            inMemory = true;
        }
    }
}