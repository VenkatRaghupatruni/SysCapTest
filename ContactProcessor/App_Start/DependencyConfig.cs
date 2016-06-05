using System.Web.Mvc;
using Microsoft.Practices.Unity;
using ContactProcessor.Services;
using ContactProcessor.Infrastructure;
using ContactProcessor.Interfaces;

namespace ContactProcessor
{
    public static class DependencyConfig
    {
        public static IUnityContainer Container;

        public static IUnityContainer Register()
        {
            //Create the container and register all the components
            Container = BuildUnityContainer();

            //Register all the services
            RegisterServices(Container);
       
            //Register the container in the MVC work flow       
            DependencyResolver.SetResolver(new MyUnityDependencyResolver(Container));
            return Container;
        }

        private static void RegisterServices(IUnityContainer _container)
        {
            _container.RegisterType(typeof(IFileSystemService), typeof(FileSystemService));
            _container.RegisterType(typeof(IFileUploader), typeof(FileUploader));
            _container.RegisterType(typeof(IFileProcessor), typeof(FileProcessor));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var unityContainer = new UnityContainer();
            return unityContainer;
        }
    }
}