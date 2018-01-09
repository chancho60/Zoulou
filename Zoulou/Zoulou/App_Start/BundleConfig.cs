using System.Web;
using System.Web.Optimization;

namespace Zoulou
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/Bundles/scripts").Include(
                "~/Content/Scripts/jquery-{version}.js",
                "~/Content/Scripts/jquery.validate*",
                "~/Content/Scripts/material.min.js",
                "~/Content/Scripts/respond.js"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/Bundles/modernizr").Include(
                "~/Content/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/Css/material.min.css",
                "~/Content/Css/site.css",
                "~/Content/Css/PKM.css",
                "~/Content/Css/rpg-awesome.css"));
        }
    }
}
