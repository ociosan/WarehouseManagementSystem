using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS.Data;
using WMS.FrontEnd.Data.Contracts;
using WMS.FrontEnd.Data.Entities;

namespace WMS.FrontEnd.Data.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly WMSDbContext _dbContext;
        public ProductoRepository(WMSDbContext context)
        {
            _dbContext = context;
        }
        public bool Create(Producto entity)
        {
            _dbContext.Producto.Add(entity);
            return Save();
        }

        public bool Delete(Producto entity)
        {
            _dbContext.Producto.Remove(entity);
            return Save();
        }

        public ICollection<Producto> FindAll()
        {
            return _dbContext.Producto.ToList();
        }

        public Producto FindById(int id)
        {
            return _dbContext.Producto.Find(id);
        }

        public bool IsExists(int id)
        {
            return _dbContext.Producto.Any(q => q.Id == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Producto entity)
        {
            _dbContext.Producto.Update(entity);
            return Save();
        }
    }
}
