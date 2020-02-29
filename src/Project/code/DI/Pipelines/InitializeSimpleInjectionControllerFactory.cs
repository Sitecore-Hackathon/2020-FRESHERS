using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using Sitecore.Pipelines;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.Web;
using Sitecore.Foundation.Poc.Interface;
using Sitecore.Feature.Poc.Interface;
using Sitecore.Foundation.Poc.ControlllerContext;
using Sitecore.Feature.Poc.Component;
using Glass.Mapper.Sc;

namespace Sitecore.Hackathon.Website.DI.Pipelines
{
    public class InitializeSimpleInjectionControllerFactory
    {
        public virtual void Process(PipelineArgs args)
        {
            SetControllerFactory(args);
        }

        private void SetControllerFactory(PipelineArgs args)
        {
            ContainerManager containerM = new ContainerManager();
            SetContainerOptions(containerM.Container);

            // you can customize this to what ever you need. This registers all IPackage implementations
            //PackageExtensions.RegisterPackages(containerM.Container,
            //AppDomain.CurrentDomain.GetAssemblies().Where(a =>
            //a.FullName.StartsWith("Sitecore.")));

            DependencyResolver.SetResolver(new 
                SimpleInjectorDependencyResolver(containerM.Container));
        }

        private void SetContainerOptions(Container container)
        {
            container.Options.PropertySelectionBehavior = new 
                ImportAttributePropertySelectionBehavior();
            container.Options.DefaultScopedLifestyle = new 
                WebRequestLifestyle();
            container.RegisterMvcIntegratedFilterProvider();

            container.Register<IControllerSCContext>(() =>
            new ControllerSCContext(container.GetInstance<IGlassHtml>()));
            container.Register<IContentLogic, ContentLogic>();
            container.Options.AllowOverridingRegistrations = true; //we do not want overriding registrations but if you do this is the property you set
        }
    }
}