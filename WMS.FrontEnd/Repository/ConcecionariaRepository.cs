using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.FrontEnd.Contracts;
using WMS.FrontEnd.Data;

namespace WMS.FrontEnd.Repository
{
    public class ConcecionariaRepository : IConcecionariaRepository
    {
        private readonly ApplicationDbContext _db;

        public ConcecionariaRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Concecionaria entity)
        {
            _db.Concecionarias.Add(entity);
            return Save();
        }

        public bool Delete(Concecionaria entity)
        {
            _db.Concecionarias.Remove(entity);
            return Save();
        }

        public ICollection<Concecionaria> FindAll()
        {
            return _db.Concecionarias.ToList();
        }

        public Concecionaria FindById(int id)
        {
            return _db.Concecionarias.Find(id);
        }

        public bool IsExists(int id)
        {
            return _db.Concecionarias.Any(q => q.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(Concecionaria entity)
        {
            _db.Concecionarias.Update(entity);
            return Save();
        }
    }
}
