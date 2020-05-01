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
    public class RolController : Controller
    {
        private readonly IRolRepository _rolRepo;
        private readonly IMapper _mapper;

        public RolController(IRolRepository therepo, IMapper mapper)
        {
            _rolRepo = therepo;
            _mapper = mapper;
        }
        // GET: Rol
        public ActionResult Index()
        {
            return View(_mapper.Map<List<Rol>, List<RolViewModel>>(_rolRepo.FindAll().ToList()));
        }

        // GET: Rol/Details/5
        public ActionResult Details(int id)
        {
            if (!_rolRepo.IsExists(id))
                return NotFound();

            return View(_mapper.Map<RolViewModel>(_rolRepo.FindById(id)));
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RolViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var rol = _mapper.Map<Rol>(model);
                var isSuccess = _rolRepo.Create(rol);
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

        // GET: Rol/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_rolRepo.IsExists(id))
                return NotFound();

            return View(_mapper.Map<RolViewModel>(_rolRepo.FindById(id)));
        }

        // POST: Rol/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RolViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var rol = _mapper.Map<Rol>(model);
                if(!_rolRepo.Update(rol))
                {
                    ModelState.AddModelError("", "Something wnet wrong...");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("","Something went wrong...");
                return View(model);
            }
        }

        // GET: Rol/Delete/5
        public ActionResult Delete(int id)
        {
            var rol = _rolRepo.FindById(id);
            if (rol == null)
                return NotFound();

            if (!_rolRepo.Delete(rol))
                return BadRequest();


            return RedirectToAction(nameof(Index));
        }

        // POST: Rol/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RolViewModel model)
        {
            try
            {
                var rol = _rolRepo.FindById(id);
                if (rol == null)
                    return NotFound();

                if (!_rolRepo.Delete(rol))
                    return View(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("","Something went wrong...");
                return View(model);
            }
        }
    }
}