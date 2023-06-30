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
        public readonly AppDbContext _db;

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
                var saved = await SaveAsync();

                if (!saved)
                {
                    throw new NotSavedException("Not saved");
                }
            }
            catch (Exception ex)
            {
                throw new DbException(ex.Message);
            }
        }

        public async Task DeleteByIdAsync(Guid Id)
        {
            try
            {
                var entity = await GetByIdAsync(Id);

                if (entity == null)
                {
                    throw new NotFoundException("Not found");
                }

                _dbSet.Remove(entity);
                var saved = await SaveAsync();

                if (!saved)
                {
                    throw new NotSavedException("Not saved");
                }
            }
            catch (Exception ex)
            {
                throw new DbException(ex.Message);
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
                throw new Exception(ex.ToString());
            }
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == Id);

                if (entity == null)
                {
                    throw new NotFoundException($"Id {Id} was not found");
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new DbException(ex.ToString());
            }

        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                var saved = await SaveAsync();

                if (!saved)
                {
                    throw new NotSavedException("Not saved");
                }
            }
            catch (Exception ex)
            {
                throw new DbException(ex.Message);
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await _db.SaveChangesAsync() == 1 ? true : false;
        }

    }
}
