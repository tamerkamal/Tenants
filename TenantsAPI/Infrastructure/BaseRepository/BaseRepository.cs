using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TenantsAPI.Helper.Enums;
using TenantsAPI.Helper.Extensions;
using TenantsAPI.Infrastructure.UnitOfWork;

namespace TenantsAPI.Infrastructure.BaseRepository
{
    /// <summary>
    /// Represents a default generic repository implements the <see cref="IBaseRepository{TEntity}"/> interface.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        #region Fields

        private IUnitOfWork _unitOfWork;
        private DbContext _context;
        private DbSet<TEntity> _entity;

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets an db context
        /// </summary>
        public DbContext Context => _context ??= _unitOfWork.Context;

        /// <summary>
        /// Gets an entity set
        /// </summary>
        private DbSet<TEntity> Entity => _entity ??= Context.Set<TEntity>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public IQueryable<TEntity> Table => Entity;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public IQueryable<TEntity> TableNoTracking => Entity.AsNoTracking();

        #endregion

        #region Utilities

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Error message</returns>
        private string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            // rollback entity changes
            if (Context is { } dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }

            try
            {
                _unitOfWork.SaveChanges();

                return exception.ToString();
            }
            catch (Exception ex)
            {
                // if after the rollback of changes the context is still not saving,
                // return the full text of the exception that occurred when saving
                return ex.ToString();
            }
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            _unitOfWork?.Dispose();
            _context?.Dispose();
        }

        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                Entity.Add(entity);

                _unitOfWork.SaveChanges();

                _context.Entry(entity).State = EntityState.Detached;

                return entity;
            }
            catch (DbUpdateException exception)
            {
                // Ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await Entity.AddAsync(entity);

                await _unitOfWork.SaveChangesAsync();

                _context.Entry(entity).State = EntityState.Detached;

                return entity;
            }
            catch (DbUpdateException exception)
            {
                // Ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual IEnumerable<TEntity> Insert(IList<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            try
            {
                Entity.AddRange(entities);

                _unitOfWork.SaveChanges();

                foreach (var entity in entities)
                {
                    _context.Entry(entity).State = EntityState.Detached;
                }

                return entities;
            }
            catch (DbUpdateException exception)
            {
                // Ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual async Task<bool> InsertAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            try
            {
                await Entity.AddRangeAsync(entities);

                await _unitOfWork.SaveChangesAsync();

                foreach (var entity in entities)
                {
                    _context.Entry(entity).State = EntityState.Detached;
                }

                return true;
            }
            catch (DbUpdateException exception)
            {
                // Ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        public virtual void Update(TEntity entity)
        {
            Entity.Update(entity);

            _unitOfWork.SaveChanges();

            _context.Entry(entity).State = EntityState.Detached;
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            Entity.Update(entity);

            var results = await _unitOfWork.SaveChangesAsync();

            _context.Entry(entity).State = EntityState.Detached;

            return results;
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            Entity.UpdateRange(entities);

            _unitOfWork.SaveChanges();

            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
        }

        public virtual async Task<int> UpdateAsync(IEnumerable<TEntity> entities)
        {
            Entity.UpdateRange(entities);

            var results = await _unitOfWork.SaveChangesAsync();

            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }

            return results;
        }

        public virtual int Delete(int id)
        {
            // Find entity by primary key
            var entity = Entity.Find(id);

            // Check if entity already exists
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Delete entity
            Entity.Remove(entity);

            var result = _unitOfWork.SaveChanges();

            return result;
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            // Find entity by primary key
            var entity = await Entity.FindAsync(id);

            // Check if entity already exists
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Delete entity
            Entity.Remove(entity);

            var result = await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public virtual int Delete(TEntity entity)
        {
            Entity.Remove(entity);

            var result = _unitOfWork.SaveChanges();

            return result;
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            Entity.Remove(entity);

            var result = await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public virtual int Delete(IEnumerable<TEntity> entities)
        {
            Entity.RemoveRange(entities);

            var result = _unitOfWork.SaveChanges();

            return result;
        }

        public virtual async Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            Entity.RemoveRange(entities);

            var result = await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Entity.Where(predicate);

            Entity.RemoveRange(entities);

            var result = _unitOfWork.SaveChanges();

            return result;
        }

        public virtual async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Entity.Where(predicate);

            Entity.RemoveRange(entities);

            var result = await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public TEntity GetById(int id) => Entity.Find(id);

        public async Task<TEntity> GetByIdAsync(int id) => await Entity.FindAsync(id);

        public TEntity GetFirstOrDefault() => Entity.AsNoTracking().FirstOrDefault();

        public async Task<TEntity> GetFirstOrDefaultAsync() => await TableNoTracking.FirstOrDefaultAsync();

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate) => TableNoTracking.FirstOrDefault(predicate);

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await TableNoTracking.FirstOrDefaultAsync(predicate);

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderByExpression, SortOrders sortOrder)
        {
            return sortOrder == SortOrders.Descending
                ? TableNoTracking.OrderByDescending(orderByExpression).FirstOrDefault(predicate)
                : TableNoTracking.OrderBy(orderByExpression).FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll() => TableNoTracking;

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await TableNoTracking.ToListAsync();

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate) => TableNoTracking.Where(predicate);

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate) => await TableNoTracking.Where(predicate).ToListAsync();

        public IEnumerable<TType> GetAll<TType>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TType>> select) where TType : class
        {
            return TableNoTracking.Where(predicate).Select(select);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate) => TableNoTracking.Any(predicate);

        public int Count(Expression<Func<TEntity, bool>> predicate) => TableNoTracking.Count(predicate);

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate) => TableNoTracking.CountAsync(predicate);

        public decimal Sum(Expression<Func<TEntity, decimal>> selector) => TableNoTracking.Sum(selector);

        public Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector) => TableNoTracking.SumAsync(selector);

        public decimal Sum(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector) => Entity.Where(predicate).DefaultIfEmpty().AsNoTracking().Sum(selector);

        public Task<decimal> SumAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector) => TableNoTracking.Where(predicate).SumAsync(selector);

        public List<TModel> GetQueryResults<TModel>(string query, IEnumerable<SqlParameter> parameters) where TModel : class
        {
            var table = new DataTable();
            var connectionString = Context.Database.GetDbConnection().ConnectionString;

            // Create connection
            using (var con = new SqlConnection(connectionString))
            {
                // Create command
                using var cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Add parameters to command
                foreach (var parameter in parameters)
                    cmd.Parameters.Add(parameter);
                cmd.CommandTimeout = 100;
                con.Open();

                // Fill data table
                var dp = new SqlDataAdapter(cmd);
                dp.Fill(table);
            }

            // Return results
            return table.ConvertToList<TModel>();
        }

        public async Task<List<TModel>> GetQueryResultsAsync<TModel>(string query, IEnumerable<SqlParameter> parameters) where TModel : class
        {
            var table = new DataTable();
            var connectionString = Context.Database.GetDbConnection().ConnectionString;

            // Create connection
            using (var con = new SqlConnection(connectionString))
            {
                // Create command
                using var cmd = new SqlCommand(query, con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Add parameters to command
                foreach (var parameter in parameters)
                    cmd.Parameters.Add(parameter);

                con.Open();

                // Fill data table
                var dp = new SqlDataAdapter(cmd);
                await Task.Run(() => dp.Fill(table));
                //dp.Fill(table);
            }

            // Return results
            return table.ConvertToList<TModel>();
        }

        #endregion
    }
}