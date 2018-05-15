using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspMain.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "trangchu",
               "trang-chu" + ".html",
               new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               new string[] { "AspMain.Web.Controllers" }
            );
            routes.MapRoute(
                "accessdenied",
                "access-denied" + ".html",
                new { controller = "Account", action = "AccessDenied", id = UrlParameter.Optional },
                new string[] { "AspMain.Web.Controllers" }
            );


            routes.MapRoute(
               "dangxuat",
               "tai-khoan/dang-xuat" + ".html",
               new { controller = "Account", action = "LogOff", id = UrlParameter.Optional },
               new string[] { "AspMain.Web.Controllers" }
            );

            routes.MapRoute(
               "dangnhap",
               "tai-khoan/dang-nhap" + ".html",
               new { controller = "Account", action = "Login", id = UrlParameter.Optional },
               new string[] { "AspMain.Web.Controllers" }
            );

            routes.MapRoute(
               "dangky",
               "tai-khoan/dang-ky" + ".html",
               new { controller = "Account", action = "Register", id = UrlParameter.Optional },
               new string[] { "AspMain.Web.Controllers" }
            );

            routes.MapRoute(
               "datlaimatkhau",
               "tai-khoan/dat-lai-mat-khau" + ".html",
               new { controller = "Account", action = "ResetPassword", id = UrlParameter.Optional },
               new string[] { "AspMain.Web.Controllers" }
            );

            routes.MapRoute(
               "quenmatkhau",
               "tai-khoan/quen-mat-khau" + ".html",
               new { controller = "Account", action = "ForgotPassword", id = UrlParameter.Optional },
               new string[] { "AspMain.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
