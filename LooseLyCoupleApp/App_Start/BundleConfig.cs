using System.Web;
using System.Web.Optimization;

namespace LooseLyCoupleApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js", 
                      "~/Scripts/ui-bootstrap-tpls-1.3.1.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome-4.5.0/css/font-awesome.min.css",
                      "~/Content/angular-flash.min.css",
                      "~/Content/angular-datepicker.css"));

           bundles.Add(new ScriptBundle("~/bundles/angular").Include(
               "~/Scripts/angular.js",
               "~/Scripts/angular-route.js",
               "~/Scripts/angular-ui-bootstrap.js",
               "~/Scripts/angular-cookies.js",
               "~/Scripts/dirPagination.js",
               "~/Scripts/angular-flash.min.js",
               "~/Scripts/ng-fluent-validation.js",
               "~/Scripts/angular-sanitize.min.js",
               "~/Scripts/angular-datepicker.js"
            ));

          bundles.Add(new ScriptBundle("~/bundles/shared").Include(
             "~/Scripts/CodeProjectBootstrap.js"
             //"~/Views/Shared/AjaxService.js",
             //"~/Views/Shared/AlertService.js",
             //"~/Views/Shared/DataGridService.js",
             //"~/Views/Shared/MasterController.js"
          ));

        bundles.Add(new ScriptBundle("~/bundles/home").Include(
                   "~/Scripts/Controllers/IndexController.js",
                   "~/Scripts/Controllers/AboutController.js"
                ));

        }
    }
}
