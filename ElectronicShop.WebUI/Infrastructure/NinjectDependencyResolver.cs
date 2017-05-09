using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Moq;
using System.Linq;
using System.Configuration;
using ElectronicShop.Domain.Abstarct;
using ElectronicShop.Domain.Entities;
using ElectronicShop.Domain.Concrete;
using ElectronicShop.WebUI.Infrastructure.Abstract;
using ElectronicShop.WebUI.Infrastructure.Concrete;

namespace ElectronicShop.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                .AppSettings["Email.WriteAsFile"] ?? "true")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
            .WithConstructorArgument("settings", emailSettings);

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
        }
    }
