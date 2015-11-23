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
                ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/site.css"));
        }
    }
}
