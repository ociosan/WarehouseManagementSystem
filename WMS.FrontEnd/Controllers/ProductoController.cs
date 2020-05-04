using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.FrontEnd.Contracts;
using WMS.FrontEnd.Data;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepo;
        private readonly IMapper _mapper;

        public ProductoController(IProductoRepository productoRepo, IMapper mapper)
        {
            _productoRepo = productoRepo;
            _mapper = mapper;
        }

        // GET: Producto
        public ActionResult Index()
        {
            var producto = _productoRepo.FindAll().ToList();
            var model = _mapper.Map<List<Producto>, List<ProductoVM>>(producto);
            return View(model);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            if (!_productoRepo.IsExists(id))
                return NotFound();

            var concecionaria = _productoRepo.FindById(id);
            var model = _mapper.Map<ProductoVM>(concecionaria);
            return View(model);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var producto = _mapper.Map<Producto>(model);
                producto.FechaAlta = DateTime.Now;

                var isSuccess = _productoRepo.Create(producto);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_productoRepo.IsExists(id))
                return NotFound();

            var producto = _productoRepo.FindById(id);
            var model = _mapper.Map<ProductoVM>(producto);
            return View(model);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    return View(model);

                var producto = _mapper.Map<Producto>(model);
                if (!_productoRepo.Update(producto))
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            var producto = _productoRepo.FindById(id);
            if (producto == null)
                return NotFound();

            if (!_productoRepo.Delete(producto))
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductoVM model)
        {
            try
            {

                var producto = _productoRepo.FindById(id);
                if (producto == null)
                    return NotFound();

                if (!_productoRepo.Delete(producto))
                {
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }
    }
}