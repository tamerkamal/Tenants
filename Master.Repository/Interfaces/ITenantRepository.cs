using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Master.Repository.Interfaces
{
    public interface ITenantRepository
    {
        Task<bool> CreateTenantDatabaseClone(string databaseName);
        Task<bool> DropDatabaseClone(string databaseName);
    }
}
