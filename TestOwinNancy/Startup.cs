using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Nancy;
using Owin;
using TestOwinNancy.Core;
using Nancy.Owin;

[assembly: OwinStartupAttribute(typeof(TestOwinNancy.Startup))]
namespace TestOwinNancy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app
           .UseNancy(options =>
           {
               options.Bootstrapper = new ResourceBootstrapper();
               options.PerformPassThrough = (context => context.Response.StatusCode == HttpStatusCode.NotFound);
           });

           app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}
