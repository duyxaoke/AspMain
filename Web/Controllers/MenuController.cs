using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Service;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Core.Data;

namespace AspMain.Web.Controllers
{
    public class MenuController : Controller
    {
        private IMenuServices _menuServices = new MenuServices();

        // GET: Template
        public ActionResult Index()
        {
            var model = _menuServices.GetAllMenu().ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEditMenu(int id)
        {
            bool isExist = id > 0 ? true : false;
            var menu = isExist ? _menuServices.GetAllMenu().FirstOrDefault(c => c.Id == id) : new MenuViewModel();
            menu.ListParent = (List<SelectListItem>) _menuServices.GetAllMenu().Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString(),
            });
            return PartialView("_AddEditMenu", menu);
        }
        [HttpPost]
        public ActionResult AddEditMenu(int id, MenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool isExist = id > 0 ? true : false;
                var menu = isExist ? _menuServices.GetMenu(id) : new Menu();
                menu.Name = model.Name;
                menu.ParentId = model.ParentId;
                menu.Icon = model.Icon;
                menu.Url = model.Url;
                menu.IsActive = model.IsActive;
                menu.SortOrder = model.SortOrder;
                if (isExist)
                {
                    _menuServices.UpdateMenu(menu);
                }
                else
                {
                    _menuServices.AddMenu(menu);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteMenu(int id)
        {
            string name = String.Empty;
            if (id > 0)
            {
                name = _menuServices.GetMenu(id).Name;
            }
            return PartialView("_DeleteMenu", name);
        }

        [HttpPost]
        public ActionResult DeleteMenu(int id, FormCollection form)
        {
            if (id > 0)
            {
                _menuServices.DeleteMenu(id);
            }
            return RedirectToAction("Index");
        }

    }
}