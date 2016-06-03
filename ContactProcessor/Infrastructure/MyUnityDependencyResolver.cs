using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ContactProcessor.Infrastructure
{
    public class MyUnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _unityContainer;

        public MyUnityDependencyResolver(IUnityContainer container)
        {
            _unityContainer = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}