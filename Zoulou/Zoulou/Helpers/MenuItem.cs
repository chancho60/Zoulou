using System;
using System.Threading;
using System.Web.Mvc;

namespace Zoulou.Helpers {
    public static class MenuHelper {
        public static MvcHtmlString MenuItem(this HtmlHelper HtmlHelper, string Text, string Action, string Controller) {
            var CurrentController = HtmlHelper.ViewContext.RouteData.Values["controller"].ToString();
            var ListItem = new TagBuilder("li");
            var Link = new TagBuilder("a");

            if (string.Equals(CurrentController, Controller, StringComparison.CurrentCultureIgnoreCase)) {
                ListItem.AddCssClass("current");
            }

            Link.Attributes.Add("href", "/" + Thread.CurrentThread.CurrentCulture.ToString() + "/" + Controller + "/" + Action);
            Link.InnerHtml = Text;
            ListItem.InnerHtml = Link.ToString();

            return MvcHtmlString.Create(ListItem.ToString());
        }
    }
}