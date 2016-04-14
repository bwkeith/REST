using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.Models;

namespace WebApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static List<Widget> Widgets { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RefreshWidgets();
        }

        public static void RefreshWidgets()
        {
            Widgets = new List<Widget>();
            Widgets.Add(new Widget { Id = 1001, Name = "Very Small Widget", PartNumber = "BW-001-0001", Value = 20.0 });
            Widgets.Add(new Widget { Id = 1002, Name = "Small Widget", PartNumber = "BW-002-0001", Value = 40.0 });
            Widgets.Add(new Widget { Id = 1003, Name = "Medium Widget", PartNumber = "BW-003-0001", Value = 50.0 });
            Widgets.Add(new Widget { Id = 1004, Name = "Large Widget", PartNumber = "BW-004-0001", Value = 60.0 });
            Widgets.Add(new Widget { Id = 1005, Name = "Very Large Widget", PartNumber = "BW-005-0001", Value = 80.0 });
            Widgets.Add(new Widget { Id = 1006, Name = "Very Small Widget Attachment Bracket", PartNumber = "BW-001-0002", Value = 4.0 });
            Widgets.Add(new Widget { Id = 1007, Name = "Small Widget Attachment Bracket", PartNumber = "BW-002-0002", Value = 8.0 });
            Widgets.Add(new Widget { Id = 1008, Name = "Medium Widget Attachment Bracket", PartNumber = "BW-003-0002", Value = 10.0 });
            Widgets.Add(new Widget { Id = 1009, Name = "Large Widget Attachment Bracket", PartNumber = "BW-004-0002", Value = 12.0 });
            Widgets.Add(new Widget { Id = 1010, Name = "Very Large Widget Attachment Bracket", PartNumber = "BW-005-0002", Value = 20.0 });
        }
    }
}
