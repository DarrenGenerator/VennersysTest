using TestAPIs.CustomerDb.Interfaces;
using TestAPIs.Domain;
using TestAPIs.Interfaces;

namespace TestAPIs.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerContext customerContext;

        public CustomerServices(ICustomerContext customerContext)
        {
            this.customerContext = customerContext;
        }

        public List<Customer> GetAll()
        {
            return customerContext.Customers.ToList();
        }

        public List<Customer> Search(string? searchFilter = "")
        {
            if (searchFilter == null)
            {
                return new List<Customer>();
            }
            else
            {
                return customerContext.Customers.Where(c => c.FirstName.ToLower().Contains(searchFilter) || c.LastName.ToLower().Contains(searchFilter)).ToList();
            }
        }

        public Customer GetById(int id)
        {
            return customerContext.Customers.Where(c => c.ID == id).FirstOrDefault() ?? new();
        }

        public int Add(Customer customer)
        {
            customerContext.Customers.Add(customer);
            return customerContext.SaveChanges();
        }

        public int Update(Customer customer)
        {
            customerContext.Customers.Update(customer);
            return customerContext.SaveChanges();
        }

    }
}
