using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.DataAccessObject.AccountsDataAccessObject;

namespace SE160956_KeyboardShop_Assignment.Repository.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly CustomerDAO _customerDAO;
        public CustomerRepository()
        {
            _customerDAO = new CustomerDAO();
        }
        public Customer GetCustomerByEmail(string email)
        {
            return _customerDAO.FindCustomerByEmail(email);
        }

        public Customer Login(string email, string password)
        {
            return _customerDAO.Login(email, password);
        }

        public List<Customer> GetCustomers()
        {
            return _customerDAO.GetAllCustomers();
        }

        public void SaveCustomer(Customer Customer)
        {
            _customerDAO.SaveAccount(Customer);
        }
        public void DeleteCustomer(Customer customer)
        {
            _customerDAO.DeleteCustomer(customer);
        }

        public Customer GetCustomerById(string id)
        {
            return _customerDAO.FindCustomerById(id);
        }

        public List<Customer> Search(string keyword)
        {
            return _customerDAO.Search(keyword);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerDAO.UpdateCustomer(customer);
        }
    }
}
