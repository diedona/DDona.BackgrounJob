using Hangfire;
using Hangfire.States;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace DDona.BackgrounJob.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            //BackgroundJob.Enqueue(() => DoStuff());
            IBackgroundJobClient client = new BackgroundJobClient();
            IState state = new EnqueuedState
            {
                Queue = Environment.MachineName.ToLower().Replace("-", "_")
            };

            client.Create(() => DoStuff(), state);

            return "Asd";
        }

        public static void DoStuff()
        {
            for(int i = 0; i < 100; i++)
            {
                Debug.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
    }
}