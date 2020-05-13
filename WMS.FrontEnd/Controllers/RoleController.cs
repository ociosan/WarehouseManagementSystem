using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WMS.FrontEnd.Models;

namespace WMS.FrontEnd.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public RoleController(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        // GET: Role
        public ActionResult Index()
        {
            var rolesCatalog = _roleManager.Roles.ToList();
            List<CreateRoleVM> lstRoles = new List<CreateRoleVM>();
            foreach(var item in rolesCatalog)
            {
                lstRoles.Add(
                    new CreateRoleVM()
                    {
                        Id = item.Id
                        , Name = item.Name
                    });
            }


            return View(lstRoles);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateRoleVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var rol = _mapper.Map<IdentityRole>(model);
                rol.Id = Guid.NewGuid().ToString();
                var result = _roleManager.CreateAsync(rol).Result;
                if(!result.Succeeded)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            if (role == null)
                return NotFound();

            var model = new EditRoleVM() 
            {
                Id = role.Id
                , Name = role.Name
                , ConcurrencyStamp = role.ConcurrencyStamp
            };
            return View(model);
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditRoleVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var Rol = new IdentityRole()
                {
                    Id = model.Id
                 , Name = model.Name
                 , NormalizedName = model.Name.ToUpper()
                 , ConcurrencyStamp = model.ConcurrencyStamp
                };

                var isSuccess = _roleManager.UpdateAsync(Rol).Result;
                if(!isSuccess.Succeeded)
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

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
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