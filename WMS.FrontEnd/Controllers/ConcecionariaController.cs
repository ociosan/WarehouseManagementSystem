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
    public class ConcecionariaController : Controller
    {
        private readonly IConcecionariaRepository _concecionariaRepo;
        private readonly IMapper _mapper;

        public ConcecionariaController(IConcecionariaRepository concecionariaRepo, IMapper mapper)
        {
            _concecionariaRepo = concecionariaRepo;
            _mapper = mapper;
        }

        // GET: Concecionaria
        public ActionResult Index()
        {
            var concecionaria = _concecionariaRepo.FindAll().ToList();
            var model = _mapper.Map<List<Concecionaria>, List<ConcecionariaVM>>(concecionaria);
            return View(model);
        }

        // GET: Concecionaria/Details/5
        public ActionResult Details(int id)
        {
            if (!_concecionariaRepo.IsExists(id))
                return NotFound();

            var concecionaria = _concecionariaRepo.FindById(id);
            var model = _mapper.Map<ConcecionariaVM>(concecionaria);
            return View(model);
        }

        // GET: Concecionaria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Concecionaria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Concecionaria model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var concecionaria = _mapper.Map<Concecionaria>(model);
                concecionaria.FechaAlta = DateTime.Now;
                
                var isSuccess = _concecionariaRepo.Create(concecionaria);

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

        // GET: Concecionaria/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_concecionariaRepo.IsExists(id))
                return NotFound();

            var concecionaria = _concecionariaRepo.FindById(id);
            var model = _mapper.Map<ConcecionariaVM>(concecionaria);
            return View(model);
        }

        // POST: Concecionaria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConcecionariaVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    return View(model);

                var concecionaria = _mapper.Map<Concecionaria>(model);
                if (!_concecionariaRepo.Update(concecionaria))
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
        public ActionResult Delete(int id, ConcecionariaVM model)
        {
            try
            {

                var concecionaria = _concecionariaRepo.FindById(id);
                if (concecionaria == null)
                    return NotFound();

                if (!_concecionariaRepo.Delete(concecionaria))
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