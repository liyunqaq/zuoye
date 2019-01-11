using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",//路由名称
                 //URL3个组成部分：
                 //controller：控制器，如果为提供，默认为Home
                 //action：Action方法。如果未提供，默认为Index
                 //id：提供数据标识，没有默认值
                 url: "{controller}/{action}/{id}",
                 //定义当前启动站点的默认路由指向的控制器中的默认方法
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
