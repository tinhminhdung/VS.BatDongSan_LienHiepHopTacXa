using System.Web;
using System.Web.Optimization;

namespace VS.ECommerce_MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/js").Include(
            //          "~/Resources/Responsive/js/jquery.flexnav.js",
            //          "~/Resources/js/smoothproducts.min.js"));


            // ko thể truyền đường dẫn có http:// chỉ có thể truyền trực tiếp thôi
            bundles.Add(new StyleBundle("~/Content/css").Include(
                                        "~/Resources/css/stylesXOASSSSSSSS.css",
                                        "~/Resources/abc/owl.carousel.min7f30.css",
                                      //  "~/Resources/abc/base.scss7f30.css",
                                        "~/Resources/abc/style.scss7f30.css",
                                        "~/Resources/abc/update.scss7f30.css",
                                        "~/Resources/abc/module.scss7f30.css",
                                        "~/Resources/abc/responsive.scss7f30.css",
                                        "~/Resources/abc/lightbox_custome7f30.css",
                                        "~/Resources/css/Css_All.css",
                                        "~/Resources/css/smoothproducts.css",
                                        "~/Resources/ResponsiveNews/css/flexnav.css",
                                        "~/Resources/css/Mobile.css"));

            
            BundleTable.EnableOptimizations = true; // nén toàn bộ lại thành 1 file css
            // BundleTable.EnableOptimizations = false;// sẽ ko nén dc code
            bundles.UseCdn = true;
        }
    }
}
