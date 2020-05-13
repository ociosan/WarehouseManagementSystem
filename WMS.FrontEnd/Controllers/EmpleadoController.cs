using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using WMS.Catalogs.Cons;
using WMS.FrontEnd.Data;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Controllers
{
    [Authorize(Roles = RolesCons.Admin)]
    public class EmpleadoController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private ApplicationDbContext _applicationDbContext;
        public EmpleadoController(RoleManager<IdentityRole> role, UserManager<IdentityUser> user, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _roleManager = role;
            _userManager = user;
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoVM> lstEmpleados = _mapper.Map<List<IdentityUser>, List<EmpleadoVM>>(_userManager.Users.ToList());

            var query = from users in lstEmpleados
                        join rolesRel in _applicationDbContext.UserRoles
                            on users.Id equals rolesRel.UserId
                        join roles in _applicationDbContext.Roles
                            on rolesRel.RoleId equals roles.Id
                            select new DisplayEmpleadoVM
                            {
                                        Id = users.Id
                                        , Nombres = users.Nombres
                                        , Apellidos = users.Apellidos
                                        , FechaNacimiento = users.FechaNacimiento
                                        , FechaAlta = users.FechaAlta
                                        , Email = users.Email
                                        , NombreRol = roles.Name
                            };

            return View(query.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(string id)
        {            
            return View(_mapper.Map<EmpleadoVM>(_userManager.FindByIdAsync(id).Result));
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            var roles = _roleManager.Roles.ToList();
            var rolesItems = roles.Select(q => new SelectListItem
            {
                Text = q.Name
                , Value = q.Name
            });

            var model = new CreateEmpleadoVM
            {
                Roles = rolesItems
            };
            return View(model);
        }

        // POST: Empleado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmpleadoVM model)
        {
            Guid gEmpleadoId = Guid.NewGuid();
            var birthDate = Convert.ToDateTime(model.FechaNacimiento);
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var empleado = new Empleado() 
                {
                    Id = gEmpleadoId.ToString()
                    , Nombres = model.Nombres
                    , Apellidos = model.Apellidos
                    , FechaAlta = DateTime.Now
                    , FechaNacimiento = birthDate
                    , UserName = model.Email
                    , Email = model.Email
                };

                var createEmpleado = _userManager.CreateAsync(empleado, model.Password).Result;
                if(createEmpleado.Succeeded)
                {
                    var asignacionRolEmpleado = _userManager.AddToRoleAsync(empleado,model.NombreRol).Result;
                    if(!asignacionRolEmpleado.Succeeded)
                    {
                        ModelState.AddModelError("", "Something went wrong");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View();
                }


                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
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