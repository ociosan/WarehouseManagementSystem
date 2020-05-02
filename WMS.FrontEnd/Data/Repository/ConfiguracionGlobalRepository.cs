using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.Data;
using WMS.FrontEnd.Data.Contracts;
using WMS.FrontEnd.Data.Entities;

namespace WMS.FrontEnd.Data.Repository
{
    public class ConfiguracionGlobalRepository : IConfiguracionGlobalRepository
    {
        private readonly WMSDbContext _dbContext;
        public ConfiguracionGlobalRepository(WMSDbContext context)
        {
            _dbContext = context;
        }
        public bool Create(ConfiguracionGlobal entity)
        {
            _dbContext.ConfiguracionGlobal.Add(entity);
            return Save();
        }

        public bool Delete(ConfiguracionGlobal entity)
        {
            _dbContext.ConfiguracionGlobal.Remove(entity);
            return Save();
        }

        public ICollection<ConfiguracionGlobal> FindAll()
        {
            return _dbContext.ConfiguracionGlobal.ToList();
        }

        public ConfiguracionGlobal FindById(int id)
        {
            return _dbContext.ConfiguracionGlobal.Find(id);
        }

        public bool IsExists(int id)
        {
            return _dbContext.ConfiguracionGlobal.Any(q => q.Id == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(ConfiguracionGlobal entity)
        {
            _dbContext.ConfiguracionGlobal.Update(entity);
            return Save();
        }
    }
}
