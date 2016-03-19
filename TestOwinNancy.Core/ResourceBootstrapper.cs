using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Nancy.ViewEngines;
using Nancy.Embedded.Conventions;

namespace TestOwinNancy.Core
{
    public class ResourceBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            
            base.ConfigureApplicationContainer(container);
            ResourceViewLocationProvider.RootNamespaces.Add(GetType().Assembly, GetType().Assembly.GetName().Name+".Views"); 
        }


        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {


            nancyConventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("Content", GetType().Assembly, "Content"));
            base.ConfigureConventions(nancyConventions);
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get { return NancyInternalConfiguration.WithOverrides(OnConfigurationBuilder); }
        }

        private void OnConfigurationBuilder(NancyInternalConfiguration x)
        {
            x.ViewLocationProvider = typeof(ResourceViewLocationProvider);
            x.StaticContentProvider = typeof(DefaultStaticContentProvider);
            
        }
    }
}
