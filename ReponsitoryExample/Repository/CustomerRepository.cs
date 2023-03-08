using System.Linq.Expressions;
using ReponsitoryExample.Model;

namespace ReponsitoryExample.Repository
{
    public class CustomerRepository : Repository<Customer>, iCustomer<Customer>
    {
        public CustomerRepository(AppDBContext dBContext) : base(dBContext)
        {
        }

        public bool Login(string username, string password)
        {
            if (username == "abc" && password == "abc")
                return true;
            return false;
        }

        public void Register(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}