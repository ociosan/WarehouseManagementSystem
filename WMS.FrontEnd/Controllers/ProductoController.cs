using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.FrontEnd.Data.Contracts;
using WMS.FrontEnd.Data.Entities;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepo;
        private readonly IMapper _mapper;

        public ProductoController(IProductoRepository repo, IMapper mapper)
        {
            _productoRepo = repo;
            _mapper = mapper;
        }

        // GET: Producto
        public ActionResult Index()
        {
            return View(_mapper.Map<List<Producto>, List<ProductoViewModel>>(_productoRepo.FindAll().ToList()));
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            if (!_productoRepo.IsExists(id))
                return NotFound();

            return View(_mapper.Map<ProductoViewModel>(_productoRepo.FindById(id)));

        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var producto = _mapper.Map<Producto>(model);
                producto.FechaAlta = DateTime.Now;
                if (!_productoRepo.Create(producto))
                {
                    ModelState.AddModelError("", "Hubo un error....");
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
            return View(_mapper.Map<ProductoViewModel>(producto));
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var producto = _mapper.Map<Producto>(model);
                if (!_productoRepo.Update(producto))
                {
                    ModelState.AddModelError("", "Hubo un error...");
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
        public ActionResult Delete(int id, ProductoViewModel model)
        {
            try
            {
                var producto = _productoRepo.FindById(id);
                if (producto == null)
                    return NotFound();

                if (!_productoRepo.Delete(producto))
                    return View(model);

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