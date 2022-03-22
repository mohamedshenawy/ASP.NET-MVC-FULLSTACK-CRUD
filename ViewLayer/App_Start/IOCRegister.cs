using Autofac;
using Autofac.Integration.Mvc;
using DataContext;
using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewLayer.App_Start
{
    public class IOCRegister
    {
        public static void IocRegister()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterGeneric(typeof(ModelRepo<>)).As(typeof(IModelRepo<>)).InstancePerHttpRequest();
            builder.RegisterType<UserRepo>().InstancePerHttpRequest();
            builder.RegisterType<ContextFactory>().As<IContextFactory>().InstancePerHttpRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}