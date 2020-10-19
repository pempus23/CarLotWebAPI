﻿using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoLotDAL.Repos.Templates;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace CarLotWebAPI.Infrastructure
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {

        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind<IExtendRepository<Inventory>>().To<InventoryRepo>().InSingletonScope();
            kernel.Bind<IGetList<Customer>>().To<CustomerRepo>().InSingletonScope();
            return kernel;
        }
    }
}