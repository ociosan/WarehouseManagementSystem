using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Data;
using WMS.FrontEnd.Data.Contracts;
using WMS.FrontEnd.Data.Entities;

namespace WMS.FrontEnd.Data.Repository
{
    public class RolRepository : IRolRepository
    {
        private readonly WMSDbContext _theContext;
        public RolRepository(WMSDbContext context)
        {
            _theContext = context;
        }
        public bool Create(Rol entity)
        {
            _theContext.Add(entity);
            return Save();
        }

        public bool Delete(Rol entity)
        {
            _theContext.Remove(entity);
            return Save();
        }

        public ICollection<Rol> FindAll()
        {
            return _theContext.Rol.ToList();
        }

        public Rol FindById(int id)
        {
            return _theContext.Rol.Find(id);
        }

        public bool IsExists(int id)
        {
            return _theContext.Rol.Any(q => q.Id == id);
        }

        public bool Save()
        {
            return _theContext.SaveChanges() > 0;
        }

        public bool Update(Rol entity)
        {
            _theContext.Update(entity);
            return Save();
        }
    }
}
