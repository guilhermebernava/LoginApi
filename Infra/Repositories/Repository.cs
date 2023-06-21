using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public readonly DbSet<T> _dbSet;
        private readonly DbContext _db;

        public Repository(AppDbContext dbContext)
        {
            _db = dbContext;
            _dbSet = _db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.ToString());
            }
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            try
            {
                var entity = await GetByIdAsync(Id);
                _dbSet.Remove(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.ToString());
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var list = await _dbSet.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.ToString());
            }
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == Id);
                if (entity == null)
                {
                    throw new RepositoryException("Not found");
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.ToString());
            }

        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex.ToString());
            }
        }
    }
}
