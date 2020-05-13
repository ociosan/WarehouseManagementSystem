using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Catalogs.Cons;
using WMS.FrontEnd.Contracts;
using WMS.FrontEnd.Data;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Controllers
{
    public class ConfiguracionGlobalController : Controller
    {
        private readonly IConfiguracionGlobalRepository _globalConfigRepo;
        private readonly IMapper _mapper;

        public ConfiguracionGlobalController(IConfiguracionGlobalRepository globalConfigRepo, IMapper mapper)
        {
            _globalConfigRepo = globalConfigRepo;
            _mapper = mapper;
        }

        // GET: ConfiguracionGlobal
        public ActionResult Index()
        {
            var globalconfig = _globalConfigRepo.FindAll().ToList();
            var model = _mapper.Map<List<ConfiguracionGlobal>, List<ConfiguracionGlobalVM>>(globalconfig);
            return View(model);
        }

        // GET: ConfiguracionGlobal/Details/5
        public ActionResult Details(int id)
        {
            if (!_globalConfigRepo.IsExists(id))
                return NotFound();

            var globalconfig = _globalConfigRepo.FindById(id);
            var model = _mapper.Map<ConfiguracionGlobalVM>(globalconfig);
            return View(model);
        }

        // GET: ConfiguracionGlobal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfiguracionGlobal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConfiguracionGlobalVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var globalconfig = _mapper.Map<ConfiguracionGlobal>(model);
                
                var isSuccess = _globalConfigRepo.Create(globalconfig);

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

        // GET: ConfiguracionGlobal/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_globalConfigRepo.IsExists(id))
                return NotFound();

            var globalConfig = _globalConfigRepo.FindById(id);
            var model = _mapper.Map<ConfiguracionGlobalVM>(globalConfig);
            return View(model);
        }

        // POST: ConfiguracionGlobal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConfiguracionGlobalVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    return View(model);

                var leaveType = _mapper.Map<ConfiguracionGlobal>(model);
                if (!_globalConfigRepo.Update(leaveType))
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

        // GET: ConfiguracionGlobal/Delete/5
        public ActionResult Delete(int id)
        {
            var globalConfig = _globalConfigRepo.FindById(id);
            if (globalConfig == null)
                return NotFound();

            if (!_globalConfigRepo.Delete(globalConfig))
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        // POST: ConfiguracionGlobal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ConfiguracionGlobalVM model)
        {
            try
            {

                var globalConfig = _globalConfigRepo.FindById(id);
                if (globalConfig == null)
                    return NotFound();

                if (!_globalConfigRepo.Delete(globalConfig))
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