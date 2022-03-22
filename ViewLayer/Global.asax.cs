using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ViewLayer.App_Start;

namespace ViewLayer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IOCRegister.IocRegister();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
