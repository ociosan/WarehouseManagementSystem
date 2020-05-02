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
    public class ConcecionariaController : Controller
    {
        private readonly IConcecionariaRepository _concecionariaRepo;
        private readonly IMapper _mapper;

        public ConcecionariaController(IConcecionariaRepository concecionariaRepository, IMapper mapper)
        {
            _concecionariaRepo = concecionariaRepository;
            _mapper = mapper;
        }

        // GET: Concecionaria
        public ActionResult Index()
        {
            return View(_mapper.Map<List<Concecionaria>, List<ConcecionariaViewModel>>(_concecionariaRepo.FindAll().ToList()));

        }

        // GET: Concecionaria/Details/5
        public ActionResult Details(int id)
        {

            if (!_concecionariaRepo.IsExists(id))
                return NotFound();

            return View(_mapper.Map<ConcecionariaViewModel>(_concecionariaRepo.FindById(id)));
        }

        // GET: Concecionaria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Concecionaria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConcecionariaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var configuracion = _mapper.Map<Concecionaria>(model);
                configuracion.FechaAlta = DateTime.Now;
                if (!_concecionariaRepo.Create(configuracion))
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

        // GET: Concecionaria/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_concecionariaRepo.IsExists(id))
                return NotFound();

            var config = _concecionariaRepo.FindById(id);
            return View(_mapper.Map<ConcecionariaViewModel>(config));
        }

        // POST: Concecionaria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConcecionariaViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var config = _mapper.Map<Concecionaria>(model);
                if (!_concecionariaRepo.Update(config))
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

        // GET: Concecionaria/Delete/5
        public ActionResult Delete(int id)
        {
            var concecionaria = _concecionariaRepo.FindById(id);
            if (concecionaria == null)
                return NotFound();

            if (!_concecionariaRepo.Delete(concecionaria))
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        // POST: Concecionaria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ConcecionariaViewModel model)
        {
            try
            {
                var concecionaria = _concecionariaRepo.FindById(id);
                if (concecionaria == null)
                    return NotFound();

                if (!_concecionariaRepo.Delete(concecionaria))
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