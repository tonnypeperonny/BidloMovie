using System.Web.Optimization;

namespace Lab._06.MVC.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.3.1.min.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/content/css/bootstrap.min.css",
                "~/Content/css/style.css",
                "~/Content/css/site.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/comments").Include(
                "~/Scripts/Comment/comment.js"));
        }
    }
}
