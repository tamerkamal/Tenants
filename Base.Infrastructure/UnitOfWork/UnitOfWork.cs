using Base.Helpers.Extensions;
using Base.Infrastructure.BaseRepository;
using Master.Entity.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Master.Entity.Models;

namespace Base.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Fields

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Hashtable _repositories;

        #endregion

        #region Private Properties     

        //private int WorkerId
        //{
        //    get
        //    {
        //        // Get logged-in username
        //        var userName = _httpContextAccessor.HttpContext.User.GetLoggedInUserName();
        //        if (string.IsNullOrEmpty(userName))
        //            throw new ArgumentNullException($"Current username cannot be empty.");

        //        // Return workerId
        //        return Context.Set<Worker>().AsNoTracking()
        //            .Where(a => a.UserName.ToLower() == userName.ToLower())
        //            .Select(a => a.WorkerId)
        //            .FirstOrDefault();
        //    }
        //}

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the underlying database context
        /// </summary>
        public MasterDbContext Context { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        /// <param name="httpContextAccessor">IHttpContextAccessor</param>
        public UnitOfWork(MasterDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _httpContextAccessor = httpContextAccessor;
            _repositories = new Hashtable();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Strongly typed repository resolution method using the IoC container
        /// </summary>
        /// <typeparam name="TRepository">
        /// Concrete repository type. 
        /// Should normally be an strong interface like IWorkerRepository.
        /// </typeparam>
        /// <returns>Requested repository resolved from IoC container.</returns>
        public TRepository GetRepository<TRepository>() where TRepository : class, new()
        {
            var type = typeof(TRepository);
            if (_repositories.ContainsKey(type)) return (TRepository)_repositories[type];

            var repositoryInstance = new TRepository();
            ((IBaseRepository)repositoryInstance).SetUnitOfWork(this);
            _repositories[type] = repositoryInstance;
            return (TRepository)_repositories[type];
        }

        public DataTable ExecuteReader(string query)
        {
            // Create command
            using var command = Context.Database.GetDbConnection().CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            // Execute reader
            using var reader = command.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);

            // Return results
            return table;
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>,
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int SaveChanges()
        {
            try
            {
                // Track all changes and save them in log table.
                TrackChanges();

                // Save changes with the default options
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    // Update the values of the entity that failed to save from the store 
                    entry.Reload();
                }

                return SaveChanges();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            // Track all changes and save them in log table.
            TrackChanges();

            // Save changes with the default options
            return await Context.SaveChangesAsync();
        }

        /// <inheritdoc />
        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Private Methods

        private void TrackChanges()
        {
            //var workerId = WorkerId;
            var entries = Context.ChangeTracker.Entries().ToList();
            var addedEntities = entries.Where(p => p.State == EntityState.Added).ToList();
            var modifiedEntities = entries.Where(p => p.State == EntityState.Modified).ToList();

            // Set audit columns
            //SetAddedAuditColumns(addedEntities, workerId);
            SetModifiedAuditColumns(modifiedEntities);

            // Insert log changes
            //InsertLogChanges(modifiedEntities, workerId);
        }

        private static void SetAddedAuditColumns(IEnumerable<EntityEntry> entries, int workerId)
        {
            foreach (var entry in entries)
            {
                // Handle "CreatedByWorkerId" by two ways because some table have different case
                // 1- First way
                if (entry.Metadata.FindProperty("CreatedByWorkerId") != null)
                    entry.Property("CreatedByWorkerId").CurrentValue = workerId;

                // 2- Second way
                else if (entry.Metadata.FindProperty("CreatedbyWorkerId") != null)
                    entry.Property("CreatedbyWorkerId").CurrentValue = workerId;

                if (entry.Metadata.FindProperty("DateCreated") != null)
                    entry.Property("DateCreated").CurrentValue = DateTime.Now;

                if (entry.Metadata.FindProperty("LastUpdated") != null)
                    entry.Property("LastUpdated").CurrentValue = DateTime.Now;
            }
        }

        private static void SetModifiedAuditColumns(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                // Handle "CreatedByWorkerId" by two ways because some table have different case
                // 1- First way
                if (entry.Metadata.FindProperty("CreatedByWorkerId") != null)
                    entry.Property("CreatedByWorkerId").IsModified = false;

                // 2- Second way
                else if (entry.Metadata.FindProperty("CreatedbyWorkerId") != null)
                    entry.Property("CreatedbyWorkerId").IsModified = false;

                if (entry.Metadata.FindProperty("DateCreated") != null)
                    entry.Property("DateCreated").IsModified = false;

                if (entry.Metadata.FindProperty("LastUpdated") != null)
                    entry.Property("LastUpdated").CurrentValue = DateTime.Now;
            }
        }

        private void InsertLogChanges(IEnumerable<EntityEntry> entries, int workerId)
        {
            var dateNow = DateTime.Now;

            foreach (var entry in entries)
            {
                var entityName = entry.Entity.GetType().Name;
                var primaryKeyValue = GetPrimaryKeyValue(entry);
                var originalProperties = entry.OriginalValues.Properties.Where(a => a.Name != "LastUpdated"
                                                                                    //&& a.Name != "LockedTime"
                                                                                    && a.PropertyInfo.PropertyType != typeof(byte[]));

                foreach (var property in originalProperties)
                {
                    var originalValue = entry.OriginalValues[property.Name];
                    var currentValue = entry.CurrentValues[property.Name];

                    if (originalValue.IsEqual(currentValue)) continue;

                    originalValue ??= "";
                    currentValue ??= "";
                    //** Insert a new "Log"
                    var log = new Log
                    {
                        WorkerId = workerId,
                        LogType = "Data update",
                        Id = primaryKeyValue,
                        Idtype = entityName,
                        EventDesc = $"Changed {property.Name} from '{originalValue?.ToString()}' to '{currentValue?.ToString()}'",
                        TableChanged = entityName,
                        FieldChanged = property.Name,
                        OldValue = originalValue?.ToString().Length > 2000 ? originalValue.ToString().Substring(0, 2000) : originalValue.ToString(),
                        NewValue = currentValue?.ToString().Length > 2000 ? currentValue.ToString().Substring(0, 2000) : currentValue.ToString(),
                        EventDate = dateNow,
                        LogDate = dateNow,
                    };

                    log = CustomHandleEntityColumns(entry.Entity.GetType().Name, property.Name, originalValue, currentValue, log);

                    Context.Add(log);
                }
            }
        }

        private dynamic CustomHandleEntityColumns(string entryEntityName, string entryPropertyName, object entryOriginalPropertyValue, object entryCurrentPropertyValue, dynamic entityToBeHandled)
        {
            var entityToBeHandledName = entityToBeHandled?.GetType()?.Name;

            switch (entityToBeHandledName)
            {
                case "Log":
                    {
                        CustomHandleLogColumns(entryEntityName, entryPropertyName, entryOriginalPropertyValue, entryCurrentPropertyValue, ref entityToBeHandled);
                        break;
                    }

                default:
                    break;
            }

            return entityToBeHandled;
        }

        private Log CustomHandleLogColumns(string entityName, string propertyName, object originalValue, object currentValue, ref dynamic log)
        {
            Log logEntity = log;

            logEntity.EventDesc = CustomHandleLogEventDesc(entityName, propertyName, originalValue, currentValue, logEntity.EventDesc);

            return logEntity;
        }

        private string CustomHandleLogEventDesc(string entityName, string propertyName, object originalValue, object currentValue, string eventDesc)
        {
            if (entityName == "JobVisit")

                switch (propertyName)
                {
                    case "PhotosCorrect":
                    case "FormCorrect":
                    case "ScopesCorrect":
                    case "EquipmentCorrect":
                    case "SafetyCorrect":
                    case "QualityCorrect":
                        {
                            if (originalValue?.ToString() == "")
                            {
                                eventDesc = $"Changed {propertyName} from 'N/A' to '{currentValue?.ToString()}'";
                            }
                            else if (currentValue?.ToString() == "")
                            {
                                eventDesc = $"Changed {propertyName} from '{originalValue?.ToString()}' to 'N/A'";
                            }

                            break;
                        }
                    default:
                        break;
                }

            return eventDesc;
        }


        private int GetPrimaryKeyValue(EntityEntry entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var type = entity.Entity.GetType();
            var keyName = Context.Model.FindEntityType(type).FindPrimaryKey().Properties.Select(a => a.Name).Single();
            var property = type.GetProperty(keyName);
            if (property == null) return -1;

            var propertyValue = property.GetValue(entity.Entity, null);
            return (int?)propertyValue ?? -1;
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing) return;

            // clear repositories.
            _repositories?.Clear();

            // dispose the db context.
            Context?.Dispose();
        }

        #endregion
    }
}