using Hangfire;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDona.BackgrounJob
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("BackgroundJob");

            BackgroundJobServerOptions options = new BackgroundJobServerOptions
            {
                Queues = new[] { Environment.MachineName.ToLower().Replace("-", "_"), "default" }
            };

            app.UseHangfireDashboard();
            app.UseHangfireServer(options);
        }
    }
}