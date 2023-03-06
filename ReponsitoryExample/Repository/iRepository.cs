using System.Linq.Expressions;
using ReponsitoryExample.Model;

namespace ReponsitoryExample.Repository
{
    public interface iRepository<T> where T : BaseEntity
    {
        Task<T> get(int id);

        Task<IQueryable<T>> GetAll();
        IQueryable<T> GetFilter(Expression<Func<T, bool>> expression);

        Task Created(T entity);
        Task Updated(T entity);
        Task Delete(T entity);
        Task Delete(int id);
    }
}

// Todo: void->Task: bat dong bo