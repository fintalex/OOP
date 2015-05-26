using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DomainModel.Abstract;
using DomainModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Infrastructure.Installers
{
    public class ManagerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Classes.FromThisAssembly()
            //    .Where(type => type.Name.EndsWith("Manager"))
            //    .WithServiceDefaultInterfaces()
            //    .Configure(c => c.LifestyleTransient()));
            
            //container.Register(Classes.FromAssemblyNamed("DomainModel").Pick().WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Component
                  .For<IProductsRepository>()
                  .ImplementedBy<SqlProductRepository>());
        }
    }
}