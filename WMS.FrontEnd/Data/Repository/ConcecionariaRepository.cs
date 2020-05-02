using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using WMS.Data;
using WMS.FrontEnd.Data.Contracts;
using WMS.FrontEnd.Data.Entities;

namespace WMS.FrontEnd.Data.Repository
{
    public class ConcecionariaRepository : IConcecionariaRepository
    {
        private readonly WMSDbContext _dbContext;
        public ConcecionariaRepository(WMSDbContext context)
        {
            _dbContext = context;
        }
        public bool Create(Concecionaria entity)
        {
            _dbContext.Concecionaria.Add(entity);
            return Save();
        }

        public bool Delete(Concecionaria entity)
        {
            _dbContext.Concecionaria.Remove(entity);
            return Save();
        }

        public ICollection<Concecionaria> FindAll()
        {
            return _dbContext.Concecionaria.ToList();
        }

        public Concecionaria FindById(int id)
        {
            return _dbContext.Concecionaria.Find(id);
        }

        public bool IsExists(int id)
        {
            return _dbContext.Concecionaria.Any(q => q.Id == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Concecionaria entity)
        {
            _dbContext.Concecionaria.Update(entity);
            return Save();
        }
    }
}
