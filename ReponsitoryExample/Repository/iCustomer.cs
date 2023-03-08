using System.Linq.Expressions;
using ReponsitoryExample.Model;

namespace ReponsitoryExample.Repository
{
    public interface iCustomer<T> : iRepository<T>where T : BaseEntity
    {
        bool Login(string username, string password);    
        void Register(T entity);
    }
}