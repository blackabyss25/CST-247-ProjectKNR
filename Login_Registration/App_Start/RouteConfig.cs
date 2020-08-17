using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Login_Registration
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Register",
              url: "{Register}",
              defaults: new { controller = "Register", action = "Register", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Login",
              url: "{Login}",
              defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Game",
              url: "{Game}",
              defaults: new { controller = "Game", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "winGame",
                url: "winGame",
                defaults: new { controller = "Game", action = "winGame", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "loseGame",
                url: "loseGame",
                defaults: new { controller = "Game", action = "loseGame", id = UrlParameter.Optional }
          );
        }
    }
}
