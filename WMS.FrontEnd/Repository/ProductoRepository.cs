using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.FrontEnd.Contracts;
using WMS.FrontEnd.Data;

namespace WMS.FrontEnd.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductoRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Producto entity)
        {
            _db.Productos.Add(entity);
            return Save();
        }

        public bool Delete(Producto entity)
        {
            _db.Productos.Remove(entity);
            return Save();
        }

        public ICollection<Producto> FindAll()
        {
            return _db.Productos.ToList();
        }

        public Producto FindById(int id)
        {
            return _db.Productos.Find(id);
        }

        public bool IsExists(int id)
        {
            return _db.Productos.Any(q => q.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(Producto entity)
        {
            _db.Productos.Update(entity);
            return Save();
        }
    }
}
