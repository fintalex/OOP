using Castle.Core;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using DomainModel.Abstract;
using DomainModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebUI
{
    //public class WindsorControllerFactory : DefaultControllerFactory
    //{
    //    WindsorContainer container;
    //    // конструктор:
    //    // 1. Устанавливает новый контейнер IoC.
    //    // 2. Регистрирует все компоненты, специфицированные в web.config.
    //    // 3. Регистрирует все типы контроллеров в качестве компонентов.
    //    public WindsorControllerFactory()
    //    {
    //        container.Install(new ProductsInstaller());
    //        //container = new WindsorContainer();
    //        //container.Register(Classes.FromAssemblyNamed("DomainModel").Pick().WithService.DefaultInterfaces().LifestyleTransient());
    //        //container.Register(Classes.FromAssemblyNamed("WebUI").Pick().WithService.DefaultInterfaces().LifestyleTransient());
    //        //container.Register(Classes.FromAssemblyNamed("WebUI").Where(Component.IsInNamespace("WebUI")).WithService.DefaultInterfaces().LifestyleTransient());
    //        //container.Register(Component
    //        //  .For<IProductsRepository>()
    //        //  .ImplementedBy<SqlProductRepository>());

    //        //IProductsRepository prodsRepository = container.Resolve<IProductsRepository>();
    //        // Создать экземпляр контейнера, взяв конфигурацию из web.config 
    //        //container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));

    //        // зарегистрировать все типы контроллеров как Transient
    //        //var controllerTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
    //        //                      where typeof(IController).IsAssignableFrom(t)
    //        //                      select t;
    //        //foreach (Type t in controllerTypes)
    //        //{
    //            //container.AddComponentWithLifestyle(t.FullName, t, LifestyleType.Transient);
    //            //container.Register(Classes.FromAssemblyNamed("WebUI").Where(Component.IsInNamespace("WebUI")).WithService.DefaultInterfaces().LifestyleTransient());
    //        //}
    //    }

    //    // Конструктор экземпляр контейнера, 
    //    // необходимого для обслуживания каждого запроса

    //    protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
    //    {
    //        return (IController)this.container.Resolve(controllerType);
    //    }

    //}

    //public class ProductsInstaller : IWindsorInstaller
    //{
    //    public void Install(IWindsorContainer container,
    //      IConfigurationStore store)
    //    {
    //        container.Register(Component
    //          .For<IProductsRepository>()
    //          .ImplementedBy<SqlProductRepository>());
    //    }
    //}
}