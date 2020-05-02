using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.FrontEnd.Data.Contracts;
using WMS.FrontEnd.Data.Entities;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ConfiguracionGlobalController : Controller
    {
        private readonly IConfiguracionGlobalRepository _configGlobalRepo;
        private readonly IMapper _mapper;

        public ConfiguracionGlobalController(IConfiguracionGlobalRepository productoRepository, IMapper mapper)
        {
            _configGlobalRepo = productoRepository;
            _mapper = mapper;
        }
        // GET: ConfiguracionGlobal
        public ActionResult Index()
        {
            return View(_mapper.Map<List<ConfiguracionGlobal>, List<ConfiguracionGlobalViewModel>>(_configGlobalRepo.FindAll().ToList()));
        }

        // GET: ConfiguracionGlobal/Details/5
        public ActionResult Details(int id)
        {
            if(!_configGlobalRepo.IsExists(id))
                return NotFound();

            return View(_mapper.Map<ConfiguracionGlobalViewModel>(_configGlobalRepo.FindById(id)));
        }

        // GET: ConfiguracionGlobal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfiguracionGlobal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConfiguracionGlobalViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var configuracion = _mapper.Map<ConfiguracionGlobal>(model);

                if(!_configGlobalRepo.Create(configuracion))
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

        // GET: ConfiguracionGlobal/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_configGlobalRepo.IsExists(id))
                return NotFound();

            var config = _configGlobalRepo.FindById(id);
            return View(_mapper.Map<ConfiguracionGlobalViewModel>(config));
        }

        // POST: ConfiguracionGlobal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConfiguracionGlobalViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var config = _mapper.Map<ConfiguracionGlobal>(model);
                if(!_configGlobalRepo.Update(config))
                {
                    ModelState.AddModelError("","Hubo un error...");
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

        // GET: ConfiguracionGlobal/Delete/5
        public ActionResult Delete(int id)
        {
            var config = _configGlobalRepo.FindById(id);
            if (config == null)
                return NotFound();

            if (!_configGlobalRepo.Delete(config))
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        // POST: ConfiguracionGlobal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ConfiguracionGlobalViewModel model)
        {
            try
            {

                var config = _configGlobalRepo.FindById(id);
                if (config == null)
                    return NotFound();

                if (!_configGlobalRepo.Delete(config))
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