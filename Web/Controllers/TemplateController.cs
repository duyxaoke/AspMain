using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMain.Web.Controllers
{
    public class TemplateController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

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

        // GET: Template
        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult Sidebar()
        {
            return PartialView();
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
    }
}