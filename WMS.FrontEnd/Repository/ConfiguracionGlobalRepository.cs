using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.FrontEnd.Contracts;
using WMS.FrontEnd.Data;

namespace WMS.FrontEnd.Repository
{
    public class ConfiguracionGlobalRepository : IConfiguracionGlobalRepository
    {
        private readonly ApplicationDbContext _db;

        public ConfiguracionGlobalRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(ConfiguracionGlobal entity)
        {
            _db.ConfiguracionesGlobales.Add(entity);
            return Save();
        }

        public bool Delete(ConfiguracionGlobal entity)
        {
            _db.ConfiguracionesGlobales.Remove(entity);
            return Save();
        }

        public ICollection<ConfiguracionGlobal> FindAll()
        {
            return _db.ConfiguracionesGlobales.ToList();
        }

        public ConfiguracionGlobal FindById(int id)
        {
            return _db.ConfiguracionesGlobales.Find(id);
        }

        public bool IsExists(int id)
        {
            return _db.ConfiguracionesGlobales.Any(q => q.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(ConfiguracionGlobal entity)
        {
            _db.ConfiguracionesGlobales.Update(entity);
            return Save();
        }
    }
}
