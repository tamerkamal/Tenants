using Base.Infrastructure.BaseRepository;
using Master.DTO;
using Master.Entity.Models;
using Master.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Master.Repository.Classes
{
    public class TenantRepository : BaseRepository<Tenant>, ITenantRepository
    {
        public async Task<bool> CreateTenantDatabaseClone(string databaseName)
        {
            //await Context.Database.ExecuteSqlRawAsync("RefreshSchedule @SchdId={0}", databaseName);

            return true;
        }

        public async Task<bool> DropDatabaseClone(string databaseName)
        {
            //await Context.Database.ExecuteSqlRawAsync("RefreshSchedule @SchdId={0}", databaseName);

            return true;
        }
    }
}
