using Azure;
using Microsoft.EntityFrameworkCore;
using TestAPIs.Domain;

namespace TestAPIs.CustomerDb.Interfaces
{
    public interface ICustomerContext : IDisposable
    {
        DbSet<Customer> Customers { get; set; }

        int SaveChanges();
    }
}