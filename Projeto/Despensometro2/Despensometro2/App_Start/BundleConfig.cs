using System.Web;
using System.Web.Optimization;

namespace Despensometro2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/materializejs").Include(
                "~/Scripts/materialize/materialize.js",
                "~/Scripts/materialize/materialize.min.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/estilo").Include(
                  "~/Content/Estilo.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/materializecss").Include(
                "~/Content/materialize/css/materialize.css",
                "~/Content/materialize/css/materialize.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/filtra").Include(
                "~/Scripts/Filtra.js"
            ));
            
        }
    }
}
