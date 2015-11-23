using System.Web;
using System.Web.Optimization;

namespace Contacts.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/bower_components/angular/angular.js",
                "~/bower_components/angular-route/angular-route.js",
                "~/bower_components/angular-animate/angular-animate.js",
                "~/bower_components/angular-aria/angular-aria.js",
                "~/bower_components/angular-material/angular-material.js",
                "~/bower_components/angular-messages/angular-messages.js",
                "~/bower_components/ng-breadcrumbs/ng-breadcrumbs.js"));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/bower_components/angular-material/angular-material.css",
                "~/Content/site.css"));
        }
    }
}
