using TestAPIs.Domain;

namespace TestAPIs.Interfaces
{
    public interface ICustomerServices
    {
        int Add(Customer customer);
        List<Customer> GetAll();
        Customer GetById(int id);
        List<Customer> Search(string? searchFilter = "");
        int Update(Customer customer);

        int Delete(Customer customer);
    }
}