using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ReponsitoryExample.Model;
using ReponsitoryExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ReponsitoryExample.Repository
{
    public class UnitOfWork<T> : iUnitOffWork<T> where T : DbContext
    {
        public DbContext _dbContext
        {
            get
            {
                return dbContext;
            }
        }

        private readonly DbContext dbContext;
        private IDbContextTransaction transaction;
        private Repository<Category> categoryRepository;
        private CustomerRepository customerRepository;

        public Repository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new Repository<Category>((AppDBContext)dbContext);
                }
                return categoryRepository;
            }
        }
        
        public CustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository((AppDBContext)dbContext);
                }
                return customerRepository;
            }
        }

        T iUnitOffWork<T>._dbContext => throw new NotImplementedException();

        public UnitOfWork(DbContext context)
        {
            dbContext = context;
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void CreateTransaction()
        {
           transaction= dbContext.Database.BeginTransaction();
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}