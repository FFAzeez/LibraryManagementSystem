using LibraryManagementInfrastructure.Context;
using LibraryManagementInfrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementInfrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly LMDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(LMDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllRecord()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetARecord(string Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
