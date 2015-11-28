using System.Web;
using System.Web.Optimization;

namespace Contacts.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts/lib").Include(
                "~/bower_components/angular/angular.js",
                "~/bower_components/angular-route/angular-route.js",
                "~/bower_components/angular-animate/angular-animate.js",
                "~/bower_components/angular-aria/angular-aria.js",
                "~/bower_components/angular-material/angular-material.js",
                "~/bower_components/angular-messages/angular-messages.js",
                "~/bower_components/moment/moment.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/contacts/app.js",
                "~/Scripts/contacts/themeConfig.js",
                "~/Scripts/contacts/routeConfig.js",
                "~/Scripts/contacts/contactService.js",
                "~/Scripts/contacts/searchController.js",
                "~/Scripts/contacts/form/formController.js",
                "~/Scripts/contacts/list/listController.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/bower_components/angular-material/angular-material.css",
                "~/Content/site.css"
                ));
        }
    }
}
