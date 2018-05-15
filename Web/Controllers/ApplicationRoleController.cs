
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Service;

namespace AspMain.Web.Controllers
{
    public class ApplicationRoleController : Controller
    {
        public ApplicationRoleController()
        {
        }

        public ApplicationRoleController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
            var x = RoleManager.Roles.ToList();
            List<ApplicationRoleListViewModel> model = new List<ApplicationRoleListViewModel>();
            model = RoleManager.Roles.Select(r => new ApplicationRoleListViewModel
            {
                RoleName = r.Name,
                Id = r.Id,
                NumberOfUsers = r.Users.Count
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> AddEditApplicationRole(string id)
        {
            ApplicationRoleViewModel model = new ApplicationRoleViewModel();
            if (!String.IsNullOrEmpty(id))
            {
                var applicationRole = await RoleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    model.Id = applicationRole.Id;
                    model.RoleName = applicationRole.Name;
                }
            }
            return PartialView("_AddEditApplicationRole", model);
        }
        [HttpPost]
        public async Task<ActionResult> AddEditApplicationRole(string id, ApplicationRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isExist = !String.IsNullOrEmpty(id);
                var applicationRole = isExist ? await RoleManager.FindByIdAsync(id) :
               new IdentityRole();
                applicationRole.Name = model.RoleName;
                IdentityResult roleRuslt = isExist?  await RoleManager.UpdateAsync(applicationRole)
                                                    : await RoleManager.CreateAsync(applicationRole);
                if (roleRuslt.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteApplicationRole(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                var applicationRole = await RoleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    name = applicationRole.Name;
                }
            }
            return PartialView("_DeleteApplicationRole", name);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteApplicationRole(string id, FormCollection form)
        {
            if(!String.IsNullOrEmpty(id))
            {
                var applicationRole = await RoleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    IdentityResult roleRuslt = RoleManager.DeleteAsync(applicationRole).Result;
                    if (roleRuslt.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
                }
            return View();
        }
    }
}
