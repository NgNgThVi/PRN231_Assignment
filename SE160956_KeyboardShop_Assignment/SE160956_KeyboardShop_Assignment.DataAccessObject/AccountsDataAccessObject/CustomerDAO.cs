using SE160956_KeyboardShop_Assignment.BussinessObject.DataAccess;
using SE160956_KeyboardShop_Assignment.BussinessObject.DbContexts;

namespace SE160956_KeyboardShop_Assignment.DataAccessObject.AccountsDataAccessObject
{
    public class CustomerDAO
    {
        private static CustomerDAO _instance;
        private readonly ApplicationDbContext _dbContext ;
        public CustomerDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new ApplicationDbContext();
            }
        }

        public static CustomerDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerDAO();
                }
                return _instance;
            }
        }
        public List<Customer> GetAllCustomers()
        {
            var listAcc = new List<Customer>();
            // 4. Customer
            try
            {
                listAcc = _dbContext.Customers.Where(a => a.Role == 4).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAcc;
        }

        public Customer FindCustomerByEmail(string email)
        {
            var acc = new Customer();
            try
            {
                acc = _dbContext.Customers.FirstOrDefault(c => c.EmailAddress == email && c.Role == 4);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public Customer FindCustomerById(string customerId)
        {
            var customer = new Customer();
            try
            {
                customer = _dbContext.Customers.SingleOrDefault(c => c.Id == Guid.Parse(customerId) && c.Role == 4);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public List<Customer> Search(string keyword)
        {
            var listCustomers = new List<Customer>();
            try
            {
                listCustomers = _dbContext.Customers
                    .Where(c => c.FullName.Contains(keyword))
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listCustomers;
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                _dbContext.Entry(customer).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            try
            {
                var customerToDelete = _dbContext
                    .Customers
                    .SingleOrDefault(c => c.Id == customer.Id);
                _dbContext.Customers.Remove(customerToDelete);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Customer> GetAllAccounts()
        {
            var listAcc = new List<Customer>();
            try
            {
                listAcc = _dbContext.Customers.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listAcc;
        }

        public Customer FindAccountByEmail(string email)
        {
            var acc = new Customer();
            try
            {
                acc = _dbContext.Customers.FirstOrDefault(c => c.EmailAddress == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public Customer Login(string email, string password)
        {
            var acc = new Customer();
            try
            {
                acc = _dbContext.Customers.FirstOrDefault(c => c.EmailAddress == email && c.AccountPassword == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }

        public void SaveAccount(Customer account)
        {
            try
            {
                _dbContext.Customers.Add(account);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
