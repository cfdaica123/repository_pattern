using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ReponsitoryExample.Model;


namespace ReponsitoryExample.Repository
{
    public class Repository<T> : iRepository<T> where T : BaseEntity
    {
        private readonly AppDBContext _dbContext;

        public Repository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task Created(T entity)
        {
            await _dbContext.Set<T>().AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            // return Task.CompletedTask;
            // bo async
        }

        public async Task Delete(int id)
        {
            var obj = _dbContext.Set<T>().Where(x => x.Id == id).FirstOrDefault();
            if(obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
                _dbContext.SaveChanges();
            }
        }

        public async Task<T> get(int id)
        {
            var rs = await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return rs;
            // !lay ra khong theo doi trang thai
        }

        // chua thuc thi truy van cau sql
        public IQueryable<T> GetAll()
        {
            var rs = _dbContext.Set<T>().AsNoTracking();
            return rs;
        }

        public IQueryable<T> GetFilter(Expression<Func<T, bool>> expression)
        {
            var rs = _dbContext.Set<T>().AsNoTracking().Where(expression);
            return rs;
        }

        public Task Updated(T entity)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<T>> iRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}