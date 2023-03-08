using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReponsitoryExample.Model;

namespace ReponsitoryExample.Repository
{
    public interface iUnitOffWork<T> where T: DbContext
    {
        T _dbContext {get; }
        void Save();
        void CreateTransaction();
        void RollBack();
        void Commit();
    }
}