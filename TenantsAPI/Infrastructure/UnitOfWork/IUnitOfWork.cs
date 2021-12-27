using System;
using System.Data;
using System.Threading.Tasks;
using TenantsAPI.Models.DbContexts;

namespace TenantsAPI.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Exposes the unit of work interface.
    /// </summary>
    /// <remarks>
    /// The IUnitOfWork interface provides the abstraction 
    /// from an ORM.
    /// </remarks>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the underlying database context
        /// </summary>
        TenantsAPIDbContext Context { get; }

        /// <summary>
        /// Strongly typed repository resolution method using the IoC container
        /// </summary>
        /// <typeparam name="TRepository">
        /// Concrete repository type. 
        /// Should normally be an strong interface like IWorkerRepository.
        /// </typeparam>
        /// <returns>Requested repository resolved from IoC container.</returns>
        TRepository GetRepository<TRepository>() where TRepository : class, new();

        DataTable ExecuteReader(string query);

        /// <summary>
        /// Saves changes to database, previously opening a transaction
        /// only when none exists. The transaction is opened with isolation
        /// level set in Unit of Work before calling this method.
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Saves changes to database
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}