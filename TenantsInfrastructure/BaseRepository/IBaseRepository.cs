using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Base.Helpers.Enums;
using Base.Infrastructure.UnitOfWork;

namespace Base.Infrastructure.BaseRepository
{
    /// <summary>
    /// Simple marker interface for cases where generic version is not needed.
    /// </summary>
    public interface IBaseRepository : IDisposable
    {
        void SetUnitOfWork(IUnitOfWork unitOfWork);
    }

    /// <summary>
    /// Strongly typed repository interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity for this repository.</typeparam>
    public interface IBaseRepository<TEntity> : IBaseRepository where TEntity : class
    {
        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

        #endregion

        #region Methods

        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        IEnumerable<TEntity> Insert(IList<TEntity> entities);
        Task<bool> InsertAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        Task<int> UpdateAsync(IEnumerable<TEntity> entities);
        int Delete(int id);
        Task<int> DeleteAsync(int id);
        int Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        int Delete(IEnumerable<TEntity> entities);
        Task<int> DeleteAsync(IEnumerable<TEntity> entities);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        TEntity GetFirstOrDefault();
        Task<TEntity> GetFirstOrDefaultAsync();
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderByExpression, SortOrders sortOrder);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TType> GetAll<TType>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TType>> select) where TType : class;
        bool Exists(Expression<Func<TEntity, bool>> predicate);
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        decimal Sum(Expression<Func<TEntity, decimal>> selector);
        Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector);
        decimal Sum(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector);
        Task<decimal> SumAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, decimal>> selector);
        List<TModel> GetQueryResults<TModel>(string query, IEnumerable<SqlParameter> parameters) where TModel : class;

        #endregion
    }
}