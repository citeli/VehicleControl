using System.Web;
using System.Web.Optimization;

namespace ControleVeiculos
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery", "https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap", "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/css", "https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css").Include("~/Content/bootstrap.css"));
            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;
        }
    }
}
