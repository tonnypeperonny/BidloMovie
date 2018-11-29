using System;
using System.Web.Mvc;

namespace Lab._06.MVC.Web.Helper
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper html, byte[] currentimage)
        {
            var img = $"data:image/jpg;base64,{Convert.ToBase64String(currentimage)}";
            return new MvcHtmlString("<img class=\"img-fluid rounded mb-0 mb-md-0\" src='" + img + "' alt=\"\">");
        }
    }
}