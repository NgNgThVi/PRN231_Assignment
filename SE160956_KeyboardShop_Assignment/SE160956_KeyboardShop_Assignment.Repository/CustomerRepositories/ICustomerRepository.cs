using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;

namespace SE160956_KeyboardShop_Assignment.Repository.CustomerRepositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerByEmail(string email);
        Customer Login(string email, string password);
        List<Customer> GetCustomers();
        void SaveCustomer(Customer Customer);
      //  List<Customer> GetCustomers();
        List<Customer> Search(string keyword);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
      //  Customer GetCustomerByEmail(string email);
        Customer GetCustomerById(string id);
    }
}
