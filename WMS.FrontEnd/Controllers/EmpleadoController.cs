using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WMS.FrontEnd.Data;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Controllers
{
    public class EmpleadoController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public EmpleadoController(RoleManager<IdentityRole> role, UserManager<IdentityUser> user, IMapper mapper)
        {
            _roleManager = role;
            _userManager = user;
            _mapper = mapper;
        }

        // GET: Empleado
        public ActionResult Index()
        {
            return View(_mapper.Map<List<IdentityUser>, List<EmpleadoVM>>(_userManager.Users.ToList()));
        }

        // GET: Empleado/Details/5
        public ActionResult Details(string id)
        {            
            return View(_mapper.Map<EmpleadoVM>(_userManager.FindByIdAsync(id).Result));
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var newUser = new Empleado
                {
                    Nombres = model.Nombres
                    , Apellidos = model.Apellidos
                    , FechaNacimiento = DateTime.Now
                    , FechaAlta = DateTime.Now
                    , Email = model.Email
                    , UserName = model.Email
                };
                var result = _userManager.CreateAsync(newUser, model.Password).Result;

                if (!result.Succeeded)
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

        // GET: Empleado/Edit/5
        public ActionResult Edit(string id)
        {
            var empleado = _mapper.Map<EmpleadoVM>(_userManager.FindByIdAsync(id).Result);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpleadoVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    return View(model);

                var result = _userManager.UpdateAsync(_userManager.FindByIdAsync(model.Id).Result).Result;
                if (!result.Succeeded)
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

        // GET: Empleado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleado/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}